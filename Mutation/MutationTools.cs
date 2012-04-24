namespace ga1
{
    public class MutationTools
    {
        /// <summary>
        /// point going to interval [0,length)
        /// </summary>
        /// <param name="point">if negative then rnd if greater than length then modulo...must be [0,length) afther this func</param>
        /// <param name="length">length</param>
        public static void CheckPoint(ref int point, int length)
        {
            if (point >= length)
            {
                point = point % length;
            }
            if (point < 0)
            {
                Program.rnd.Next(0, length);
            }
        }
    }
}