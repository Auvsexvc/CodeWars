using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    [TestFixture]
    public class CheckSameCaseTest
    {
        [Test]
        public void TrueTests()
        {
            Assert.AreEqual(1, CheckSameCase.SameCase('a', 'u'));
            Assert.AreEqual(1, CheckSameCase.SameCase('A', 'U'));
            Assert.AreEqual(1, CheckSameCase.SameCase('Q', 'P'));
            Assert.AreEqual(1, CheckSameCase.SameCase('w', 'y'));
            Assert.AreEqual(1, CheckSameCase.SameCase('c', 'm'));
            Assert.AreEqual(1, CheckSameCase.SameCase('N', 'W'));
        }

        [Test]
        public void FalseTests()
        {
            Assert.AreEqual(0, CheckSameCase.SameCase('a', 'U'));
            Assert.AreEqual(0, CheckSameCase.SameCase('A', 'u'));
            Assert.AreEqual(0, CheckSameCase.SameCase('Q', 'p'));
            Assert.AreEqual(0, CheckSameCase.SameCase('w', 'Y'));
            Assert.AreEqual(0, CheckSameCase.SameCase('c', 'M'));
            Assert.AreEqual(0, CheckSameCase.SameCase('N', 'w'));
        }

        [Test]
        public void NotLetters()
        {
            Assert.AreEqual(-1, CheckSameCase.SameCase('a', '*'));
            Assert.AreEqual(-1, CheckSameCase.SameCase('A', '%'));
            Assert.AreEqual(-1, CheckSameCase.SameCase('Q', '1'));
            Assert.AreEqual(-1, CheckSameCase.SameCase('w', '-'));
            Assert.AreEqual(-1, CheckSameCase.SameCase('c', '8'));
            Assert.AreEqual(-1, CheckSameCase.SameCase('N', ':'));
        }
    }

    internal static class CheckSameCase
    {
        public static int SameCase(char a, char b)
        {
            return !Regex.IsMatch(string.Concat(a, b), "^[a-zA-Z]*$")
                ? -1
                : Regex.IsMatch(string.Concat(a, b), "^[A-Z]*$|^[a-z]*$")
                    ? 1
                    : 0;
        }

        public static int SameCaseLinq(char a, char b)
        {
            return !char.IsLetter(a) || !char.IsLetter(b)
                ? -1
                : (char.IsLower(a) && char.IsLower(b)) || (!char.IsLower(a) && !char.IsLower(b))
                    ? 1
                    : 0;
        }
    }
}