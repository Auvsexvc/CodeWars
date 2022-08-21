using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    public class EnglishBeggarsTest
    {
        [Test]
        public void FixedTest()
        {
            // Basic tests
            int[] test = { 1, 2, 3, 4, 5 };
            int[] a1 = { 15 }, a2 = { 9, 6 }, a3 = { 5, 7, 3 }, a4 = { 1, 2, 3, 4, 5, 0 }, a5 = { };
            Assert.AreEqual(a2, EnglishBeggars.Beggars(test, 2));
            Assert.AreEqual(a1, EnglishBeggars.Beggars(test, 1));
            Assert.AreEqual(a3, EnglishBeggars.Beggars(test, 3));
            Assert.AreEqual(a4, EnglishBeggars.Beggars(test, 6));
            Assert.AreEqual(a5, EnglishBeggars.Beggars(test, 0));
        }
    }

    internal class EnglishBeggars
    {
        public static int[] Beggars(int[] values, int n)
        {
            return Enumerable
                .Range(0, n)
                .GroupBy(r => (Beggar: r + 1, Loot: values.Where((_, i) => (i + (n - r)) % n == 0).Sum()))
                .Select(x => x.Key)
                .Select(x => x.Loot)
                .ToArray();
        }

        public static int[] Beggars2(int[] values, int n)
        {
            return Enumerable.Range(0, n).Select(x => values.Where((_, i) => i % n == x).Sum()).ToArray();
        }
    }
}