using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    class DigitalChromosome : IChromosome
    {
        public DigitalChromosome()
        {
            rnd = new Random();
        }

        public IChromosome[] Crossover(ICrossover crossover, IChromosome mother)
        {
            return crossover.Crossover(this, mother);
        }

        public IChromosome Clone()
        {
            DigitalChromosome clone = new DigitalChromosome();
            clone.GenerateFromArray(this.ToArray());
            return clone;
        }

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
            if (gens == null)
            {
                throw new Exception("Cant generate chromosome from null array");
            }
            if (this.gens != null && gens.GetType() != this.gens.GetType())
            {
                throw new Exception("GenerateFromArray(Array): Array type missmathc");
            }

            this.gens = new int[gens.Length];
            Array.Copy(gens, this.gens, gens.Length);
            return this;
        }

        public void Generate(int length)
        {
            if (length <= 0)
            {
                throw new Exception("Chromosome length must be possitive number");
            }
            gens = Enumerable.Range(1, length).OrderBy(i=>rnd.Next()).ToArray();   
        }

        public override String ToString()
        {
            String result = "";
            foreach (int elem in gens)
            {
                result += elem.ToString();
            }
            return result;
        }

        private int[] gens;
        private Random rnd;
    }
}
