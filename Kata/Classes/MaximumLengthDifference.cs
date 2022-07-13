using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class MaximumLengthDifferenceTests
    {
        private static readonly Random _rnd = new();

        [Test]
        public static void MxdiflgTest1()
        {
            string[] s1 = new string[] { "hoqq", "bbllkw", "oox", "ejjuyyy", "plmiis", "xxxzgpsssa", "xxwwkktt", "znnnnfqknaz", "qqquuhii", "dvvvwz" };
            string[] s2 = new string[] { "cccooommaaqqoxii", "gggqaffhhh", "tttoowwwmmww" };
            Assert.AreEqual(13, MaximumLengthDifference.Mxdiflg(s1, s2)); // 13
            s1 = new string[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" };
            s2 = new string[] { "bbbaaayddqbbrrrv" };
            Assert.AreEqual(10, MaximumLengthDifference.Mxdiflg(s1, s2)); // 10
            s1 = new string[] { "ccct", "tkkeeeyy", "ggiikffsszzoo", "nnngssddu", "rrllccqqqqwuuurdd", "kkbbddaakkk" };
            s2 = new string[] { "tttxxxxxxgiiyyy", "ooorcvvj", "yzzzhhhfffaaavvvpp", "jjvvvqqllgaaannn", "tttooo", "qmmzzbhhbb" };
            Assert.AreEqual(14, MaximumLengthDifference.Mxdiflg(s1, s2)); // 14
            s1 = Array.Empty<string>();
            s2 = new String[] { "bbbaaayddqbbrrrv" };
            Assert.AreEqual(-1, MaximumLengthDifference.Mxdiflg(s1, s2));
            s1 = new String[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" };
            s2 = Array.Empty<string>();
            Assert.AreEqual(-1, MaximumLengthDifference.Mxdiflg(s1, s2));
            s1 = Array.Empty<string>();
            s2 = Array.Empty<string>();
            Assert.AreEqual(-1, MaximumLengthDifference.Mxdiflg(s1, s2));
        }

        public static void RandomTest()
        {
            Console.WriteLine("100 Random Tests MaxDifLength");
            for (int i = 0; i < 100; i++)
            {
                string[] s1 = DoEx(_rnd.Next(1, 10));
                string[] s2 = DoEx(_rnd.Next(1, 8));
                Assert.AreEqual(MxdiflgSol(s1, s2), MaximumLengthDifference.Mxdiflg(s1, s2));
            }
        }

        public static string[] DoEx(int k)
        {
            string[] a1 = new string[k];
            for (int u = 0; u < k; u++)
            {
                string res = "";
                for (int i = 0; i < _rnd.Next(1, 15); i++)
                {
                    int n = _rnd.Next(97, 122);
                    for (int j = 0; j < _rnd.Next(1, 4); j++)
                        res += (char)n;
                }
                a1[u] = res;
            }
            return a1;
        }

        public static int MxdiflgSol(string[] a1, string[] a2)
        {
            int mx = -1;
            foreach (string x in a1)
            {
                foreach (string y in a2)
                {
                    int diff = Math.Abs(x.Length - y.Length);
                    if (diff > mx)
                        mx = diff;
                }
            }

            return mx;
        }
    }

    internal static class MaximumLengthDifference
    {
        public static int Mxdiflg(string[] a1, string[] a2) =>
            a1.Length == 0 || a2.Length == 0 ? -1 : a1.SelectMany(s1 => a2.Select(s2 => Math.Abs(s1.Length - s2.Length))).Max();
    }
}