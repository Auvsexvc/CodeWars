using NUnit.Framework;
using System;
using System.Numerics;

namespace Kata.Classes
{
    [TestFixture]
    public class SpiralTest
    {
        [Test]
        public void Test05()
        {
            BigInteger input = 5;
            BigInteger expected = 17;

            BigInteger actual = Spiral.Sum(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test10()
        {
            BigInteger input = 10;
            BigInteger expected = 59;

            BigInteger actual = Spiral.Sum(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test1000()
        {
            BigInteger input = 1000;
            BigInteger expected = 500999;

            BigInteger actual = Spiral.Sum(input);

            Assert.AreEqual(expected, actual);
        }
    }

    internal class Spiral
    {
        public static BigInteger Sum(BigInteger size) => (2 * size) + (BigInteger.Pow(size - 1, 2) / 2) - 1;
    }
}