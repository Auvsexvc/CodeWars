using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class WhichAreInTests
    {
        [Test]
        public void Test1()
        {
            string[] a1 = new string[] { "arp", "live", "strong" };
            string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };
            string[] r = new string[] { "arp", "live", "strong" };
            Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
        }
    }

    internal class WhichAreIn
    {
        public static string[] inArray(string[] array1, string[] array2)
        {
            var ret =  array1
                .Where(x => array2.Where(y => y.Contains(x)).Any())
                .OrderBy(x => x)
                .ToArray();

            return ret;
        }
    }
}