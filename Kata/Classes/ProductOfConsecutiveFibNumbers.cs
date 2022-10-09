using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    internal class ProductOfConsecutiveFibNumbers
    {
        public class ProdFib
        {

            public static ulong[] productFib2(ulong prod)
            {

                ulong prev = 0;
                ulong curr = 1;
                ulong multiplied = prev * curr;

                while (multiplied < prod)
                {
                    ulong temp = curr;
                    curr += prev;
                    prev = temp;
                    multiplied = prev * curr;
                }

                return new ulong[] { prev, curr, multiplied == prod ? 1UL : 0 };

            }
            public static ulong[] productFib(ulong prod)
            {
                ulong sqrt = (ulong)Math.Sqrt(prod);
                ulong v1 = 0;
                ulong v2 = 0;
                ulong v = sqrt;
                ulong nf = 0;

                while (v > 1UL)
                {
                    if (isFibonacci(v))
                    {
                        v1 = v;
                        v2 = prod / v;

                        if (isFibonacci(v1 + v2) && v1 * v2 == prod)
                            return new ulong[] { v1, v2, 1 };


                        nf = nextFibonacci(v1);

                        if (v1 * nf > prod)
                            return new ulong[] { v1, nf, 0 };

                        v1 = nf;
                        nf = nextFibonacci(nf);

                        if (v1 * nf > prod)
                            return new ulong[] { v1, nf, 0 };

                        v = previousFibonacci(v);
                    }
                    else
                    {
                        v--;
                    }
                }

                return new ulong[] { v, nf, 0 };
            }

            private static ulong nextFibonacci(ulong n)
            {
                double a = n * (1 + Math.Sqrt(5)) / 2.0;
                return (ulong)Math.Round(a);
            }

            private static ulong previousFibonacci(ulong n)
            {
                double a = n / ((1 + Math.Sqrt(5)) / 2.0);
                return (ulong)Math.Round(a);
            }

            private static bool isPerfectSquare(ulong x)
            {
                ulong s = (ulong)Math.Sqrt(x);
                return s * s == x;
            }

            private static bool isFibonacci(ulong n)
            {
                return isPerfectSquare(5UL * n * n + 4UL) || isPerfectSquare(5UL * n * n - 4UL);
            }

            private static Dictionary<int, ulong> FibNumbersUpToValue(ulong maxValue)
            {
                Dictionary<int, ulong> cache = new Dictionary<int, ulong>();
                cache[0] = 1;
                cache[1] = 1;
                int n = 1;

                while (cache.Last().Value <= maxValue)
                {
                    n++;
                    cache[cache.Count] = cache[cache.Count - 1] + cache[cache.Count - 2];
                }

                return cache;
            }
        }

        [TestFixture]
        public class ProdFibTests
        {
            [Test]
            public void Test1()
            {
                ulong[] r = new ulong[] { 55, 89, 1 };
                Assert.AreEqual(new ulong[] { 34, 55, 0 }, ProdFib.productFib(800));
                Assert.AreEqual(r, ProdFib.productFib(4895));

            }
        }
    }
}