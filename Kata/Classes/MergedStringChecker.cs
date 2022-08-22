using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class StringMergerTests
    {
        [Test]
        public void HappyPath4()
        {
            Assert.IsTrue(MergedStringChecker.isMerge("Can we merge it? Yes, we can!", "n ee tYw n!", "Cawe mrgi? es, eca"), "codewars can be created from code and wars");
        }

        [Test]
        public void Bananas()
        {
            Assert.IsTrue(MergedStringChecker.isMerge("Bananas from Bahamas", "Bahas", "Bananas from am"), "codewars can be created from code and wars");
        }

        [Test]
        public void HappyPath1()
        {
            Assert.IsTrue(MergedStringChecker.isMerge("codewars", "code", "wars"), "codewars can be created from code and wars");
        }

        [Test]
        public void HappyPath2()
        {
            Assert.IsTrue(MergedStringChecker.isMerge("codewars", "cdwr", "oeas"), "codewars can be created from cdwr and oeas");
        }

        [Test]
        public void SadPath1()
        {
            Assert.IsFalse(MergedStringChecker.isMerge("codewars", "cod", "wars"), "Codewars are not codwars");
        }
    }

    internal class MergedStringChecker
    {
        public static bool isMerge(string s, string part1, string part2)
        {
            if (s.Length != part1.Length + part2.Length)
            {
                return false;
            }
            if (s.Length == 0)
            {
                return true;
            }

            if (s.FirstOrDefault() == part1.FirstOrDefault())
            {
                if (isMerge(s[1..], part1[1..], part2))
                {
                    return true;
                }
            }
            if (s.FirstOrDefault() == part2.FirstOrDefault())
            {
                if (isMerge(s[1..], part1, part2[1..]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}