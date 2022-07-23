using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class KataTests
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(8, DontGiveMeFiveKata.DontGiveMeFive(1, 9));
            Assert.AreEqual(12, DontGiveMeFiveKata.DontGiveMeFive(4, 17));
        }
    }

    internal class DontGiveMeFiveKata
    {
        public static int DontGiveMeFive(int start, int end) =>
            Enumerable.Range(start, end - (start - 1)).Count(x => !x.ToString().Contains('5'));
    }
}