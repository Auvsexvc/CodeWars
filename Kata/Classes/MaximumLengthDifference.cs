using NUnit.Framework;

namespace Kata.Classes
{
    [TestFixture]
    public static class MaximumLengthDifferenceTests
    {
        [Test]
        public static void test1()
        {
            string[] s1 = new string[] { "hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz" };
            string[] s2 = new string[] { "cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww" };
            Assert.AreEqual(13, MaximumLengthDifference.Mxdiflg(s1, s2));
        }
    }

    internal static class MaximumLengthDifference
    {
        public static int Mxdiflg(string[] a1, string[] a2)
        {
            return 0;
        }
    }
}