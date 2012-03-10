using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    interface IChromosome
    {
        /// <summary>
        /// Generate random chromosome value.
        /// </summary>
        /// 
        /// <remarks><para>Regenerates chromosome's value using random number generator.</para>
        /// </remarks>
        /// 
        void Generate(int length);


        /// <summary>
        /// Clone the chromosome.
        /// </summary>
        /// 
        /// <remarks><para>The method clones the chromosome returning the exact copy of it.</para>
        /// </remarks>
        /// 
        IChromosome Clone();
        /// <summary>
        /// Crossover two chromosomes/
        /// </summary>
        /// <param name="crossover">Crossover Operation</param>
        /// <param name="mother">AnotherChromosome</param>
        /// <returns>Children array</returns>
        IChromosome[] Crossover(ICrossover crossover, IChromosome mother);

        IChromosome GenerateFromArray(Array gens);

        Array ToArray();
        String ToString();
        int Length { get; }
    }
}
