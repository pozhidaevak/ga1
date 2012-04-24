using System;
using System.Diagnostics;
using System.Linq;

namespace ga1
{
    public class TwoPointOrderCrossover<T> : ICrossover<T>
    {
        public TwoPointOrderCrossover(int point1, int point2)
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

            //initialaize children
            T[] child1 = new T[father.Length];
            T[] child2 = new T[father.Length];

            //copy constant parts from parrents to children
            Array.Copy(fatherArr, child1, point1);
            Array.Copy(fatherArr, point2, child1, point2, father.Length - point2);

            Array.Copy(motherArr, child2, point1);
            Array.Copy(motherArr, point2, child2, point2, father.Length - point2);

            //calculate modified(middle) part of children
            T[] childAddition = motherArr.Where(x => !child1.Take(point1).Concat(child1.Skip(point2)).Contains(x)).ToArray();
            Debug.Assert(childAddition.Length == fatherArr.Length - point1 - (fatherArr.Length - point2), "first child");
            Array.Copy(childAddition, 0, child1, point1, fatherArr.Length - point1 - (fatherArr.Length - point2));

            childAddition = fatherArr.Where(x => !child2.Take(point1).Concat(child2.Skip(point2)).Contains(x)).ToArray();
            Debug.Assert(childAddition.Length == fatherArr.Length - point1 - (fatherArr.Length - point2), "first child");
            Array.Copy(childAddition, 0, child2, point1, fatherArr.Length - point1 - (fatherArr.Length - point2));

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