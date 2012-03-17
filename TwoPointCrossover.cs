using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    /// <summary>
    /// Implements two point crossover by using UniversalCrossover
    /// </summary>
    class TwoPointCrossover : UniversalCrossover, ICrossover
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point1">First point of two point crossover. from 1 to length - 1</param>
        /// <param name="point2">second point of two point crossover.  from 1 to length - 1</param>
        /// <param name="length">length of cromosome</param>
        /// <remarks>if points are not possitive, then use random points</remarks>
        public TwoPointCrossover(int point1, int point2, int length) : base(length)
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
        public override IChromosome[] Crossover(IChromosome father, IChromosome mother)
        {
            CheckPoint(ref point1);
            CheckPoint(ref point2);

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

        /// <summary>
        /// Check point value
        /// </summary>
        /// <remarks> if point value not possitive, then randomize point. if point value more or equal length, then mod point value</remarks>
        /// <param name="point">point value</param>
        private void CheckPoint(ref int point)
        {
            if (point >= base.mask.Length)
            {
                point = point % (base.mask.Length - 1) + 1;
            }
            else if (point <= 0)
            {
                point = Program.rnd.Next(1, base.mask.Length);
            }
        }
        private int point1, point2;
        public int Point1
        {
            get
            { return point1; }
        }
        public int Point2
        {
            get
            { return point2; }
        }
        public int Length
        {
            get
            { return base.mask.Length; }
        }
    }
}
