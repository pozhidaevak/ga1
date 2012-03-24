using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    public class PointMutation : IMutation<bool>
    {
        public PointMutation(double probability)
        {
            this.probability = probability;
        }

        public IChromosome<bool> Mutate(IChromosome<bool> chromo)
        {
            bool[] chromoGens = chromo.ToArray();
            for (int i = 0; i < chromo.Length; ++i)
            {
                if (Program.rnd.NextDouble() <= probability)
                {
                    chromoGens[i] = !chromoGens[i];
                }
            }
            return ((IChromosome<bool>)Activator.CreateInstance(chromo.GetType())).GenerateFromArray(chromoGens);
        }
        private double probability;
    }
}
