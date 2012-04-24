using System;

namespace ga1
{
    public interface IChromosome<T>
    {
        /// <summary>
        /// Generate random chromosome
        /// </summary>
        /// <param name="length">length of chromosome</param>
        IChromosome<T> Generate(int length);

        /// <summary>
        /// Clone the chromosome.
        /// </summary>
        /// <remarks>    <para>The method clones the chromosome returning the exact copy of it.</para>
        /// </remarks>
        IChromosome<T> Clone();

        /// <summary>
        /// Crossover two chromosomes
        /// </summary>
        /// <param name="crossover">Crossover Operation</param>
        /// <param name="mother">AnotherChromosome</param>
        /// <returns>Children array</returns>
        IChromosome<T>[] Crossover(ICrossover<T> crossover, IChromosome<T> mother);

        /// <summary>
        /// Generates chromosome from Array
        /// </summary>
        /// <remarks>For different chromosomes types use different Array types. See realizations...</remarks>
        /// <param name="gens">Array of "gens" to create chromosome</param>
        /// <returns>new chrmomosome</returns>
        IChromosome<T> GenerateFromArray(Array gens);

        /// <summary>
        /// Use it if you need to see array of "gens"
        /// </summary>
        /// <returns>array of gens</returns>
        T[] ToArray();

        /// <summary>
        /// String representation of chromosome
        /// </summary>
        /// <remarks>When you realize this methode use override modificer</remarks>
        /// <returns>String representation of chromosome</returns>
        String ToString();

        /// <summary>
        /// Length -- number of gens
        /// </summary>
        int Length { get; }
    }
}