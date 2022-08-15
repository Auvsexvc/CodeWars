using NUnit.Framework;
using System.Globalization;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class CamelCaseMethodTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("TestCase", "test case".CamelCase());
            Assert.AreEqual("CamelCaseMethod", "camel case method".CamelCase());
            Assert.AreEqual("SayHello", "say hello".CamelCase());
            Assert.AreEqual("CamelCaseWord", " camel case word".CamelCase());
            Assert.AreEqual("", "".CamelCase());
        }
    }

    internal static class CamelCaseMethod
    {
        public static string CamelCase(this string str)
        {
            return str.Length > 0
                ? string.Concat(str
                    .TrimStart(' ')
                    .TrimEnd(' ')
                    .Split(' ')
                    .Select(s => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s)))
                : "";
        }
    }
}