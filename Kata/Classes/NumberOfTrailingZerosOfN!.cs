using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    public class NumberOfTrailingZerosOfN
    {
        public static int TrailingZeros(int n) =>
            GetPrimeFactors(10).Min(p => LegendreFormula(n, p.Factor) / p.Occurence);

        private static List<(int Factor, int Occurence)> GetPrimeFactors(int radix)
        {
            List<(int x, int y)> primeFactors = new();

            for (int factor = 2; factor <= radix; factor++)
            {
                if (radix % factor == 0 && IsPrime(factor))
                {
                    int occurence = 0;
                    while (radix % factor == 0)
                    {
                        radix /= factor;
                        occurence++;
                    }
                    primeFactors.Add((factor, occurence));
                }
            }

            return primeFactors;
        }

        private static int LegendreFormula(int n, int p)
        {
            int power = 0;
            while (n > 0)
            {
                n /= p;
                power += n;
            }
            return power;
        }

        private static bool IsPrime(int n) =>
            n > 1 && Enumerable.Range(1, n).Where(x => n % x == 0).SequenceEqual(new[] { 1, n });
    }

    [TestFixture]
    public class TrailingZeros
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(1, NumberOfTrailingZerosOfN.TrailingZeros(5));
            Assert.AreEqual(6, NumberOfTrailingZerosOfN.TrailingZeros(25));
            Assert.AreEqual(131, NumberOfTrailingZerosOfN.TrailingZeros(531));
        }
    }
}