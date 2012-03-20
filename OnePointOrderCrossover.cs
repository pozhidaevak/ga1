using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace ga1
{
    public class OnePointOrderCrossover<T> : ICrossover<T>
    {
        public OnePointOrderCrossover(int point)
        {
            Point = point;
        }

        public IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            CrossoverTools.CheckChromosomes(father, mother);
            if(Point <= 0)
            {
                Program.rnd.Next(1, father.Length);
            }
            if (Point >= father.Length)
            {
                Point = (Point - 1) % (father.Length - 1) + 1;
            }
            T[] fatherArr = father.ToArray();
            T[] motherArr = mother.ToArray();
            if(!Enumerable.SequenceEqual(fatherArr,fatherArr.Distinct()) ||
                !Enumerable.SequenceEqual(motherArr,motherArr.Distinct()))
            {
                throw new ArgumentOutOfRangeException("father",father,"order crossover works only with unique chromosomes");
            }
            T[] child1 = new T[father.Length];// Array.CreateInstance(fatherArr.GetType().GetElementType(), father.Length);
            T[] child2 = new T[father.Length];//Array.CreateInstance(fatherArr.GetType().GetElementType(), father.Length);

            //copy first parts of Parents to children
            Array.Copy(fatherArr, child1, Point);
            Array.Copy(motherArr, child2, Point);

            // making Point the first element(circular shift array left)
            fatherArr = fatherArr.Skip(Point).Concat(fatherArr.Take(Point)).ToArray(); 
            motherArr = motherArr.Skip(Point).Concat(motherArr.Take(Point)).ToArray();
            //fatherArr = CrossoverTools.RotateLeft(fatherArr, Point);
            //motherArr = CrossoverTools.RotateLeft(motherArr, Point);
            
            //adding unique elements from another parent(in order from Point)
            //Array subChild = Array.CreateInstance(fatherArr.GetType().GetElementType(), Point);
            //int childInd = Point;
            //Array.Copy(child1, subChild, Point);
            //for(int i = 0; i <= fatherArr.Length; ++i)
            //{
                
                //if(!child1.Take(Point).Contains(motherArr[i]))
                //{
                //    child1[childInd] = motherArr[i];
                //    ++childInd;
                //}
            //}

            //Calculating second part of child1 chromosmoe
            T[] childAddition = motherArr.Where(x => !child1.Take(Point).Contains(x)).ToArray();
            Debug.Assert(childAddition.Length == fatherArr.Length - Point,"first child");
            Array.Copy(childAddition, 0, child1, Point, father.Length - Point);

            //Calculating second part of child2 chromosmoe
            childAddition = fatherArr.Where(x => !child2.Take(Point).Contains(x)).ToArray();
            Debug.Assert(childAddition.Length == fatherArr.Length - Point, "first child");
            Array.Copy(childAddition, 0, child2, Point, father.Length - Point);

            //childInd =Point;
           
            //Array.Copy(child2, subChild, Point);
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
        public int Point { get; private set; }
        
    }
}
