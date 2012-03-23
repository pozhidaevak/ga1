using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    public class GoldenCrossover<T> : OnePointCrossover<T>, ICrossover<T> 
    {
        public const double phi = 1.61803; // golden proportion
        public GoldenCrossover(int length):base((int)Math.Round(length/phi))
        {
        }
        public override IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            return base.Crossover(father, mother);
        }
    }
}
