using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class NumbersWithTheHighestAmountOfDivisorsTest
    {
        [Test(Description = "Sample Tests")]
        public void FixedTests()
        {
            Act((21, 2, (9, new int[] { 36 })), new int[] { 66, 36, 49, 40, 73, 12, 77, 78, 76, 8, 50, 20, 85, 22, 24, 68, 26, 59, 92, 93, 30 });
            Act((26, 7, (12, new int[] { 108, 150, 444, 486 })), new int[] { 267, 273, 271, 145, 275, 150, 487, 169, 428, 50, 314, 444, 445, 67, 458, 211, 58, 95, 357, 486, 359, 491, 108, 493, 247, 379 });
        }

        private static string Print(IEnumerable<int> row) => $"[{string.Join(",", row)}]";

        private static void Act((int, int, (int, int[])) expected, int[] numbers) => Assert.AreEqual(
          expected,
          NumbersWithTheHighestAmountOfDivisors.ProcArrInt(numbers),
          $"\n  numbers = {Print(numbers)}\n");
    }

    internal class NumbersWithTheHighestAmountOfDivisors
    {
        public static (int, int, (int, int[])) ProcArrInt(int[] numbers)
        {
            var divisors = numbers.GroupBy(x => GetDivisors(x));
            var maxCountOfDivisors = divisors.Max(g => g.Key.Length);
            var numbersWithMaxCountOfDivisors = divisors
                .Where(g => g.Key.Length == maxCountOfDivisors)
                .SelectMany(x => x)
                .OrderBy(x => x)
                .ToArray();

            return (numbers.Length, numbers.Count(IsPrime), (maxCountOfDivisors, numbersWithMaxCountOfDivisors));
        }

        private static bool IsPrime(int n)
        {
            return n > 1 && Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0);
        }

        private static int[] GetDivisors(int n)
        {
            if (n <= 0)
            {
                return null;
            }
            List<int> divisors = new List<int>();
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    if (i != n / i)
                    {
                        divisors.Add(n / i);
                    }
                }
            }
            divisors.Sort();
            return divisors.ToArray();
        }
    }
}