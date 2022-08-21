using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    public class NSmallestElementsInOriginalOrder
    {
        public static int[] FirstNSmallestBlune(int[] arr, int n)
        {
            var smallestNumbers = arr.OrderBy(x => x).Take(n).ToList();
            return arr.Where(x => smallestNumbers.Remove(x)).ToArray();
        }

        public static int[] FirstNSmallest(int[] arr, int n)
        {
            return FirstNSmallestHelper(arr, n).ToArray();
        }

        private static IEnumerable<int> FirstNSmallestHelper(int[] arr, int n)
        {
            var v = arr.OrderBy(x => x).Take(n).ToList();

            foreach (var e in arr)
            {
                if (v.Contains(e))
                {
                    v.Remove(e);
                    yield return e;
                }
            }
        }
    }

    internal class NSmallestElementsInOriginalOrderTest
    {
        [Test]
        public void FixedTest()
        {
            Assert.AreEqual(new[] { 1, 2, 3 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { -10, 1, -2, -7, -10, -9, 9, 9, -5, -5, -5, -3, 8, 4, 2, -1, 2, -4, -1, -4, 10, 0, 7, 3, 2, -1, 6, 5, 9, 6, 3, 3, 1, 1, -1 }, 23));
            Assert.AreEqual(new[] { 1, 2, 3 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 1, 2, 3, 4, 5 }, 3));
            Assert.AreEqual(new[] { 3, 2, 1 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 5, 4, 3, 2, 1 }, 3));
            Assert.AreEqual(new[] { 1, 2, 1 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 1, 2, 3, 1, 2 }, 3));
            Assert.AreEqual(new[] { 1, -4, 0 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 1, 2, 3, -4, 0 }, 3));
            Assert.AreEqual(new int[0], NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 1, 2, 3, 4, 5 }, 0));
            Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 1, 2, 3, 4, 5 }, 5));
            Assert.AreEqual(new[] { 1, 2, 3, 2 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 1, 2, 3, 4, 2 }, 4));
            Assert.AreEqual(new[] { 2, 1 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 2, 1, 2, 3, 4, 2 }, 2));
            Assert.AreEqual(new[] { 2, 1, 2 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 2, 1, 2, 3, 4, 2 }, 3));
            Assert.AreEqual(new[] { 2, 1, 2, 2 }, NSmallestElementsInOriginalOrder.FirstNSmallest(new[] { 2, 1, 2, 3, 4, 2 }, 4));
        }
    }
}