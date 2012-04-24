namespace ga1
{
    public interface ICrossover<T>
    {
        /// <summary>
        /// Crossover two chromosomes
        /// </summary>
        /// <param name="father">"father" chromosome</param>
        /// <param name="mother">"mother" chromosome</param>
        /// <returns>children array</returns>
        IChromosome<T>[] Crossover(IChromosome<T> father, IChromosome<T> mother);
    }
}