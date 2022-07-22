using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void MyTest()
        {
            Assert.AreEqual(new int[0], ReverseListKata.ReverseList(new int[0]));
            Assert.AreEqual(new int[] { 3, 2, 1 }, ReverseListKata.ReverseList(new int[] { 1, 2, 3 }));
        }
    }

    internal static class ReverseListKata
    {
        public static int[] ReverseList(int[] list) => list.Reverse().ToArray();
    }
}