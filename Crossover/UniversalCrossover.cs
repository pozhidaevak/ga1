using System;
using System.Collections;

namespace ga1
{
    public class UniversalCrossover<T> : ICrossover<T>
    {
        protected BitArray mask;

        public BitArray Mask
        {
            get
            {
                return mask;
            }
        }

        public UniversalCrossover(BitArray mask)
        {
            this.mask = new BitArray(mask);
        }

        public UniversalCrossover(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "length of array must be possitive");
            }
            mask = new BitArray(length);
            mask.Length = length;
        }

        public BitArray RandomizeMask()
        {
            int length = mask.Length;
            byte[] arr = new byte[Convert.ToInt32(Math.Ceiling((double)Mask.Length / 8.0))];
            Program.rnd.NextBytes(arr);
            mask = new BitArray(arr);
            mask.Length = length;
            return Mask;
        }

        public virtual IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            CrossoverTools.CheckChromosomes(father, mother);
            if (mask.Length < father.Length)
            {
                throw new Exception("Mask too short");
            }

            T[] fatherGens = father.ToArray();
            T[] motherGens = mother.ToArray();

            T[] child1 = new T[father.Length];
            T[] child2 = new T[father.Length];

            for (int i = 0; i < fatherGens.Length; ++i)
            {
                child1[i] = mask[i] ? motherGens[i] : fatherGens[i];
                child2[i] = mask[i] ? fatherGens[i] : motherGens[i];
            }

            IChromosome<T>[] childArray = new IChromosome<T>[2] { ((IChromosome<T>)Activator.CreateInstance(father.GetType())).GenerateFromArray(child1),
            ((IChromosome<T>)Activator.CreateInstance(father.GetType())).GenerateFromArray(child2) };
            return childArray;
        }
    }
}