using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    internal static class MinimizeSumOfArray
    {
        public static int MinSum(int[] a)
        {
            return a
                .OrderBy(x => x)
                .Zip(a.OrderByDescending(x => x))
                .Take(a.Length / 2)
                .Sum(x => x.First * x.Second);
        }
    }

    [TestFixture]
    internal class MinimizeSumOfArrayTests
    {
        [TestCase(2, 1, 2)]
        [TestCase(22, 5, 4, 2, 3)]
        [TestCase(342, 12, 6, 10, 26, 3, 24)]
        [TestCase(74, 9, 2, 8, 7, 5, 4, 0, 6)]
        public void BasicTests(int expected, params int[] a)
        {
            Assert.That(MinimizeSumOfArray.MinSum(a), Is.EqualTo(expected));
        }

        [Test]
        public void EmptyInput()
        {
            var a = new int[] { };
            Assert.That(MinimizeSumOfArray.MinSum(a), Is.EqualTo(0));
        }
    }
}