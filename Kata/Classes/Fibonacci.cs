using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Create function fib that returns n'th element of Fibonacci sequence (classic programming task).
    /// </summary>
    public class Fibonacci
    {
        public static int Fib_naive(int n) =>
            n == 0 | n == 1 ? n : Fib_naive(n - 1) + Fib_naive(n - 2);

        public static int FibSqrt(int n)
        {
            double phi = 0.5 + 0.5 * Math.Sqrt(5);
            return (int)Math.Round((Math.Pow(phi, n) - Math.Pow(-phi, 1 / n)) / Math.Sqrt(5));
        }

        public static long Fib(int n)
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
}