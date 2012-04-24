using System;
using System.Linq;

namespace ga1
{
    public class ThreePointCrossover<T> : UniversalCrossover<T>, ICrossover<T>
    {
        public ThreePointCrossover(int[] points, int length)
            : base(length)
        {
            if (points == null || points.Length != 3)
            {
                throw new ArgumentOutOfRangeException("points", points, "ThreePointCrossover must have three points");
            }
            Points = points.OrderBy(x => x).ToArray();
        }

        public override IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            for (int i = 0; i < Points.Length; ++i)
            {
                CrossoverTools.CheckPoint(ref Points[i], base.mask.Length);
            }
            Points = Points.OrderBy(x => x).ToArray();
            for (int i = 0; i < base.mask.Length; ++i)
            {
                base.mask[i] = (i >= Points[0] && i < Points[1]) || (i >= Points[2]);
            }
            return base.Crossover(father, mother);
        }

        public int[] Points { get; private set; }
    }
}