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
            IChromosome<int>[] a = new IChromosome<int>[] { new DigitalChromosome().GenerateFromArray(new int[] { 9, 9, 9 }),
            new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }) };
            RouletteSelection<int> selection = new RouletteSelection<int>();
            IChromosome<int>[] res = selection.Select(a, x => x.ToArray().Sum(), 1);
        }

        [TestMethod]
        public void Elite()
        {
            IChromosome<int>[] a = new IChromosome<int>[] { new DigitalChromosome().GenerateFromArray(new int[] { 9, 9, 9 }),
            new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }), new DigitalChromosome().GenerateFromArray(new int[] { 3, 3, 3 }),
            new DigitalChromosome().GenerateFromArray(new int[] { 2, 2, 2 }), new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }), new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }),
            new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }) };
            EliteSelection<int> selection = new EliteSelection<int>(2);
            IChromosome<int>[] res = selection.Select(a, x => x.ToArray().Sum(), 6);
            CollectionAssert.AreEqual(new IChromosome<int>[] { new DigitalChromosome().GenerateFromArray(new int[] { 9, 9, 9 }),
            new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }) }, res.Take(2).ToArray());
        }

        [TestMethod]
        public void Tornament()
        {
            IChromosome<int>[] a = new IChromosome<int>[] { new DigitalChromosome().GenerateFromArray(new int[] { 9, 9, 9 }),
            new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }), new DigitalChromosome().GenerateFromArray(new int[] { 3, 3, 3 }),
            new DigitalChromosome().GenerateFromArray(new int[] { 2, 2, 2 }), new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }), new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }),
            new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }) };
            TornamentSelection<int> selection = new TornamentSelection<int>(3);
            IChromosome<int>[] res = selection.Select(a, x => x.ToArray().Sum(), 3);
            CollectionAssert.DoesNotContain(res, new DigitalChromosome().GenerateFromArray(new int[] { 2, 2, 2 }));
            CollectionAssert.DoesNotContain(res, new DigitalChromosome().GenerateFromArray(new int[] { 3, 3, 3 }));
            CollectionAssert.Contains(res, new DigitalChromosome().GenerateFromArray(new int[] { 7, 7, 7 }));
        }
    }
}