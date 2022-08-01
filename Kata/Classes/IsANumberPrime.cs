using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    public static class IsANumberPrime
    {
        public static bool IsPrime(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            if (n == 2 || n == 3)
            {
                return true;
            }
            if (n % 2 == 0 || n % 3 == 0)
            {
                return false;
            }
            for (int i = 5; i <= Math.Sqrt(n); i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPrimeLq(int n)
        {
            return n > 1 && Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0);
        }

        public static bool IsPrimeSh(int n)
        {
            if (n <= 2 || n % 2 == 0) return n == 2;
            for (int i = 3; i <= Math.Sqrt(n); i += 2) if (n % i == 0) return false;
            return true;
        }
    }

    [TestFixture]
    public class IsANumberPrimeTest
    {
        private static IEnumerable<TestCaseData> sampleTestCases
        {
            get
            {
                yield return new TestCaseData(0).Returns(false);
                yield return new TestCaseData(1).Returns(false);
                yield return new TestCaseData(2).Returns(true);
            }
        }

        [Test, TestCaseSource("sampleTestCases")]
        public bool SampleTest(int n) => IsANumberPrime.IsPrime(n);
    }
}