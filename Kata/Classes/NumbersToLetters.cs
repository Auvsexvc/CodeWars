using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    public class NumbersToLetters
    {
        public static string Switcher(string[] x) =>
            string.Concat(x.Select(x => x == "27" ? 33 : x == "28" ? 63 : x == "29" ? 32 : (123 - int.Parse(x))).Select(n => (char)n));
    }

    [TestFixture]
    public class NumbersToLettersTests
    {
        [Test]
        public void ExampleTest1()
        {
            string expected = "codewars";

            string actual = NumbersToLetters.Switcher(new string[] { "24", "12", "23", "22", "4", "26", "9", "8" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleTest2()
        {
            string expected = "btswmdsbd kkw";

            string actual = NumbersToLetters.Switcher(new string[] { "25", "7", "8", "4", "14", "23", "8", "25", "23", "29", "16", "16", "4" });

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleTest3()
        {
            string expected = "wc";

            string actual = NumbersToLetters.Switcher(new string[] { "4", "24" });

            Assert.AreEqual(expected, actual);
        }
    }
}