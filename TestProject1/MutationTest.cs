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
    }
}
