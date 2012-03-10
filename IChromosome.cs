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
        /// Create new random chromosome with same parameters (factory method).
        /// </summary>
        /// 
        /// <remarks><para>The method creates new chromosome of the same type, but randomly
        /// initialized. The method is useful as factory method for those classes, which work
        /// with chromosome's interface, but not with particular chromosome class.</para></remarks>
        /// 
        //IChromosome CreateNew();

        /// <summary>
        /// Clone the chromosome.
        /// </summary>
        /// 
        /// <remarks><para>The method clones the chromosome returning the exact copy of it.</para>
        /// </remarks>
        /// 
        //IChromosome Clone();
        /// <summary>
        /// Crossover two chromosomes/
        /// </summary>
        /// <param name="crossover">Crossover Operation</param>
        /// <param name="mother">AnotherChromosome</param>
        /// <returns>Children array</returns>
        IChromosome[] Crossover(ICrossover crossover, IChromosome mother);

        IChromosome GenerateFromArray(Array gens);

        Array ToArray();
        int Length { get; }
    }
}
