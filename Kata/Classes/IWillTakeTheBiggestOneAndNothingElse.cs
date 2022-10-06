using NUnit.Framework;
using System;

namespace Kata.Classes
{
    [TestFixture]
    public class FixedTests
    {
        [Test]
        public void ExampleTestCases()
        {
            Assert.AreEqual(8, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(6), "Incorrect Result");
            Assert.AreEqual(24, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(10), "Incorrect Result");
            Assert.AreEqual(168, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(26), "Incorrect Result");
            Assert.AreEqual(255, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(32), "Incorrect Result");
            Assert.AreEqual(323, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(36), "Incorrect Result");
            Assert.AreEqual(380, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(39), "Incorrect Result");
        }

        [Test]
        public void PrimeIntegers()
        {
            Assert.AreEqual(6, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(5), "Incorrect Result");
            Assert.AreEqual(12, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(7), "Incorrect Result");
            Assert.AreEqual(30, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(11), "Incorrect Result");
            Assert.AreEqual(42, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(13), "Incorrect Result");
            Assert.AreEqual(72, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(17), "Incorrect Result");
        }

        [Test]
        public void StartingIntegerLessThan5()
        {
            Assert.AreEqual(-1, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(1), "Incorrect Result");
            Assert.AreEqual(-1, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(2), "Incorrect Result");
            Assert.AreEqual(-1, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(3), "Incorrect Result");
            Assert.AreEqual(-1, IWillTakeTheBiggestOneAndNothingElse.MaxIntChain(4), "Incorrect Result");
        }
    }

    internal class IWillTakeTheBiggestOneAndNothingElse
    {
        public static long MaxIntChain(long n)
        {
            return n < 5
                ? -1
                : n % 2 == 0
                    ? ((n * n) / 4) -1
                    : (n * n) / 4;
        }
    }
}