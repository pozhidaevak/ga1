using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    class OnePointCrossover : ICrossover
    {
        
        public OnePointCrossover(int crossoverPoint = -1)
        {
            this.crossoverPoint = crossoverPoint;
        }
       
        public IChromosome[] Crossover(IChromosome father, IChromosome mother)
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
            if (crossoverPoint <= 0)
            {
                crossoverPoint = Program.rnd.Next(1, father.Length - 1);
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
