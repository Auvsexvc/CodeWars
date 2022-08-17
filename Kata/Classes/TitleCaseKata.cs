using NUnit.Framework;
using System;
using System.Globalization;
using System.Linq;

namespace Kata.Classes
{
    public class TitleCaseKata
    {
        public static string TitleCase(string title, string minorWords = "")
        {
            return string.Join(
                " ",
                CultureInfo
                    .CurrentCulture
                    .TextInfo
                    .ToTitleCase(title.ToLower())
                    .Split(' ')
                    .Select((v, i) => minorWords != null && i != 0 && minorWords.ToLower().Split(' ').Contains(v.ToLower())
                        ? v.ToLower()
                        : v));
        }
    }

    [TestFixture]
    public class TitleCaseKataTest
    {
        [TestCase("a clash of KINGS", "a an the of", "A Clash of Kings")]
        [TestCase("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
        public void MyTest(string sampleTitle, string sampleMinorWords, string expected)
        {
            Assert.AreEqual(expected, TitleCaseKata.TitleCase(sampleTitle, sampleMinorWords));
        }

        [Test]
        public void MyTest2()
        {
            Assert.AreEqual("", TitleCaseKata.TitleCase(""));
        }

        [Test]
        public void MyTest3()
        {
            Assert.AreEqual("The Quick Brown Fox", TitleCaseKata.TitleCase("the quick brown fox"));
        }
    }
}