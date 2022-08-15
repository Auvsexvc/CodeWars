using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class CountCharactersInYourStringTests
    {
        [Test]
        public static void FixedTest_aaaa()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 4);
            Assert.AreEqual(d, CountCharactersInYourString.Count("aaaa"));
        }

        [Test]
        public static void FixedTest_aabb()
        {
            Dictionary<char, int> d = new Dictionary<char, int>();
            d.Add('a', 2);
            d.Add('b', 2);
            Assert.AreEqual(d, CountCharactersInYourString.Count("aabb"));
        }
    }

    internal class CountCharactersInYourString
    {
        public static Dictionary<char, int> Count(string str)
        {
            return str.Distinct().ToDictionary(x => x, x => str.Count(c => c == x));
        }

        public static Dictionary<char, int> Count2(string str)
        {
            return str.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        }
    }
}