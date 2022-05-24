using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// A Narcissistic Number is a number of length n in which the sum of its digits to the power of n is equal to the original number.
    /// If this seems confusing, refer to the example below.
    /// Write a method is_narcissistic(i) (in Haskell: isNarcissistic :: Integer -> Bool) which returns whether or not i is a Narcissistic Number.
    /// </summary>
    internal class Narcissistic_Numbers
    {
        public static bool IsNarcissistic(long n) =>
            n.ToString().Select(c => Math.Pow(c-48, n.ToString().Length)).Sum() == n;
    }
}