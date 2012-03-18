using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1 //бициллин
{
    class OnePointCrossover : ICrossover
    {
        /// <summary>
        /// Creates instanse of OnePointCrossover
        /// </summary>
        /// <param name="crossoverPoint">possition of crossover. if not possitive, then ranndom. if bigger then chromosome.length -1 then crossoverPoint % (father.Length) + 1  </param>
        public OnePointCrossover(int crossoverPoint = -1)
        {
            this.crossoverPoint = crossoverPoint;
        }
       
        public IChromosome[] Crossover(IChromosome father, IChromosome mother)
        {
            CrossoverTools.CheckChromosomes(father, mother);

            if (crossoverPoint <= 0)
            {
                crossoverPoint = Program.rnd.Next(1, father.Length);
            }
            if (crossoverPoint >= father.Length)
            {
                crossoverPoint = crossoverPoint % (father.Length - 1) + 1;
            }


            Array fatherGens = father.ToArray();
            Array motherGens = mother.ToArray();

            Array child1 = Array.CreateInstance(fatherGens.GetType().GetElementType(), father.Length);
            Array child2 = Array.CreateInstance(fatherGens.GetType().GetElementType(), father.Length);

            //this is one point crossover
            Array.Copy(fatherGens, child1, crossoverPoint);
            Array.Copy(motherGens, child2, crossoverPoint);
            Array.Copy(fatherGens, crossoverPoint , child2, crossoverPoint, fatherGens.Length - crossoverPoint);
            Array.Copy(motherGens, crossoverPoint, child1, crossoverPoint, fatherGens.Length - crossoverPoint);
          
            IChromosome[] childArray = new IChromosome[2] { ((IChromosome)Activator.CreateInstance(father.GetType())).GenerateFromArray(child1),
                ((IChromosome)Activator.CreateInstance(father.GetType())).GenerateFromArray(child2) };
            return childArray;
        }

        private int crossoverPoint = -1;
        
    }
}
