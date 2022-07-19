using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class ToWeirdCaseKataTests
    {
        [Test]
        public static void ShouldWorkForSomeExamples()
        {
            Assert.AreEqual("ThIs", ToWeirdCaseKata.ToWeirdCase("This"));
            Assert.AreEqual("Is", ToWeirdCaseKata.ToWeirdCase("is"));
            Assert.AreEqual("ThIs Is A TeSt", ToWeirdCaseKata.ToWeirdCase("This is a test"));
        }
    }

    internal class ToWeirdCaseKata
    {
        public static string ToWeirdCase(string s) => string.Join(" ", s.Split(' ').Select(s => string.Concat(s.Select((c, i) => i % 2 == 0 ? char.ToUpper(c) : char.ToLower(c)))));
    }
}