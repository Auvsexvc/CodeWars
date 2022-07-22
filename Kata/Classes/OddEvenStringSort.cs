using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class OddEvenStringSortTests
    {
        private static object[] testCases = new object[]
        {
            new object[] {"CodeWars", "CdWr oeas"},
            new object[] {"YCOLUE'VREER", "YOU'RE CLEVER"},
        };

        [Test, TestCaseSource("testCases")]
        public void Test(string s, string expected) => Assert.AreEqual(expected, OddEvenStringSort.SortMyString(s));
    }

    internal class OddEvenStringSort
    {
        public static string SortMyString(string s) =>
            string
                .Concat(Enumerable
                    .Range(0, s.Length)
                    .GroupBy(i => i % 2 == 0)
                    .SelectMany(g => g
                        .Select(e => s[e])
                        .Append(' ')))
                .TrimEnd();
    }
}