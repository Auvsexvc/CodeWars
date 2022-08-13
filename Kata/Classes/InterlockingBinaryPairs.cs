using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class InterlockingBinaryPairsTest
    {
        [Test]
        public void SampleTests()
        {
            Object[][] tests = {
                new Object[] { true,  9UL, 4UL },
                new Object[] { false, 5UL, 6UL },
                new Object[] { true,  2UL, 5UL },
                new Object[] { false, 7UL, 1UL },
                new Object[] { true,  0UL, 8UL }
            };
            foreach (Object[] test in tests)
            {
                bool expected = (bool)test[0];
                ulong a = (ulong)test[1];
                ulong b = (ulong)test[2];
                bool submitted = InterlockingBinaryPairs.Interlockable(a, b);
                string message = "a = " + a + "\n  b = " + b;
                Assert.AreEqual(expected, submitted, message);
            }
        }
    }

    internal class InterlockingBinaryPairs
    {
        public static bool Interlockable(ulong a, ulong b)
        {
            return (a & b) == 0;
        }

        public static bool InterlockableA(ulong a, ulong b)
        {
            var x = Convert.ToString((long)a, 2).Reverse();

            var y = Convert.ToString((long)b, 2).Reverse();

            return !Enumerable
                .Range(0, x.Count())
                .Where(i => x.ElementAt(i) == '1')
                .Intersect(Enumerable
                    .Range(0, y.Count())
                    .Where(i => y.ElementAt(i) == '1'))
                .Any();
        }
    }
}