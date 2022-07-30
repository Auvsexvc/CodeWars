using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class FactorialTailTest
    {
        [Test]
        public void Can_Be_Solved_With_Basic_Computations()
        {
            Assert.AreEqual(3, FactorialTail.Zeroes(2, 5));
            Assert.AreEqual(2, FactorialTail.Zeroes(10, 10));
            Assert.AreEqual(3, FactorialTail.Zeroes(16, 16));
            Assert.AreEqual(10, FactorialTail.Zeroes(12, 26));
            Assert.AreEqual(524287, FactorialTail.Zeroes(2, 524288));
            Assert.AreEqual(444, FactorialTail.Zeroes(128, 3114));
            Assert.AreEqual(5, FactorialTail.Zeroes(17, 100));
        }
    }

    /// <summary>
    /// How many zeroes are at the end of the factorial of 10? 10! = 3628800, i.e. there are 2
    /// zeroes. 16! (or 0x10!) in hexadecimal would be 0x130777758000, which has 3 zeroes.
    /// Unfortunately, machine integer numbers has not enough precision for larger values. Floating
    /// point numbers drop the tail we need. We can fall back to arbitrary-precision ones -
    /// built-ins or from a library, but calculating the full product isn't an efficient way to find
    /// just the tail of a factorial. Calculating 100'000! in compiled language takes around 10
    /// seconds. 1'000'000! would be around 10 minutes, even using efficient Karatsuba algorithm
    /// Your task is to write a function, which will find the number of zeroes at the end of
    /// (number) factorial in arbitrary radix = base for larger numbers.
    /// - base is an integer from 2 to 256
    /// - number is an integer from 1 to 1'000'000 Note Second argument: number is always declared,
    /// passed and displayed as a regular decimal number. If you see a test described as 42! in base
    /// 20 it's 4210 not 4220 = 8210.
    /// </summary>
    public static class FactorialTail
    {
        public static int Zeroes(int radix, int number) =>
            GetPrimeFactors(radix).Min(p => LegendreFormula(number, p.Factor) / p.Occurence);

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
}