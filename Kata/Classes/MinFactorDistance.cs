using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    internal class MinFactorDistance
    {
        public static int MinDistance(int n)
        {
            var factors = Enumerable
                .Range(1, (int)Math.Sqrt(n))
                .Where(i => n % i == 0)
                .SelectMany(i => i != (n / i) ? new int[] { i, n / i } : new int[] { i })
                .OrderBy(i => i);

            return factors.Zip(factors.Skip(1), (p, f) => (p, f)).Min(i => i.f - i.p);
        }

        [TestFixture]
        public class MinFactorDistanceTest
        {
            [Test, Description("Sample Tests")]
            public void SampleTest()
            {
                Assert.AreEqual(1, MinDistance(8));
                Assert.AreEqual(4, MinDistance(25));
                Assert.AreEqual(2, MinDistance(13013));
                Assert.AreEqual(200, MinDistance(557009));
                Assert.AreEqual(198, MinDistance(218683));
            }
        }
    }
}