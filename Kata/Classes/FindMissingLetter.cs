using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    public class FindMissingLetterKataTests
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual('e', FindMissingLetterKata.FindMissingLetter(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', FindMissingLetterKata.FindMissingLetter(new[] { 'O', 'Q', 'R', 'S' }));
        }
    }

    internal class FindMissingLetterKata
    {
        public static char FindMissingLetter(char[] array) => Enumerable
            .Range(array[0], array.Length)
            .SkipWhile(x => x == array[x - array[0]])
            .Select(x => (char)x)
            .FirstOrDefault();
    }
}