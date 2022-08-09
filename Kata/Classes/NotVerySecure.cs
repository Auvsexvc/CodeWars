using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    public class NotVerySecure
    {
        public static bool Alphanumeric(string str) =>
            str.Length > 0 && str.Count(char.IsLetterOrDigit) == str.Length;
    }

    [TestFixture]
    public class NotVerySecureTests
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData("Mazinkaiser").Returns(true);
                yield return new TestCaseData("hello world_").Returns(false);
                yield return new TestCaseData("PassW0rd").Returns(true);
                yield return new TestCaseData("     ").Returns(false);
            }
        }

        [Test, TestCaseSource("testCases")]
        public bool Test(string str) => NotVerySecure.Alphanumeric(str);
    }
}