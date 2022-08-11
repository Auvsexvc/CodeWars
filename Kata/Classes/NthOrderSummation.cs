using NUnit.Framework;
using System.Numerics;

namespace Kata.Classes
{
    public class NthOrderSummation
    {
        public static BigInteger S(BigInteger m, BigInteger n)
        {
            BigInteger sum = BigInteger.Zero;

            if (m == 0) return 1;

            while (m > 0)
            {
                for (int k = 0; k < (int)n; k++)
                {
                    sum += S(m - 1, k);
                    System.Console.WriteLine($"{m},{n},({k}), {sum}");
                }
                m--;
            }

            return sum;
        }
    }

    [TestFixture]
    public class NthOrderSummationTests
    {
        [TestCase(0, 1, 1)]
        [TestCase(1, 1, 1)]
        [TestCase(0, 53, 1)]
        [TestCase(1, 49, 49)]
        [TestCase(1, 101, 101)]
        [TestCase(2, 5, 15)]
        [TestCase(2, 99, 4950)]
        [TestCase(3, 7, 84)]
        [TestCase(3, 32, 5984)]
        [TestCase(4, 8, 330)]
        [TestCase(5, 17, 20349)]
        [TestCase(10, 4, 286)]
        public void SmallTests(int m, int n, int expected)
            => Act(m, n, expected);

        private static void Act(BigInteger m, BigInteger n, BigInteger expected)
        {
            var msg = $"Invalid answer for: m = {m}, n = {n}";
            var actual = NthOrderSummation.S(m, n);
            Assert.AreEqual(expected, actual, msg);
        }
    }
}