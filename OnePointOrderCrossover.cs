using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace ga1
{
    class OnePointOrderCrossover<T> : ICrossover<T>
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
                Point = Point % (father.Length - 1) + 1;
            }
            dynamic fatherArr = father.ToArray();
            dynamic motherArr = mother.ToArray();
            //if(!Enumerable.SequenceEqual(fatherArr,fatherArr.Distinct()) ||
            //    !Enumerable.SequenceEqual(motherArr,motherArr.Distinct()))
            //{
            //    throw new ArgumentOutOfRangeException("father",father,"order crossover works only with unique chromosomes");
            //}
            dynamic child1 = Array.CreateInstance(fatherArr.GetType().GetElementType(), father.Length);
            dynamic child2 = Array.CreateInstance(fatherArr.GetType().GetElementType(), father.Length);

            Array.Copy(fatherArr, child1, Point);
            Array.Copy(motherArr, child2, Point);
            
            int[] test ={1}; //TODO: delete this
            //fatherArr = fatherArr.Skip(Point).Concat(fatherArr.Take(Point)).ToArray(); // make Point the first element(circular shift array)
            //motherArr = motherArr.Skip(Point).Concat(motherArr.Take(Point)).ToArray();
            fatherArr = CrossoverTools.RotateLeft(fatherArr, Point);
            motherArr = CrossoverTools.RotateLeft(motherArr, Point);
            
            //adding unique elements from another parent(in order from Point)
            Array subChild = Array.CreateInstance(fatherArr.GetType().GetElementType(), Point);
            int childInd = Point;
            Array.Copy(child1, subChild, Point);
            for(int i = 0; i <= fatherArr.Length; ++i)
            {
                if(!Array.Exists(subChild,motherArr[i]))
                {
                    child1[childInd] = motherArr[i];
                    ++childInd;
                }
            }
            Debug.Assert(childInd == fatherArr.Length,"first child"); //

            childInd =Point;
           
            Array.Copy(child2, subChild, Point);
            for(int i = 0; i <= fatherArr.Length; ++i)
            {
                if(!Array.Exists(subChild,fatherArr[i]))
                {
                    child2[childInd] = fatherArr[i];
                    ++childInd;
                }
            }
            Debug.Assert(childInd == fatherArr.Length,"second child"); //child completel
            IChromosome[] childArray = new IChromosome[2] { ((IChromosome)Activator.CreateInstance(father.GetType())).GenerateFromArray(child1),
                ((IChromosome)Activator.CreateInstance(father.GetType())).GenerateFromArray(child2) };
            return childArray;

        }
        public int Point { get; private set; }
        
    }
}
