using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class BackspacesInStringTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual("ac", BackspacesInString.CleanString("abc#d##c"));
            Assert.AreEqual("", BackspacesInString.CleanString("abc####d##c#"));
        }
    }

    internal static class BackspacesInString
    {
        public static string CleanString(string s)
        {
            var str = string.Empty;
            int bsp = 0;

            foreach (var item in s.Reverse())
            {
                if (item == '#')
                {
                    bsp++;
                }
                else if (bsp < 1)
                {
                    str += item;
                }
                else
                {
                    bsp--;
                }
            }

            return string.Join("", str.Reverse());
        }
    }
}