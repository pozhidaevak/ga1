using System;

namespace ga1
{
    public static class CrossoverTools
    {
        /// <summary>
        /// Check chromosomes for null value, type and length. Throws exception if something wrong
        /// </summary>
        /// <param name="father">first chromosome</param>
        /// <param name="mother">second chromosome</param>
        public static void CheckChromosomes<T>(IChromosome<T> father, IChromosome<T> mother)
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
        }

        /// <summary>
        /// Check point value in [1,length)
        /// </summary>
        /// <remarks> if point value not possitive, then randomize point. if point value more or equal length, then mod point value</remarks>
        /// <param name="point">point value</param>
        /// <param name="length">length of chromosome</param>
        public static void CheckPoint(ref int point, int length)
        {
            if (point >= length)
            {
                point = (point - 1) % (length - 1) + 1;
            }
            else
            {
                if (point <= 0)
                {
                    point = Program.rnd.Next(1, length); // [1,length)
                }
            }
        }

        public static Array RotateLeft(Array array, int places)
        {
            Array temp = Array.CreateInstance(array.GetType().GetElementType(), places);
            Array.Copy(array, 0, temp, 0, places);
            Array.Copy(array, places, array, 0, array.Length - places);
            Array.Copy(temp, 0, array, array.Length - places, places);
            return array;
        }

        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}