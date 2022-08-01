using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class CountByXTest
    {
        [Test]
        public static void CountBy1()
        {
            Assert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, CountByX.CountBy(1, 5), "Array does not match");
        }

        [Test]
        public static void CountBy2()
        {
            Assert.AreEqual(new int[] { 2, 4, 6, 8, 10 }, CountByX.CountBy(2, 5), "Array does not match");
        }
    }

    internal class CountByX
    {
        public static int[] CountBy(int x, int n) => Enumerable.Range(1, n).Select(i => i * x).ToArray();
    }
}