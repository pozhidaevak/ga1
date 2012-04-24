using System;
using System.Linq;

namespace ga1
{
    public class DigitalChromosome : IChromosome<int>
    {
        public DigitalChromosome()
        {
        }

        public IChromosome<int>[] Crossover(ICrossover<int> crossover, IChromosome<int> mother)
        {
            return crossover.Crossover(this, mother);
        }

        public IChromosome<int> Clone()
        {
            DigitalChromosome clone = new DigitalChromosome();
            clone.GenerateFromArray(this.ToArray());
            return clone;
        }

        public int[] ToArray()
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

        public IChromosome<int> GenerateFromArray(Array gens)
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

        public IChromosome<int> Generate(int length)
        {
            if (length <= 0)
            {
                throw new Exception("Chromosome length must be possitive number");
            }
            gens = Enumerable.Range(1, length).OrderBy(i => Program.rnd.Next()).ToArray(); //generates shuffled array. items from 1 to length
            return this;
        }

        public override String ToString()
        {
            String result = "";
            foreach (int elem in gens)
            {
                result += elem.ToString();
                result += " ";
            }
            return result;
        }

        private int[] gens;

        public static bool operator ==(DigitalChromosome lhs, DigitalChromosome rhs)
        {
            return lhs.gens.SequenceEqual(rhs.gens);
        }

        public static bool operator !=(DigitalChromosome lhs, DigitalChromosome rhs)
        {
            return !lhs.gens.SequenceEqual(rhs.gens);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == this.GetType() && this == (DigitalChromosome)obj;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException("DigitalChromosome.GetHashCode");
            return base.GetHashCode();
        }
    }
}