using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    public class AllUnique
    {
        public static bool HasUniqueChars(string str) =>
            str.Distinct().Count() == str.Length;
    }

    public class UniqueTestClass
    {
        [Test]
        public void TestHasUniqueChars1()
        {
            Assert.IsTrue(AllUnique.HasUniqueChars("abcdef"));
        }

        [Test]
        public void TestHasUniqueChars2()
        {
            Assert.False(AllUnique.HasUniqueChars("++-"));
        }

        [Test]
        public void TestHasUniqueChars3()
        {
            Assert.False(AllUnique.HasUniqueChars("  nAa"));
        }

        [Test]
        public void TestHasUniqueChars4()
        {
            Assert.False(AllUnique.HasUniqueChars("aba"));
        }
    }
}