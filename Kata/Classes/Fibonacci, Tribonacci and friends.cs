using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// You have to build a Xbonacci function that takes a signature of X elements - and remember each next element is the sum of the last X elements - and returns the first n elements of the so seeded sequence
    /// </summary>
    internal class Fibonacci__Tribonacci_and_friends
    {
        public class Xbonacci
        {
            public static double[] xbonacci(double[] signature, int n)
            {
                if (n == 0)
                    return new double[] {};

                var result = new double[n];
                for (var i = 0; i < n; i++)
                    result[i] = i < signature.Length
                      ? signature[i]
                      : result.Skip(i - signature.Length).Take(signature.Length).Sum();

                return result;
            }
        }
    }
}
