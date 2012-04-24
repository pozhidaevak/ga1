namespace ga1
{
    /// <summary>
    /// Implements two point crossover by using UniversalCrossover
    /// </summary>
    public class TwoPointCrossover<T> : UniversalCrossover<T>, ICrossover<T>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="point1">First point of two point crossover. from 1 to length - 1</param>
        /// <param name="point2">second point of two point crossover.  from 1 to length - 1</param>
        /// <param name="length">length of cromosome</param>
        /// <remarks>if points are not possitive, then use random points. if bigger then length-1 -- take modulo</remarks>
        public TwoPointCrossover(int point1, int point2, int length)
            : base(length)
        {
            if (point1 > point2)
            {
                this.point2 = point1;
                this.point1 = point2;
            }
            else
            {
                this.point1 = point1;
                this.point2 = point2;
            }
        }

        public override IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            CrossoverTools.CheckPoint(ref point1, base.mask.Length);
            CrossoverTools.CheckPoint(ref point2, base.mask.Length);

            if (point2 < point1)
            {
                point1 ^= point2 ^= point1 ^= point2; // Yeah! XOR Swap))))
            }
            if (point1 == point2)
            {
                ++point2;
            }

            for (int i = 0; i < base.mask.Length; ++i)
            {
                base.mask[i] = i >= point1 && i < point2;
            }
            return base.Crossover(father, mother);
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

        public int Length
        {
            get
            {
                return base.mask.Length;
            }
        }
    }
}