using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    public class SortTheOdd
    {
        public static int[] SortArray(int[] array)
        {
            Queue<int> queue = new(array.Where(x => x % 2 != 0).OrderBy(x => x));

            return array.Select(i => i % 2 == 0 ? i : queue.Dequeue()).ToArray();
        }
    }

    [TestFixture]
    public class SortTheOddTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new int[] { 1, 3, 2, 8, 5, 4 }, SortTheOdd.SortArray(new int[] { 5, 3, 2, 8, 1, 4 }));
            Assert.AreEqual(new int[] { 1, 3, 5, 8, 0 }, SortTheOdd.SortArray(new int[] { 5, 3, 1, 8, 0 }));
            Assert.AreEqual(new int[] { }, SortTheOdd.SortArray(new int[] { }));
        }
    }
}