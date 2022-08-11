using NUnit.Framework;
using System.Numerics;

namespace Kata.Classes
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(5, ExpectedResult = true)]
        [TestCase(9, ExpectedResult = false)]
        [TestCase(6, ExpectedResult = false)]
        public static bool FixedTest(int p)
        {
            return WilsonPrimes.AmIWilson(p);
        }
    }

    internal class WilsonPrimes
    {
        public static bool AmIWilson(int p) => (FactorialFn(p - 1) + 1) % (p * p) == 0;

        private static BigInteger FactorialFn(int n) => (n == 0) ? 1 : n * FactorialFn(n - 1);
    }
}