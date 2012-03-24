using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ga1
{
    [TestClass]
    public class SelectionTest
    {
      
        [TestMethod]
        public void Roulette()
        {
            IChromosome<int>[] a = new IChromosome<int>[] {new DigitalChromosome().GenerateFromArray(new int[] {9,9,9}),
                new DigitalChromosome().GenerateFromArray(new int[] {7,7,7}) };
            RouletteSelection<int> selection = new RouletteSelection<int>(1);
            IChromosome<int>[] res = selection.Select(a, x => x.ToArray().Sum());

        }
    }
}
