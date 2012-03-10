using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ga1
{
    interface ICrossover
    {
        /// <summary>
        /// Crossover two chromosomes
        /// </summary>
        /// <param name="father">"father" chromosome</param>
        /// <param name="mother">"mother" chromosome</param>
        /// <returns>children array</returns>
        IChromosome[] Crossover(IChromosome father, IChromosome mother);
    }
}
