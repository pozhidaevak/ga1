using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    class DigitalChromosome : IChromosome
    {

        public IChromosome[] Crossover(ICrossover crossover, IChromosome mother)
        {
            return crossover.Crossover(this, mother);
        }

        private int[] gens;
        public Array ToArray()
        {
            return gens;
        }
        public int Length
        {
            get
            {
                return gens.Length;
            }
        }
        public IChromosome GenerateFromArray(Array gens)
        {
            //TODO check type
            this.gens = new int[gens.Length];
            Array.Copy(gens, this.gens, gens.Length);
            return this;
        }
        public void Generate(int length)
        {
            //gens = new int[length];
            Random rnd = new Random();
            gens = Enumerable.Range(1, length).OrderBy(i=>rnd.Next()).ToArray();
            

        }

    }
}
