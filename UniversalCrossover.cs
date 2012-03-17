using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ga1
{
    class UniversalCrossover : ICrossover
    {
        protected BitArray mask;
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
        public BitArray Mask { get { return mask; } }

        public virtual IChromosome[] Crossover(IChromosome father, IChromosome mother)
        {
            if (father == null || mother == null)
            {
                throw new Exception("virgin birth will be implemented in next version..."); // ;-)
            }

            if (father.Length != mother.Length)
            {
                throw new Exception("Parents' chromosomes has different length");
            }
            if (father.GetType() != mother.GetType())
            {
                throw new Exception("Parents' has different types of chromosomes");
            }
            if (mask.Length < father.Length)
            {
                throw new Exception("Mask too short");
            }

            dynamic fatherGens = father.ToArray();
            dynamic motherGens = mother.ToArray();

            dynamic child1 = Array.CreateInstance(fatherGens.GetType().GetElementType(), father.Length);
            dynamic child2 = Array.CreateInstance(fatherGens.GetType().GetElementType(), father.Length);

            for (int i = 0; i < fatherGens.Length; ++i)
            {
                child1[i] = mask[i] ? motherGens[i] : fatherGens[i];
                child2[i] = mask[i] ? fatherGens[i] : motherGens[i];
            }

            IChromosome[] childArray = new IChromosome[2] { ((IChromosome)Activator.CreateInstance(father.GetType())).GenerateFromArray(child1),
                ((IChromosome)Activator.CreateInstance(father.GetType())).GenerateFromArray(child2) };
            return childArray;

        }

    }
}
