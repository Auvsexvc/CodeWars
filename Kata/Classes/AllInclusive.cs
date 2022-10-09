using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Classes
{
    internal class AllInclusive
    {
        [TestFixture]
        public static class RotationsTests
        {
            [Test]
            public static void test1()
            {
                Console.WriteLine("Basic Tests ContainAllRots");
                List<string> a = new List<string>() { "bsjq", "qbsj", "sjqb", "twZNsslC", "jqbs" };
                testing(Rotations.ContainAllRots("bsjq", a), true);
                a = new List<string>() { };
                testing(Rotations.ContainAllRots("", a), true);
                a = new List<string>() { "bsjq", "qbsj" };
                testing(Rotations.ContainAllRots("", a), true);
                a = new List<string>() { "TzYxlgfnhf", "yqVAuoLjMLy", "BhRXjYA", "YABhRXj", "hRXjYAB", "jYABhRX", "XjYABhR", "ABhRXjY" };
                testing(Rotations.ContainAllRots("XjYABhR", a), false);
            }

            private static void testing(Boolean actual, Boolean expected)
            {
                Assert.AreEqual(expected, actual);
            }
        }

        public class Rotations
        {
            public static Boolean ContainAllRots(string strng, List<string> arr)
            {
                return string.IsNullOrEmpty(strng) || !GetRotations(strng).Except(arr).Any();
            }

            private static IEnumerable<string> GetRotations(string str)
            {
                StringBuilder sb = new StringBuilder(str).Append(str);
                int i = 0;
                while (i < str.Length)
                    yield return sb.ToString(i++, str.Length);
            }
        }
    }
}