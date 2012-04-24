namespace ga1
{
    public interface ISelection<T>
    {
        IChromosome<T>[] Select(IChromosome<T>[] population, Population<T>.Fitness fitness, int outLength);
    }
}