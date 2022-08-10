using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    public class SimpleValidationUsernameRegex
    {
        public static bool ValidateUsr(string username)
        {
            // use regex here
            return Regex.Match(username, @"^([a-z_\d]){4,16}$").Success;
        }
    }

    public class SimpleValidationUsernameRegexTests
    {
        [Test]
        [TestCase("asddsa", ExpectedResult = true)]
        [TestCase("a", ExpectedResult = false)]
        [TestCase("Hass", ExpectedResult = false)]
        [TestCase("Hasd_12ssssssssssssssasasasasasssasassss", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("____", ExpectedResult = true)]
        [TestCase("012", ExpectedResult = false)]
        [TestCase("p1pp1", ExpectedResult = true)]
        [TestCase("asd43 34", ExpectedResult = false)]
        [TestCase("asd43_34", ExpectedResult = true)]
        public static bool FixedTest(string username)
        {
            return SimpleValidationUsernameRegex.ValidateUsr(username);
        }
    }
}