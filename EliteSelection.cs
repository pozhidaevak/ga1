using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ga1
{
    public class EliteSelection<T> : ISelection<T>
    {
        public EliteSelection(int outLength, int eliteCount)
        {
            OutLength = outLength;
            EliteCount = eliteCount;
        }
        public IChromosome<T>[] Select(IChromosome<T>[] population, Population<T>.Fitness fitness)
        {
            if (population.Length <= OutLength)
            {
                throw new ArgumentOutOfRangeException("Population to small");
            }
            List<IChromosome<T>> selectedChromosomes = new List<IChromosome<T>>(population.OrderByDescending(x => fitness(x)).Take(eliteCount));
            List<IChromosome<T>> notEliteChromosomes = new List<IChromosome<T>>(population.OrderByDescending(x => fitness(x)).Skip(eliteCount));
            for (int i = 0; i < outLength - eliteCount; ++i )
            {
                int rndInd = Program.rnd.Next(0, notEliteChromosomes.Count);
                selectedChromosomes.Add(notEliteChromosomes[rndInd]);
            }
            Debug.Assert(selectedChromosomes.Count == outLength, "EliteSelection: selected wrong amount");
            return selectedChromosomes.ToArray();
        }
        private int outLength, eliteCount;
        public int OutLength
        {
            get
            {
                return outLength;
            }
            set
            {
                if (value < eliteCount || value <= 0)
                {
                    throw new ArgumentOutOfRangeException("outLength", outLength, " outLength must be bigger or equal to eliteCount");
                }
                else
                {
                    outLength = value;
                }
            }
        }
        public int EliteCount
        {
            get
            {
                return eliteCount;
            }
            set
            {
                if (value > outLength || value < 0)
                {
                    throw new ArgumentOutOfRangeException("eliteCount", eliteCount, "eliteCount must be < outLength");
                }
                else
                {
                    eliteCount = value;
                }
            }
        }
    }
}
