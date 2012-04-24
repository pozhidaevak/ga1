using System;

namespace ga1
{
    public class SwapMutation<T> : IMutation<T>
    {
        public SwapMutation(int point1, int point2)
        {
            if (point1 == point2)
            {
                ++point2;
            }
            this.point1 = point1;
            this.point2 = point2;
        }

        public IChromosome<T> Mutate(IChromosome<T> chromo)
        {
            MutationTools.CheckPoint(ref point1, chromo.Length);
            MutationTools.CheckPoint(ref point2, chromo.Length);
            if (point1 == point2)
            {
                ++point2;
            }
            T[] chromoGens = chromo.ToArray();
            CrossoverTools.Swap<T>(ref chromoGens[point1], ref chromoGens[point2]);
            return ((IChromosome<T>)Activator.CreateInstance(chromo.GetType())).GenerateFromArray(chromoGens);
        }

        private int point1, point2;

        public int Point1
        {
            get
            {
                return point1;
            }
        }

        public int Point2
        {
            get
            {
                return point2;
            }
        }
    }
}