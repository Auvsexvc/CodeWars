using NUnit.Framework;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    [TestFixture]
    public class ShortestWordTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(2, ShortestWord.FindShort("Let's travel abroad shall we"));
            Assert.AreEqual(3, ShortestWord.FindShort("bitcoin take over the world maybe who knows perhaps"));
            Assert.AreEqual(3, ShortestWord.FindShort("turns out random test cases are easier than writing out basic ones"));
        }
    }

    internal class ShortestWord
    {
        public static int FindShort(string s) => Regex.Matches(s, @"([\w\']+)").GroupBy(m => m.Value.Length).Min(g => g.Key);
    }
}