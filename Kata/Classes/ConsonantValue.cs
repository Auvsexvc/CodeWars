using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class ConsonantValueTests
    {
        [TestCase("zodiac", 26)]
        [TestCase("chruschtschov", 80)]
        [TestCase("khrushchev", 38)]
        [TestCase("strength", 57)]
        [TestCase("catchphrase", 73)]
        [TestCase("twelfthstreet", 103)]
        [TestCase("mischtschenkoana", 80)]
        public void BasicTests(string input, int expected)
        {
            Assert.That(ConsonantValue.Solve(input), Is.EqualTo(expected));
        }
    }

    public class ConsonantValue
    {
        public static int Solve(string s)
        {
            return s
                .Split(new char[] { 'a', 'e', 'i', 'o', 'u' })
                .GroupBy(x => x
                    .Select(c => (int)char.ToUpper(c) - 64)
                    .Sum())
                .Max(x => x.Key);
        }
    }
}