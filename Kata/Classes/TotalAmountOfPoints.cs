using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    internal class TotalAmountOfPoints
    {
        public static class Kata
        {
            public static int TotalPoints(string[] games)
            {
                return games
                    .Select(x => (int.Parse(x.Split(':')[0]), int.Parse(x.Split(':')[1])))
                    .Where(x => x.Item1 >= x.Item2)
                    .Sum(x => x.Item1 > x.Item2 ? 3 : 1);
            }
        }

        [TestFixture]
        public class SolutionTest
        {
            [Test]
            public void Test1() =>
                Test(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "3:1", "4:1", "3:2", "4:2", "4:3" }, 30);

            [Test]
            public void Test2() =>
                Test(new[] { "1:1", "2:2", "3:3", "4:4", "2:2", "3:3", "4:4", "3:3", "4:4", "4:4" }, 10);

            [Test]
            public void Test3() =>
                Test(new[] { "0:1", "0:2", "0:3", "0:4", "1:2", "1:3", "1:4", "2:3", "2:4", "3:4" }, 0);

            [Test]
            public void Test4() =>
                Test(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "1:3", "1:4", "2:3", "2:4", "3:4" }, 15);

            [Test]
            public void Test5() =>
                Test(new[] { "1:0", "2:0", "3:0", "4:4", "2:2", "3:3", "1:4", "2:3", "2:4", "3:4" }, 12);

            private void Test(string[] input, int expectedOutput) =>
                Assert.AreEqual(expectedOutput, Kata.TotalPoints(input));
        }
    }
}