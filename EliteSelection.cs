using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace ga1
{
    public class EliteSelection<T> : ISelection<T>
    {
        public EliteSelection( int eliteCount)
        {
            
            EliteCount = eliteCount;
        }
        public IChromosome<T>[] Select(IChromosome<T>[] population, Population<T>.Fitness fitness, int outLength)
        {
            if (population.Length <= outLength)
            {
                if (population.Length == outLength)
                {
                    return population;
                }
                throw new ArgumentOutOfRangeException("Population to small");
            }
            List<IChromosome<T>> selectedChromosomes = new List<IChromosome<T>>(population.OrderByDescending(x => fitness(x)).Take(EliteCount));
            List<IChromosome<T>> notEliteChromosomes = new List<IChromosome<T>>(population.OrderByDescending(x => fitness(x)).Skip(EliteCount));
            for (int i = 0; i < outLength - EliteCount; ++i )
            {
                int rndInd = Program.rnd.Next(0, notEliteChromosomes.Count);
                selectedChromosomes.Add(notEliteChromosomes[rndInd]);
            }
            Debug.Assert(selectedChromosomes.Count == outLength, "EliteSelection: selected wrong amount");
            return selectedChromosomes.ToArray();
        }


        public int EliteCount { get; set; }
        
    }
}
