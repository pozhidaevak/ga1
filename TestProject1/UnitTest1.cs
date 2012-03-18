using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ga1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OnePointCrossoverTest()
        {
           IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4 });
           IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] {4,3,2,1 });
           OnePointCrossover<int> cross = new OnePointCrossover<int>(2);
           IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 2, 1 }), new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 3, 4 })};
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void UniversalPointCrossover()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 2, 1 });
            UniversalCrossover<int> cross = new UniversalCrossover<int>(new System.Collections.BitArray(new bool[]{false,true,false,true}));
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 3, 3, 1 }), new DigitalChromosome().GenerateFromArray(new int[] { 4, 2, 2, 4 })};
            CollectionAssert.AreEqual(res, exp);
        }
    }
}
