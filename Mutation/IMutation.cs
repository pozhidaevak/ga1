namespace ga1
{
    public interface IMutation<T>
    {
        IChromosome<T> Mutate(IChromosome<T> chromo);
    }
}