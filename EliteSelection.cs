using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    public class EliteSelection<T>:ISelection<T>
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
            List<IChromosome<T>> selectedChromosomes = new List<IChromosome<T>>(population.OrderBy(x => fitness(x)).Take(eliteCount));
            for (int i = 0; i < outLength - eliteCount; )
            {
                int rndInd = Program.rnd.Next(0, population.Length);
                if (!selectedChromosomes.Contains(population[rndInd]))
                {
                    selectedChromosomes.Add(population[rndInd]);
                    ++i;
                }
            }
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
                if (value < eliteCount)
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
                if (value > outLength)
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
