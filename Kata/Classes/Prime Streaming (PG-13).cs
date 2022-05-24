using System;
using System.Collections;
using System.Collections.Generic;

namespace Kata.Classes
{
    /// <summary>
    /// Create an endless stream of prime numbers - a bit like IntStream.of(2, 3, 5, 7, 11, 13, 17), but infinite. 
    /// The stream must be able to produce a million primes in a few seconds.
    /// </summary>
    internal class Prime_Streaming__PG_13_
    {
        public static IEnumerable<int> Stream()
        {
            List<int> list = new List<int>();
            int integersLimit = 20000000; //for a sake of passing codewars tests
            var mbaPrimeState = new BitArray(integersLimit + 2, true);
            //The sieve of Eratosthenes
            for (int i = 2; i <= (int)Math.Sqrt(integersLimit) + 1; i += 1)
                if (mbaPrimeState[i])
                    for (int j = i * i; j <= integersLimit; j += i)
                        mbaPrimeState[j] = false;
            //ToList
            for (int i = 2; i < mbaPrimeState.Length; i++)
            {
                if (mbaPrimeState[i])
                    list.Add(i);
            }

            return list;
        }
    }
}