using NUnit.Framework;
using System;

namespace Kata.Classes
{
    public class FindNextPerfectSquare
    {
        public static long FindNextSquare(long num)
        {
            return num != Math.Pow((long)Math.Sqrt(num), 2) ? -1 : (long)(Math.Sqrt(num) + 1) * (long)(Math.Sqrt(num) + 1);
        }
    }

    [TestFixture]
    public class FindNextPerfectSquareTests
    {
        [Test]
        [TestCase(155, ExpectedResult = -1)]
        [TestCase(4503599627370497, ExpectedResult = -1)]
        [TestCase(73834630508331225, ExpectedResult = 73834631051781796)]
        [TestCase(121, ExpectedResult = 144)]
        [TestCase(625, ExpectedResult = 676)]
        [TestCase(319225, ExpectedResult = 320356)]
        [TestCase(15241383936, ExpectedResult = 15241630849)]
        public static long SampleTests(long num)
        {
            return FindNextPerfectSquare.FindNextSquare(num);
        }
    }
}