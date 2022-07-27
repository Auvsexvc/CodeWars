using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class AlphabetPositionKataTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", AlphabetPositionKata.AlphabetPosition("The sunset sets at twelve o' clock."));
            Assert.AreEqual("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", AlphabetPositionKata.AlphabetPosition("The narwhal bacons at midnight."));
        }
    }

    internal class AlphabetPositionKata
    {
        public static string AlphabetPosition(string text) =>
            string.Join(
                " ",
                text
                    .ToLower()
                    .Where(char.IsLetter)
                    .Select(c => c - 96));
    }
}