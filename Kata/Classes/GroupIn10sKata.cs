using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    public static class GroupIn10sKata
    {
        public static int[][] GroupIn10s(int[] array)
        {
            var x = array.Length > 0
                ? Enumerable
                    .Range(0, (array.Max() / 10) + 1)
                    .GroupBy(r => (Group: r, Numbers: array.Where(x => x / 10 == r).OrderBy(x => x).ToArray()))
                    .Select(x => x.Key)
                    .Select(x => x.Numbers.Length > 0
                        ? x.Numbers
                        : null)
                : new int[][] { };

            return x.ToArray();
        }
    }

    [TestFixture]
    public class GroupIn10sKataTest
    {
        [Test]
        public void BasicTests()
        {
            var expected = new int[][] { new int[] { 1, 2, 3 } };
            Assert.AreEqual(expected, GroupIn10sKata.GroupIn10s(new int[] { 1, 2, 3 }));

            expected = new int[][] { new int[] { 3, 8 },
                               new int[] { 12, 17, 19 },
                               new int[] { 25 },
                               new int[] { 35, 38 },
                               null,
                               new int[] { 50 } };
            Assert.AreEqual(expected, GroupIn10sKata.GroupIn10s(new int[] { 8, 12, 38, 3, 17, 19, 25, 35, 50 }));

            expected = new int[][] { null,
                               new int[] { 10, 11, 12, 13 },
                               new int[] { 25, 28, 29 },
                               null,
                               new int[] { 49 },
                               new int[] { 51 },
                               null,
                               null,
                               null,
                               new int[] { 90 } };
            Assert.AreEqual(expected, GroupIn10sKata.GroupIn10s(new int[] { 12, 10, 11, 13, 25, 28, 29, 49, 51, 90 }));

            Assert.AreEqual(new int[][] { }, GroupIn10sKata.GroupIn10s(new int[] { }));

            expected = new int[][] { null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               null,
                               new int[] { 100 } };

            Assert.AreEqual(expected, GroupIn10sKata.GroupIn10s(new int[] { 100 }));
        }
    }
}