using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// Your task is to efficiently calculate the nth element in the Fibonacci sequence and then count the occurrence of each digit in the number. Return a list of integer pairs sorted in descending order.
    /// </summary>
    internal class Calculate_Fibonacci_return_count_of_digit_occurrences
    {
        public static List<Tuple<int, int>> FibDigits(int n)
        {
            string fibStr = Fibonacci(n).ToString();
            return fibStr
                  .Distinct()
                  .Select(item => new Tuple<int, int>(fibStr.Where(c => c == item).Count(), (int)char.GetNumericValue(item)))
                  .OrderByDescending(t => t.Item1)
                  .ThenByDescending(t => t.Item2)
                  .ToList();
        }

        public static BigInteger Fibonacci(int x)
        {
            var previousValue = new BigInteger(-1);
            var currentResult = new BigInteger(1);

            for (var i = 0; i <= x; ++i)
            {
                var sum = currentResult + previousValue;
                previousValue = currentResult;
                currentResult = sum;
            }

            return currentResult;
        }
    }
}