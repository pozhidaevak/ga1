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
        /// <param name="point1">First point of two point crossover</param>
        /// <param name="point2">second point of two point crossover</param>
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
        private int point1, point2, length;
    }
}
