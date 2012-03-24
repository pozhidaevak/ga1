using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ga1;

namespace TestProject1
{
    [TestClass]
    public class MutationTest
    {
        [TestMethod]
        public void EasyMutation()
        {
            IChromosome<bool> a = new BinaryChromosome().GenerateFromArray(new bool[] { false, true, false, true });
            EasyMutation mutation = new EasyMutation(2);
            IChromosome<bool> res = mutation.Mutate(a);
            IChromosome<bool> exp = new BinaryChromosome().GenerateFromArray(new bool[] { false, true, true, true });
            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void SwapMutationTest()
        {
            IChromosome<bool> a = new BinaryChromosome().GenerateFromArray(new bool[] { false, true, false, true });
            SwapMutation<bool> mutation = new SwapMutation<bool>(0,3);
            IChromosome<bool> res = mutation.Mutate(a);
            IChromosome<bool> exp = new BinaryChromosome().GenerateFromArray(new bool[] { true, true, false, false });
            Assert.AreEqual(exp, res);
        }
        
        [TestMethod]
        public void OnePointSwapMutationTest()
        {
            IChromosome<bool> a = new BinaryChromosome().GenerateFromArray(new bool[] { false, true, false, true });
            OnePointSwapMutation<bool> mutation = new OnePointSwapMutation<bool>(1);
            IChromosome<bool> res = mutation.Mutate(a);
            IChromosome<bool> exp = new BinaryChromosome().GenerateFromArray(new bool[] { true, false, false, true });
            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void GoldenMutationTest()
        {
            IChromosome<bool> a = new BinaryChromosome().GenerateFromArray(new bool[] { false, true, false, true, false });
            GoldenMutation<bool> mutation = new GoldenMutation<bool>(5);
            IChromosome<bool> res = mutation.Mutate(a);
            IChromosome<bool> exp = new BinaryChromosome().GenerateFromArray(new bool[] { false, true, true, false, false });
            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void PointMutationTest()
        {
            IChromosome<bool> a = new BinaryChromosome().GenerateFromArray(new bool[] { false, true, false, true, false });
            PointMutation mutation = new PointMutation(1);
            IChromosome<bool> res = mutation.Mutate(a);
            IChromosome<bool> exp = new BinaryChromosome().GenerateFromArray(new bool[] { true, false, true, false, true });
            Assert.AreEqual(exp, res);
        }

        [TestMethod]
        public void FibonacciMutationTest()
        {
            IChromosome<int> a = new DigitalChromosome().GenerateFromArray(new int[] { 12, 13, 14, 15, 16, 17,18,19,20});
            FibonacciMutation<int> mutation = new FibonacciMutation<int>(9);
            IChromosome<int> res = mutation.Mutate(a);
            IChromosome<int> exp = new DigitalChromosome().GenerateFromArray(new int[] { 19,12,13,15,14,17,18,16,20 });
            Assert.AreEqual(exp, res);
        }
    }
}
