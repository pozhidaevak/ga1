using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    public class RouletteSelection<T> : ISelection<T>
    {
        public RouletteSelection(int outLength)
        {
            OutLength = outLength;
        }
        public IChromosome<T>[] Select(IChromosome<T>[] population, Population<T>.Fitness fitness)
        {
            if (population.Length <= OutLength)
            {
                throw new ArgumentOutOfRangeException("Population to small");
            }
            double[] fitnessArr = population.Select(x => fitness(x)).ToArray();
            if (fitnessArr.Where(x => x < 0).Count() != 0)
            {
                throw new Exception("negative fitness");
            }
            var map = population.Zip(fitnessArr, (chromo, fit) => new { chromo, fit }).ToList();
            List<IChromosome<T>> outPopulation = new List<IChromosome<T>>();
            for (int i = 0; i < OutLength; ++i)
            {
                double fitSum = map.Select(x => x.fit).Sum();
                double[] rulFit = map.Select(x => x.fit / fitSum).ToArray();
                for (int j = 1; j < rulFit.Length; ++j)
                {
                    rulFit[j] += rulFit[j - 1];
                }
                double rnd = Program.rnd.NextDouble();
                int selectedInd = Array.FindIndex(rulFit, x => x >= rnd);
                outPopulation.Add(map.Select(x => x.chromo).ToArray()[selectedInd]);
                map.RemoveAt(selectedInd);
            }
            return outPopulation.ToArray();
        }
        private int outLength;
        public int OutLength
        {
            get
            {
                return outLength;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("outLength", outLength, " must be possitive");
                }
                else
                {
                    outLength = value;
                }
            }
        }
        
    }
}
