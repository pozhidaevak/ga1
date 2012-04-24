using System;
using System.Linq;

namespace ga1
{
    public class Deletion<T> : IMutation<T>
    {
        /// <summary>
        /// delete part of chromo with indexes [point1, point2]
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public Deletion(int point1, int point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public IChromosome<T> Mutate(IChromosome<T> chromo)
        {
            MutationTools.CheckPoint(ref point1, chromo.Length);
            MutationTools.CheckPoint(ref point2, chromo.Length);
            if (point2 < point1)
            {
                point1 ^= point2 ^= point1 ^= point2;
            }

            T[] chromoGens = chromo.ToArray();
            chromoGens = chromoGens.Take(point1).Concat(chromoGens.Skip(point2 + 1)).ToArray();
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