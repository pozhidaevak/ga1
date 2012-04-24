using System;
using System.Linq;

namespace ga1
{
    public class Translocation<T> : IMutation<T>
    {
        /// <summary>
        /// swap [point1,point2] and [point3,point4]
        /// </summary>
        public Translocation(int point1, int point2, int point3, int point4)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
            this.point4 = point4;
        }

        public IChromosome<T> Mutate(IChromosome<T> chromo)
        {
            if (point1 >= chromo.Length || point2 >= chromo.Length ||
            point3 >= chromo.Length || point4 >= chromo.Length)
            {
                throw new ArgumentOutOfRangeException("Translocation: chromo too short");
            }
            if (point1 < 0)
            {
                point1 = Program.rnd.Next(0, chromo.Length);
            }
            if (point2 < 0)
            {
                point2 = Program.rnd.Next(point1, chromo.Length);
            }
            if (point3 < 0)
            {
                point3 = Program.rnd.Next(point2 + 1, chromo.Length);
            }
            if (point4 < 0)
            {
                point4 = Program.rnd.Next(point3, chromo.Length);
            }
            if (point1 > point2 || point3 > point4 || point2 >= point3)
            {
                throw new ArgumentOutOfRangeException("Translocation: wrong points");
            }

            T[] chromoGens = chromo.ToArray();
            chromoGens = chromoGens.Take(point1).Concat(chromoGens.Skip(point3).Take(point4 - point3 + 1)).Concat(chromoGens.Skip(point2 + 1).Take(point3 - point2 - 1))
            .Concat(chromoGens.Skip(point1).Take(point2 - point1 + 1)).Concat(chromoGens.Skip(point4 + 1)).ToArray();
            return ((IChromosome<T>)Activator.CreateInstance(chromo.GetType())).GenerateFromArray(chromoGens);
        }

        private int point1, point2, point3, point4;

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

        public int Point3
        {
            get
            {
                return point3;
            }
        }

        public int Point4
        {
            get
            {
                return point4;
            }
        }
    }
}