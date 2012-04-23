using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    public interface ISelection<T>
    {
        IChromosome<T>[] Select(IChromosome<T>[] population, Population<T>.Fitness fitness, int outLength);
    }
}
