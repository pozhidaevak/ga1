using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    public class CicleCrossover<T> : UniversalCrossover<T>, ICrossover<T>
    {
        public CicleCrossover(int length)
            : base(length)
        {
        }

        public override IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            //Checking input variables
            CrossoverTools.CheckChromosomes(father, mother);
            if (mask.Length < father.Length)
            {
                throw new Exception("Mask too short");
            }

            T[] fatherGens = father.ToArray();
            T[] motherGens = mother.ToArray();

            //check uniqueness
            if (!Enumerable.SequenceEqual(fatherGens, fatherGens.Distinct()) ||
            !Enumerable.SequenceEqual(motherGens, motherGens.Distinct()))
            {
                throw new ArgumentOutOfRangeException("father", father, "order crossover works only with unique chromosomes");
            }

            //check for equality of gen sets
            if (!Enumerable.SequenceEqual(fatherGens.OrderBy(x => x), motherGens.OrderBy(x => x)))
            {
                throw new ArgumentOutOfRangeException("father", father, "sets of gens in mother and father aren't equal");
            }

            //gens than was in cicle
            bool[] usedGens = new bool[base.mask.Length];
            T[] currentParent = fatherGens; //cicle iterations starts on it's items
            T[] anotherParent = motherGens; // cicle iterations ends on it's items

            //all cicles
            while (usedGens.Where(x => x == false).Count() != 0)
            {
                int StartCicleInd = Array.FindIndex(usedGens, x => x == false);
                //int EndCicleInd = -1;
                int currentItemInd = StartCicleInd;
                //mask[StartCicleInd] = (currentParent == motherGens);
                //One cycle
                do
                {
                    mask[currentItemInd] = (currentParent == motherGens);
                    usedGens[currentItemInd] = true;
                    currentItemInd = Array.FindIndex(currentParent, x => EqualityComparer<T>.Default.Equals(x, anotherParent[currentItemInd]));
                }
                while (StartCicleInd != currentItemInd);
                CrossoverTools.Swap<T[]>(ref currentParent, ref anotherParent);
            }

            return base.Crossover(father, mother);
        }
    }
}