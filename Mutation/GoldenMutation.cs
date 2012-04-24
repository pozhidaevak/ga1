using System;

namespace ga1
{
    public class GoldenMutation<T> : OnePointSwapMutation<T>, IMutation<T>
    {
        public GoldenMutation(int length)
            : base((int)Math.Round(length / 1.61803))
        {
        }

        public IChromosome<T> mutate(IChromosome<T> chromo)
        {
            return base.Mutate(chromo);
        }
    }
}