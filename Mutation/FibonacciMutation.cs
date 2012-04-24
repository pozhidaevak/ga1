using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    public class FibonacciMutation<T> : IMutation<T>
    {
        static Func<int, int, int, IEnumerable<int>> fib = (n, m, cap) => n + m > cap ? Enumerable.Empty<int>()
            : Enumerable.Repeat(n + m, 1).Concat(fib(m, n + m, cap));

        public FibonacciMutation(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "length must be positive");
            }
            //generate fibonacci sequence
            fibArr = fib(0, 1, length).ToArray();
            this.length = length;
        }

        public IChromosome<T> Mutate(IChromosome<T> chromo)
        {
            if (chromo.Length > length)
            {
                throw new ArgumentOutOfRangeException("chromo", chromo, "chromosome is too big");
            }
            T[] chromoGens = chromo.ToArray();

            for (int i = Array.FindLastIndex(fibArr, x => x <= chromoGens.Length); i > 0; --i)
            {
                CrossoverTools.Swap<T>(ref chromoGens[fibArr[i] - 1], ref chromoGens[fibArr[i - 1] - 1]);
            }
            return ((IChromosome<T>)Activator.CreateInstance(chromo.GetType())).GenerateFromArray(chromoGens);
        }

        private int[] fibArr;
        private int length;

        public int[] FibArr
        {
            get
            {
                return fibArr;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
        }
    }
}