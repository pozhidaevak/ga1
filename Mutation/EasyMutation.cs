using System;

namespace ga1
{
    public class EasyMutation : IMutation<bool>
    {
        public EasyMutation(int point)
        {
            this.point = point;
        }

        public IChromosome<bool> Mutate(IChromosome<bool> chromo)
        {
            if (point >= chromo.Length)
            {
                point = point % chromo.Length;
            }
            if (point < 0)
            {
                Program.rnd.Next(0, chromo.Length);
            }
            bool[] chromoGens = chromo.ToArray();
            chromoGens[point] = !chromoGens[point];
            return ((IChromosome<bool>)Activator.CreateInstance(chromo.GetType())).GenerateFromArray(chromoGens);
        }

        private int point;

        public int Point
        {
            get
            {
                return point;
            }
        }
    }
}