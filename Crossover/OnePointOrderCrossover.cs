using System;
using System.Diagnostics;
using System.Linq;

namespace ga1
{
    public class OnePointOrderCrossover<T> : ICrossover<T>
    {
        public OnePointOrderCrossover(int point)
        {
            this.point = point;
        }

        public IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            CrossoverTools.CheckChromosomes(father, mother);
            CrossoverTools.CheckPoint(ref point, father.Length);
            T[] fatherArr = father.ToArray();
            T[] motherArr = mother.ToArray();
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

            T[] child1 = new T[father.Length];
            T[] child2 = new T[father.Length];

            //copy first parts of Parents to children
            Array.Copy(fatherArr, child1, point);
            Array.Copy(motherArr, child2, point);

            // making point the first element(circular shift array left)
            fatherArr = fatherArr.Skip(point).Concat(fatherArr.Take(point)).ToArray();
            motherArr = motherArr.Skip(point).Concat(motherArr.Take(point)).ToArray();
            //fatherArr = CrossoverTools.RotateLeft(fatherArr, point);
            //motherArr = CrossoverTools.RotateLeft(motherArr, point);

            //adding unique elements from another parent(in order from point)
            //Array subChild = Array.CreateInstance(fatherArr.GetType().GetElementType(), point);
            //int childInd = point;
            //Array.Copy(child1, subChild, point);
            //for(int i = 0; i <= fatherArr.Length; ++i)
            //{
            //if(!child1.Take(point).Contains(motherArr[i]))
            //{
            //    child1[childInd] = motherArr[i];
            //    ++childInd;
            //}
            //}

            //Calculating second part of child1 chromosmoe
            T[] childAddition = motherArr.Where(x => !child1.Take(point).Contains(x)).ToArray();
            Debug.Assert(childAddition.Length == fatherArr.Length - point, "first child");
            Array.Copy(childAddition, 0, child1, point, father.Length - point);

            //Calculating second part of child2 chromosmoe
            childAddition = fatherArr.Where(x => !child2.Take(point).Contains(x)).ToArray();
            Debug.Assert(childAddition.Length == fatherArr.Length - point, "first child");
            Array.Copy(childAddition, 0, child2, point, father.Length - point);

            //childInd =point;

            //Array.Copy(child2, subChild, point);
            //for(int i = 0; i <= fatherArr.Length; ++i)
            //{
            //    if(!Array.Exists(subChild,fatherArr[i]))
            //    {
            //        child2[childInd] = fatherArr[i];
            //        ++childInd;
            //    }
            //}
            //Debug.Assert(childInd == fatherArr.Length,"second child"); //child completel
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