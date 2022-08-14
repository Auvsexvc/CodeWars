using NUnit.Framework;
using System;

namespace Kata.Classes
{
    [TestFixture]
    public static class SumDigNthTests
    {
        [Test]
        public static void Test1()
        {
            Console.WriteLine("Basic Tests SumDigNthTerm");
            Testing(ReachMeAndSumMyDigits.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 6), 10);
            Testing(ReachMeAndSumMyDigits.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 15), 10);
            Testing(ReachMeAndSumMyDigits.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 50), 9);
            Testing(ReachMeAndSumMyDigits.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 78), 10);
            Testing(ReachMeAndSumMyDigits.SumDigNthTerm(10, new long[] { 2, 1, 3 }, 157), 7);
        }

        private static void Testing(long actual, long expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }

    public class ReachMeAndSumMyDigits
    {
        public static long SumDigNthTerm(long initval, long[] patternl, int nthterm)
        {
            for (int idx = 0; idx < nthterm - 1; idx++)
                initval += patternl[idx % patternl.Length];

            return SumDigitsOfNumber(initval);
        }

        private static long SumDigitsOfNumber(long n)
        {
            long sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }
    }
}