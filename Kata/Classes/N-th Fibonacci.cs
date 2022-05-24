using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// I love Fibonacci numbers in general, but I must admit I love some more than others.
    /// I would like for you to write me a function that when given a number (n) returns the n-th number in the Fibonacci Sequence.
    /// For example:
    ///  NthFib(4) == 2
    ///  Because 2 is the 4th number in the Fibonacci Sequence.
    ///  For reference, the first two numbers in the Fibonacci sequence are 0 and 1, and each subsequent number is the sum of the previous two.
    /// </summary>
    internal class N_th_Fibonacci
    {
        public int NthFib(int n) =>
            FibonacciSequence(n - 1);

        private int FibonacciSequence(int n) =>
            n == 0 | n == 1 ? n : FibonacciSequence(n - 1) + FibonacciSequence(n - 2);

        public static int FibSqrt(int n)
        {
            double phi = 0.5 + 0.5 * Math.Sqrt(5);
            return (int)Math.Round((Math.Pow(phi, n) - Math.Pow(-phi, 1 / n)) / Math.Sqrt(5));
        }

    }
}
