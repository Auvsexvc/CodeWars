using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// As the name may already reveal, it works basically like a Fibonacci, but summing the last 3 (instead of 2) numbers of the sequence to generate the next. And, worse part of it, regrettably I won't get to hear non-native Italian speakers trying to pronounce it :(
    /// So, if we are to start our Tribonacci sequence with[1, 1, 1] as a starting input(AKA signature), we have this sequence:
    /// [1, 1 ,1, 3, 5, 9, 17, 31, ...]
    /// But what if we started with[0, 0, 1] as a signature? As starting with[0, 1] instead of[1, 1] basically shifts the common Fibonacci sequence by once place, you may be tempted to think that we would get the same sequence shifted by 2 places, but that is not the case and we would get:
    /// [0, 0, 1, 1, 2, 4, 7, 13, 24, ...]
    /// Well, you may have guessed it by now, but to be clear: you need to create a fibonacci function that given a signature array/list, returns the first n elements - signature included of the so seeded sequence.
    /// Signature will always contain 3 numbers; n will always be a non-negative number; if n == 0, then return an empty array (except in C return NULL) and be ready for anything else which is not clearly specified;)
    /// </summary>
    internal class Tribonacci_Sequence
    {
        public double[] TribonacciLinq(double[] signature, int n)
        {
            if (n == 0)
                return new double[] { 0 };

            var result = new double[n];
            for (var i = 0; i < n; i++)
                result[i] = i < 3
                  ? signature[i]
                  : result.Skip(i - 3).Take(3).Sum();

            return result;
        }

        private static List<double> lista = new List<double>();

        public static double[] Tribonacci(double[] signature, int n)
        {
            if (n == 0) return Array.Empty<double>();

            if (!lista.Any())
            {
                if (n <= signature.Length)
                {
                    return signature.Take(n).ToArray();
                }
                lista.AddRange(signature);
            }
            while (n - signature.Length > 0)
            {
                lista.Add(signature.TakeLast(3).Sum());

                return Tribonacci(lista.TakeLast(3).ToArray(), n - 1);
            }
            double[] sCopy = lista.ToArray();

            lista.Clear();
            return sCopy;
        }
    }
}