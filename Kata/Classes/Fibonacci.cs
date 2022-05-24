using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Create function fib that returns n'th element of Fibonacci sequence (classic programming task).
    /// </summary>
    public class Fibonacci
    {
        public static int Fib(int n) =>
            n == 0 | n == 1 ? n : Fib(n - 1) + Fib(n - 2);

        public static int FibSqrt(int n)
        {
            double phi = 0.5 + 0.5 * Math.Sqrt(5);
            return (int)Math.Round((Math.Pow(phi, n) - Math.Pow(-phi, 1 / n)) / Math.Sqrt(5));
        }
    }
}