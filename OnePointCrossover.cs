using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    class OnePointCrossover : ICrossover
    {
        const int CrossoverPoint = 2;
        public IChromosome[] Crossover(IChromosome father, IChromosome mother)
        {
            //TODO add type check
            if (father.Length != mother.Length)
            {
            }

            Array fatherGens = father.ToArray();
            Array motherGens = mother.ToArray();

            Array child1 = Array.CreateInstance(fatherGens.GetType().GetElementType(), father.Length);
            Array child2 = Array.CreateInstance(fatherGens.GetType().GetElementType(), father.Length);

            //this is one point crossover
            Array.Copy(fatherGens, child1, CrossoverPoint);
            Array.Copy(motherGens, child2, CrossoverPoint);
            Array.Copy(fatherGens, CrossoverPoint , child2, CrossoverPoint, fatherGens.Length - CrossoverPoint);
            Array.Copy(motherGens, CrossoverPoint, child1, CrossoverPoint, fatherGens.Length - CrossoverPoint);
            IChromosome child1Chromosome = (IChromosome)Activator.CreateInstance(father.GetType());
            IChromosome[] childArray = new IChromosome[2] { ((IChromosome)Activator.CreateInstance(father.GetType())).GenerateFromArray(child1),
                ((IChromosome)Activator.CreateInstance(father.GetType())).GenerateFromArray(child2) };
            return childArray;
        }
    }
}
