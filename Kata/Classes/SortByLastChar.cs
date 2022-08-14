using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    public class SortByLastCharTests
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new[] { "cba", "cab", "abc" }, SortByLastChar.Last("abc cba cab"));
            Assert.AreEqual(new[] { "aaa", "bbb", "ccc", "ddd" }, SortByLastChar.Last("bbb ccc aaa ddd"));
            Assert.AreEqual(new[] { "wa", "de", "co", "rs" }, SortByLastChar.Last("co de wa rs"));
            Assert.AreEqual(new[] { "axa", "ava", "asa" }, SortByLastChar.Last("axa ava asa"));

            Assert.AreEqual(new[] { "a", "need", "ubud", "i", "taxi", "man", "to", "up" },
                SortByLastChar.Last("man i need a taxi up to ubud"));

            Assert.AreEqual(new[] { "time", "are", "we", "the", "climbing", "volcano", "up", "what" },
                SortByLastChar.Last("what time are we climbing up the volcano"));

            Assert.AreEqual(new[] { "take", "me", "semynak", "to" }, SortByLastChar.Last("take me to semynak"));

            Assert.AreEqual(new[] { "massage", "massage", "massage", "yes", "yes" },
                SortByLastChar.Last("massage yes massage yes massage"));

            Assert.AreEqual(new[] { "a", "and", "take", "dance", "please", "bintang" },
                SortByLastChar.Last("take bintang and a dance please"));
        }
    }

    internal class SortByLastChar
    {
        public static string[] Last(string x)
        {
            return x.Split(' ').OrderBy(x => x.Last()).ToArray();
        }
    }
}