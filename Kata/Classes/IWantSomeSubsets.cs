using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Kata.Classes
{
    internal class IWantSomeSubsets
    {
        public static class Kata
        {
            public static BigInteger F(int n)
            {
                return (BigInteger)(Fib(n + 2) - 1);
            }

            private static long Fib(int n)
            {
                Dictionary<int, long> cache = new Dictionary<int, long>();
                cache[0] = 1;
                cache[1] = 1;

                while (cache.Count < n)
                {
                    cache[cache.Count] = cache[cache.Count - 1] + cache[cache.Count - 2];
                }
                return cache[n - 1];
            }
        }

        [TestFixture]
        public class SolutionTest
        {
            [TestCase(48, 12586269024)]
            [TestCase(74, 3416454622906706)]
            [TestCase(5, 12)]
            [TestCase(3, 4)]
            [TestCase(2, 2)]
            [TestCase(20, 17710)]
            [Test(Description = "Basic Tests")]
            public void BasicTests(int n, long expected) => Act(expected, n);

            private static void Act(BigInteger expected, int n) => Assert.AreEqual(expected, Kata.F(n), $"n = {n}");
        }
    }
}