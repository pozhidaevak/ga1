using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    class ThreePointCrossover:UniversalCrossover, ICrossover
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

        public override IChromosome[] Crossover(IChromosome father, IChromosome mother)
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
