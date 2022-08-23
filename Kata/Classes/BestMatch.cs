using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class BestMatchKataTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(1, BestMatchKata.BestMatch(new int[] { 6, 4 }, new int[] { 1, 2 }));

            Assert.AreEqual(0, BestMatchKata.BestMatch(new int[] { 1 }, new int[] { 0 }));

            Assert.AreEqual(4, BestMatchKata.BestMatch(new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4 }));

            Assert.AreEqual(2, BestMatchKata.BestMatch(new int[] { 3, 4, 3 }, new int[] { 1, 1, 2 }));

            Assert.AreEqual(1, BestMatchKata.BestMatch(new int[] { 4, 3, 4 }, new int[] { 1, 1, 1 }));
        }
    }

    internal static class BestMatchKata
    {
        public static int BestMatch(int[] goals1, int[] goals2)
        {
            var diff = goals1
                .Zip(goals2)
                .Select((x, i) => (i, x))
                .GroupBy(z => (Index: z.i, Delta: Math.Abs(z.x.First - z.x.Second), Total: Math.Abs(z.x.First + z.x.Second)))
                .OrderBy(g => g.Key.Delta)
                .ThenByDescending(g => g.Key.Total)
                .ThenBy(g => g.Key.Index)
                .FirstOrDefault().Key.Index;

            return diff;
        }
    }
}