using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    /// <summary>
    /// Two point partially mathched crossover
    /// </summary>
    /// <typeparam name="T">Type of gens</typeparam>
    public class TwoPointPMX<T> : ICrossover<T>
    {
        public TwoPointPMX(int point1, int point2)
        {
            if (point1 > point2)
            {
                this.point2 = point1;
                this.point1 = point2;
            }
            else
            {
                this.point1 = point1;
                this.point2 = point2;
            }
        }

        public IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            //Checking input variables
            CrossoverTools.CheckChromosomes(father, mother);
            CrossoverTools.CheckPoint(ref point1, father.Length);
            CrossoverTools.CheckPoint(ref point2, father.Length);

            //cast partents to arrays
            T[] fatherArr = father.ToArray();
            T[] motherArr = mother.ToArray();

            //check uniqueness
            if (!Enumerable.SequenceEqual(fatherArr, fatherArr.Distinct()) ||
                !Enumerable.SequenceEqual(motherArr, motherArr.Distinct()))
            {
                throw new ArgumentOutOfRangeException("father", father, "order crossover works only with unique chromosomes");
            }

            //check for equality of gen sets
            if (!Enumerable.SequenceEqual(fatherArr.OrderBy(x => x), motherArr.OrderBy(x => x)))
            {
                throw new ArgumentOutOfRangeException("father", father, "sets of gens in mother and father aren't equal");
            }

            //sort points
            if (point2 < point1)
            {
                point1 ^= point2 ^= point1 ^= point2; // Yeah! XOR Swap))))
            }
            if (point1 == point2)
            {
                ++point2;
            }

            //initialaize children
            T[] child1 = new T[father.Length];
            T[] child2 = new T[father.Length];

            //copy parrents to children
            Array.Copy(fatherArr, child1, fatherArr.Length);
            Array.Copy(motherArr, child2, fatherArr.Length);

            //swap gens after point and matched gens
            int matchedGenInd1 = -1, matchedGenInd2 = -1; //indexes of matched gens in child1 and child2 respectivly
            for (int i = point1; i < point2; ++i)
            {
                if (!EqualityComparer<T>.Default.Equals(child1[i], child2[i])) //equivalent to child1[i] != child2[i]
                {
                    matchedGenInd1 = Array.FindIndex(child1, x => EqualityComparer<T>.Default.Equals(x, child2[i]));
                    matchedGenInd2 = Array.FindIndex(child2, x => EqualityComparer<T>.Default.Equals(x, child1[i]));
                    CrossoverTools.Swap<T>(ref child1[matchedGenInd1], ref child1[i]);
                    CrossoverTools.Swap<T>(ref child2[matchedGenInd2], ref child2[i]);
                }
            }

            //Form children array and return it
            IChromosome<T>[] childArray = new IChromosome<T>[2] { ((IChromosome<T>)Activator.CreateInstance(father.GetType())).GenerateFromArray(child1),
                ((IChromosome<T>)Activator.CreateInstance(father.GetType())).GenerateFromArray(child2) };
            return childArray;
        }

        private int point1, point2;

        public int Point1
        {
            get
            {
                return point1;
            }
        }

        public int Point2
        {
            get
            {
                return point2;
            }
        }
    }
}