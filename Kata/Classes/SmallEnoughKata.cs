using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class SmallEnoughKataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(true, SmallEnoughKata.SmallEnough(new int[] { 66, 101 }, 200));
            Assert.AreEqual(false, SmallEnoughKata.SmallEnough(new int[] { 78, 117, 110, 99, 104, 117, 107, 115 }, 100));
            Assert.AreEqual(true, SmallEnoughKata.SmallEnough(new int[] { 101, 45, 75, 105, 99, 107 }, 107));
            Assert.AreEqual(true, SmallEnoughKata.SmallEnough(new int[] { 80, 117, 115, 104, 45, 85, 112, 115 }, 120));
        }
    }

    internal class SmallEnoughKata
    {
        public static bool SmallEnough(int[] a, int limit) => a.All(x => x <= limit);
    }
}