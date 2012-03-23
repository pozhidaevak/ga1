using System;
using System.Collections.Generic;
using System.Linq;

namespace ga1
{
    public interface IMutation<T>
    {
        IChromosome<T> Mutate(IChromosome<T> chromo);
    }
}
