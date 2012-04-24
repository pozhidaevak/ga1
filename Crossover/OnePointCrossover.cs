using System;

namespace ga1 //бициллин
{
    public class OnePointCrossover<T> : ICrossover<T>
    {
        /// <summary>
        /// Creates instanse of OnePointCrossover
        /// </summary>
        /// <param name="crossoverPoint">possition of crossover. if not possitive, then ranndom. if bigger then chromosome.length -1 then crossoverPoint % (father.Length) + 1  </param>
        public OnePointCrossover(int crossoverPoint = -1)
        {
            this.crossoverPoint = crossoverPoint;
        }

        public virtual IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother)
        {
            CrossoverTools.CheckChromosomes(father, mother);

            if (crossoverPoint <= 0)
            {
                crossoverPoint = Program.rnd.Next(1, father.Length);
            }
            if (crossoverPoint >= father.Length)
            {
                crossoverPoint = (crossoverPoint - 1) % (father.Length - 1) + 1;
            }

            Array fatherGens = father.ToArray();
            Array motherGens = mother.ToArray();

            Array child1 = Array.CreateInstance(fatherGens.GetType().GetElementType(), father.Length);
            Array child2 = Array.CreateInstance(fatherGens.GetType().GetElementType(), father.Length);

            //this is one point crossover
            Array.Copy(fatherGens, child1, crossoverPoint);
            Array.Copy(motherGens, child2, crossoverPoint);
            Array.Copy(fatherGens, crossoverPoint, child2, crossoverPoint, fatherGens.Length - crossoverPoint);
            Array.Copy(motherGens, crossoverPoint, child1, crossoverPoint, fatherGens.Length - crossoverPoint);

            IChromosome<T>[] childArray = new IChromosome<T>[2] { ((IChromosome<T>)Activator.CreateInstance(father.GetType())).GenerateFromArray(child1),
            ((IChromosome<T>)Activator.CreateInstance(father.GetType())).GenerateFromArray(child2) };
            return childArray;
        }

        private int crossoverPoint = -1;

        public int Point
        {
            get
            {
                return crossoverPoint;
            }
        }
    }
}