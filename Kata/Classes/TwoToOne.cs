using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class TwoToOneTests
    {
        [Test]
        public static void test1()
        {
            Assert.AreEqual("aehrsty", TwoToOne.Longest("aretheyhere", "yestheyarehere"));
            Assert.AreEqual("abcdefghilnoprstu", TwoToOne.Longest("loopingisfunbutdangerous", "lessdangerousthancoding"));
            Assert.AreEqual("acefghilmnoprstuy", TwoToOne.Longest("inmanylanguages", "theresapairoffunctions"));
        }
    }

    public class TwoToOne
    {
        public static string Longest(string s1, string s2)
        {
            return string.Concat(s1.Union(s2).OrderBy(c => c));
        }
    }
}