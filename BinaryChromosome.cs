using System;
using System.Linq;

namespace ga1
{
    public class BinaryChromosome : IChromosome<bool>
    {
        public BinaryChromosome()
        {
        }

        public IChromosome<bool>[] Crossover(ICrossover<bool> crossover, IChromosome<bool> mother)
        {
            return crossover.Crossover(this, mother);
        }

        public IChromosome<bool> Clone()
        {
            BinaryChromosome clone = new BinaryChromosome();
            clone.GenerateFromArray(this.ToArray());
            return clone;
        }

        public bool[] ToArray()
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

        public IChromosome<bool> GenerateFromArray(Array gens)
        {
            if (gens == null)
            {
                throw new Exception("Cant generate chromosome from null array");
            }
            if (this.gens != null && gens.GetType() != this.gens.GetType())
            {
                throw new Exception("GenerateFromArray(Array): Array type missmathc");
            }

            this.gens = new bool[gens.Length];
            Array.Copy(gens, this.gens, gens.Length);
            return this;
        }

        public IChromosome<bool> Generate(int length)
        {
            if (length <= 0)
            {
                throw new Exception("Chromosome length must be possitive number");
            }
            gens = new bool[length];
            for (int i = 0; i < length; ++i)
                gens[i] = Program.rnd.Next(0, 2) == 0 ? false : true;
            return this;
        }

        public static bool operator ==(BinaryChromosome lhs, BinaryChromosome rhs)
        {
            return lhs.gens.SequenceEqual(rhs.gens);
        }

        public static bool operator !=(BinaryChromosome lhs, BinaryChromosome rhs)
        {
            return !lhs.gens.SequenceEqual(rhs.gens);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == this.GetType() && this == (BinaryChromosome)obj;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException("DigitalChromosome.GetHashCode");
            return base.GetHashCode();
        }

        private bool[] gens;
    }
}