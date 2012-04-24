using ga1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class CrossoverTest
    {
        [TestMethod]
        public void OnePointCrossoverTest()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 2, 1 });
            OnePointCrossover<int> cross = new OnePointCrossover<int>(2);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 2, 1 }), new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 3, 4 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void UniversalPointCrossover()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 2, 1 });
            UniversalCrossover<int> cross = new UniversalCrossover<int>(new System.Collections.BitArray(new bool[] { false, true, false, true }));
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 3, 3, 1 }), new DigitalChromosome().GenerateFromArray(new int[] { 4, 2, 2, 4 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void TwoPointCrossover()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 2, 1 });
            TwoPointCrossover<int> cross = new TwoPointCrossover<int>(1, 3, 4);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 3, 2, 4 }), new DigitalChromosome().GenerateFromArray(new int[] { 4, 2, 3, 1 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void ThreePointCrossover()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 2, 1 });
            ThreePointCrossover<int> cross = new ThreePointCrossover<int>(new int[] { 1, 2, 3 }, 4);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 3, 3, 1 }), new DigitalChromosome().GenerateFromArray(new int[] { 4, 2, 2, 4 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void OnePointOrderCrossover()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4, 5 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 5, 4, 3, 2, 1 });
            OnePointOrderCrossover<int> cross = new OnePointOrderCrossover<int>(2);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 5, 4 }), new DigitalChromosome().GenerateFromArray(new int[] { 5, 4, 3, 1, 2 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void TwoPointOrderCrossover()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 2, 4, 5, 1, 6, 3 });
            TwoPointOrderCrossover<int> cross = new TwoPointOrderCrossover<int>(2, 4);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 4, 3, 5, 6 }), new DigitalChromosome().GenerateFromArray(new int[] { 2, 4, 1, 5, 6, 3 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void OnePointPMX()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4, 5 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 5, 1, 2 });
            OnePointPMX<int> cross = new OnePointPMX<int>(3);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 4, 5, 3, 1, 2 }), new DigitalChromosome().GenerateFromArray(new int[] { 1, 3, 2, 4, 5 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void TwoPointPMX()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4, 5 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 5, 1, 2 });
            TwoPointPMX<int> cross = new TwoPointPMX<int>(1, 3);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 3, 5, 4, 2 })
                , new DigitalChromosome().GenerateFromArray(new int[] { 4, 5, 2, 1, 3 }) }; // different from ex. because, i do it for rows
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void Fibonacci()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 6, 5, 4, 3, 2, 1 });
            FibonacciCrossover<int> cross = new FibonacciCrossover<int>(6);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 5, 3, 3, 2, 6 })
                , new DigitalChromosome().GenerateFromArray(new int[] { 6, 2, 4, 4, 5, 1 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void GoldenCrossoverTest()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4, 5 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 5, 4, 3, 2, 1 });
            GoldenCrossover<int> cross = new GoldenCrossover<int>(5);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 2, 1 }), new DigitalChromosome().GenerateFromArray(new int[] { 5, 4, 3, 4, 5 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void CicleCrossoverTest()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4, 5 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 5, 4, 3, 2, 1 });
            CicleCrossover<int> cross = new CicleCrossover<int>(5);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 4, 3, 2, 5 }), new DigitalChromosome().GenerateFromArray(new int[] { 5, 2, 3, 4, 1 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void CicleCrossoverTest2()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 2, 4, 5, 1, 6, 3 });
            CicleCrossover<int> cross = new CicleCrossover<int>(6);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 1, 2, 5, 4, 6, 3 }), new DigitalChromosome().GenerateFromArray(new int[] { 2, 4, 3, 1, 5, 6 }) };
            CollectionAssert.AreEqual(res, exp);
        }

        [TestMethod]
        public void GreedyCrossoverTest()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 4, 2, 3, 1 });
            IChromosome<int> b = new DigitalChromosome().GenerateFromArray(new int[] { 1, 4, 3, 2 });
            int[,] matrix = new int[4, 4]
            {
                { 0, 2, 3, 4},
                { 1, 0, 2, 3},
                { 1, 2, 0, 5},
                { 3, 7, 6, 0}
            };
            GreedyCrossover cross = new GreedyCrossover(4, 2, matrix);
            IChromosome<int>[] res = cross.Crossover(a, b);
            IChromosome<int>[] exp = new IChromosome<int>[2] { new DigitalChromosome().GenerateFromArray(new int[] { 4, 3, 1, 2 }), new DigitalChromosome().GenerateFromArray(new int[] { 2, 1, 4, 3 }) };
            CollectionAssert.AreEqual(res, exp);
        }
    }
}