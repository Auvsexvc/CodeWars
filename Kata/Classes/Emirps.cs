using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class EmirpsTests
    {
        public static void tests(long[] list1, long[][] results)
        {
            for (int i = 0; i < list1.Length; i++)
                testing(EmirpsTests.Array2String(Emirps.FindEmirp(list1[i])), EmirpsTests.Array2String(results[i]));
            return;
        }

        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests FindEmirp");
            long[] l = new long[] { 50, 100, 200, 500, 750, 1000 };
            long[][] r = new long[][] { new long[] {4, 37, 98}, new long[] {8, 97, 418}, new long[] {15, 199, 1489}, new long[] {20, 389, 3232},
            new long[] {25, 743, 6857}, new long[] {36, 991, 16788} };
            tests(l, r);
        }

        private static string Array2String(long[] list)
        {
            return "[" + string.Join(", ", list) + "]";
        }

        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }

    internal class Emirps
    {
        public static long[] FindEmirp(long n)
        {
            var emirps = GeneratePrimesSieveOfEratosthenes(n)
                .TakeWhile(x => x <= n)
                .Select(x => x.ToString())
                .Where(x => IsPrime(long.Parse(string.Concat(x.Reverse())))
                    && x.Substring(0, (int)Math.Floor(x.Length / 2.0)) != string.Concat(x.Substring((int)Math.Ceiling(x.Length / 2.0)).Reverse()))
                .Select(long.Parse);

            return new long[] { emirps.Count(), emirps.Max(), emirps.Sum() };
        }

        private static bool IsPrime(long n)
        {
            if (n <= 1)
            {
                return false;
            }
            if (n == 2 || n == 3)
            {
                return true;
            }
            if (n % 2 == 0 || n % 3 == 0)
            {
                return false;
            }
            for (int i = 5; i <= Math.Sqrt(n); i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static List<int> GeneratePrimesSieveOfEratosthenes(long n)
        {
            int limit = ApproximateNthPrime(n);
            BitArray bits = SieveOfEratosthenes(limit);
            List<int> primes = new();
            for (int i = 0, found = 0; i < limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(i);
                    found++;
                }
            }
            return primes;
        }

        private static int ApproximateNthPrime(long nn)
        {
            double n = (double)nn;
            double p;
            if (nn >= 7022)
            {
                p = (n * Math.Log(n)) + (n * (Math.Log(Math.Log(n)) - 0.9385));
            }
            else if (nn >= 6)
            {
                p = (n * Math.Log(n)) + (n * Math.Log(Math.Log(n)));
            }
            else if (nn > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11 }[nn - 1];
            }
            else
            {
                p = 0;
            }
            return (int)p;
        }

        private static BitArray SieveOfEratosthenes(int limit)
        {
            BitArray bits = new(limit + 1, true);
            bits[0] = false;
            bits[1] = false;
            for (int i = 0; i * i <= limit; i++)
            {
                if (bits[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }
            return bits;
        }
    }
}