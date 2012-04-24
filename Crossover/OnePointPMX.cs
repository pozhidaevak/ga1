using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    /// <summary>
    /// One point partially mathched crossover
    /// </summary>
    /// <typeparam name="T">Type of gens</typeparam>
    public class OnePointPMX<T> : ICrossover<T>
    {
        public OnePointPMX(int point)
        {
            this.point = point;
        }

        public IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            //Checking input variables
            CrossoverTools.CheckChromosomes(father, mother);
            CrossoverTools.CheckPoint(ref point, father.Length);

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

            //initialaize children
            T[] child1 = new T[father.Length];
            T[] child2 = new T[father.Length];

            //copy parrents to children
            Array.Copy(fatherArr, child1, fatherArr.Length);
            Array.Copy(motherArr, child2, fatherArr.Length);

            //swap gens after point and matched gens
            int matchedGenInd1 = -1, matchedGenInd2 = -1; //indexes of matched gens in child1 and child2 respectivly
            for (int i = point; i < fatherArr.Length; ++i)
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

        private int point;

        public int Point
        {
            get
            {
                return point;
            }
        }
    }
}