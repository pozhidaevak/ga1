using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    static class CrossoverTools
    {
        /// <summary>
        /// Check point value
        /// </summary>
        /// <remarks> if point value not possitive, then randomize point. if point value more or equal length, then mod point value</remarks>
        /// <param name="point">point value</param>
        /// <param name="length">length of chromosome</param>
        public static void CheckPoint(ref int point,  int length)
        {
            if (point >= length)
            {
                point = point % (length - 1) + 1;
            }
            else if (point <= 0)
            {
                point = Program.rnd.Next(1, length); // [1,length)
            }
        }
    }
}
