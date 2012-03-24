using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    public  class Population<T>
    {
        public delegate double Fitness(IChromosome<T> chromo);
        public IChromosome<T> Chromosomes { get; set; }
        public IMutation<T> Mutation { get; set; }
        public ICrossover<T> Crossover { get; set; }
        private double mutationProb;
        public double MutationProb
        {
            get
            {
                return mutationProb;
            }
            set
            {
                if (value > 1 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("MutationProb", MutationProb, "probability must be in [0,1]");
                }
                else
                {
                    mutationProb = value;
                }
            }
        }
    }
}
