using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    public class FibonacciCrossover<T> : UniversalCrossover<T>, ICrossover<T>
    {
        static Func<int, int, int, IEnumerable<int>> fib = (n, m, cap) => n + m > cap ? Enumerable.Empty<int>()
        : Enumerable.Repeat(n + m, 1).Concat(fib(m, n + m, cap));

        public FibonacciCrossover(int length)
            : base(length)
        {
            //generate fibonacci sequence
            FibArr = fib(0, 1, length).ToArray();

            //generate mask for UniversalCrossover
            base.mask[0] = false;
            for (int i = 1; i < length; ++i)
            {
                base.mask[i] = Array.FindLastIndex(FibArr, x => x <= i) % 2 == 0;
            }
        }

        public override IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            return base.Crossover(father, mother);
        }

        public int[] FibArr { get; private set; }
    }
}