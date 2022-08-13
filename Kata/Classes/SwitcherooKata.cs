using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    [TestFixture]
    public class SwitcherooKataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("bac", SwitcherooKata.Switcheroo("abc"));
            Assert.AreEqual("bbbacccabbb", SwitcherooKata.Switcheroo("aaabcccbaaa"));
            Assert.AreEqual("ccccc", SwitcherooKata.Switcheroo("ccccc"));
            Assert.AreEqual("babababababababa", SwitcherooKata.Switcheroo("abababababababab"));
            Assert.AreEqual("bbbbb", SwitcherooKata.Switcheroo("aaaaa"));
        }

        [Test]
        public void RandomTests()
        {
            var rand = new Random();

            var names = new[] { "a", "b", "c" };

            for (var i = 0; i < 100; i++)
            {
                var len = rand.Next(1, 30);
                var x = string.Concat(Enumerable.Range(0, len).Select(a => names[rand.Next(0, names.Length - 1)]));

                var expected = string.Concat(x.Select(a => a == 'a' ? 'b' : a == 'b' ? 'a' : a));
                Assert.AreEqual(expected, SwitcherooKata.Switcheroo(x), "It should work for random inputs too");
            }
        }
    }

    internal class SwitcherooKata
    {
        public static string Switcheroo(string x)
        {
            return string.Concat(x.Select(c => c == 'a' ? 'b' : c == 'b' ? 'a' : c));
        }

        public static string SwitcherooRegex(string x)
        {
            return Regex.Replace(x, "[ab]", m => m.Value == "a" ? "b" : "a");
        }
    }
}