using System;
using System.Collections;
using System.Collections.Generic;

namespace Kata.Classes
{
    internal static class PrimesGenerator
    {
        public static List<int> GeneratePrimesNaive(int n)
        {
            List<int> primes = new()
            {
                2
            };
            int nextPrime = 3;
            while (primes.Count < n)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }

        private static int ApproximateNthPrime(int nn)
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

        public static List<int> GeneratePrimesSieveOfEratosthenes(int n)
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

        private static BitArray SieveOfSundaram(int limit)
        {
            limit /= 2;
            BitArray bits = new(limit + 1, true);
            for (int i = 1; (3 * i) + 1 < limit; i++)
            {
                for (int j = 1; i + j + (2 * i * j) <= limit; j++)
                {
                    bits[i + j + (2 * i * j)] = false;
                }
            }
            return bits;
        }

        public static List<int> GeneratePrimesSieveOfSundaram(int n)
        {
            int limit = ApproximateNthPrime(n);
            BitArray bits = SieveOfSundaram(limit);
            List<int> primes = new()
            {
                2
            };
            for (int i = 1, found = 1; (2 * i) + 1 <= limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add((2 * i) + 1);
                    found++;
                }
            }
            return primes;
        }
    }
}