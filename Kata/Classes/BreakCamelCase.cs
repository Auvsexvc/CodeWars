using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    [TestFixture]
    public class BreakCamelCaseKataTest
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData("camelCasing").Returns("camel Casing");
                yield return new TestCaseData("camelCasingTest").Returns("camel Casing Test");
            }
        }

        [Test, TestCaseSource("testCases")]
        public string Test(string str) => BreakCamelCaseKata.BreakCamelCase(str);
    }

    internal class BreakCamelCaseKata
    {
        public static string BreakCamelCase(string str) => Regex.Replace(str, "([A-Z])", " $1");
    }
}