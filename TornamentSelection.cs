using System;
using System.Linq;

namespace ga1
{
    public class TornamentSelection<T> : ISelection<T>
    {
        public TornamentSelection(int tornSize)
        {
            TornSize = tornSize;
        }

        public IChromosome<T>[] Select(IChromosome<T>[] population, Population<T>.Fitness fitness, int outLength)
        {
            if (population.Length <= outLength || population.Length <= tornSize * 2)
            {
                if (population.Length == outLength)
                {
                    return population;
                }
                throw new ArgumentOutOfRangeException("Population to small");
            }
            IChromosome<T>[] outPopulation = new IChromosome<T>[outLength];
            for (int i = 0; i < outPopulation.Length; ++i)
            {
                outPopulation[i] = population.OrderBy(x => Program.rnd.Next()).Take(tornSize).OrderByDescending(x => fitness(x)).Take(1).ToArray()[0];
            }
            return outPopulation;
        }

        private int tornSize;

        public int TornSize
        {
            get
            {
                return tornSize;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("tornSize", tornSize, " tornSize must be possitive");
                }
                else
                {
                    tornSize = value;
                }
            }
        }
    }
}