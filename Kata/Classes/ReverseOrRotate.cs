using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class RevrotTests
    {
        [Test]
        public static void test1()
        {
            Console.WriteLine("Testing RevRot");
            testing(ReverseOrRotate.RevRot("1234", 0), "");
            testing(ReverseOrRotate.RevRot("", 0), "");
            testing(ReverseOrRotate.RevRot("1234", 5), "");
            String s = "733049910872815764";
            testing(ReverseOrRotate.RevRot(s, 5), "330479108928157");
        }

        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }

    internal class ReverseOrRotate
    {
        public static string RevRot(string strng, int sz)
        {
            return sz != 0
                ? String.Concat(Enumerable
                    .Range(0, strng.Length / sz)
                    .Select(i => strng.Skip(i * sz).Take(sz))
                    .SelectMany(v => v.Sum(d => d * d * d) % 2 == 0
                        ? v.Reverse()
                        : string.Concat(v.Skip(1).Concat(v.Take(1)))))
                : String.Empty;
        }
    }
}