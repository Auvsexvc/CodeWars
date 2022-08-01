using NUnit.Framework;

namespace Kata.Classes
{
    [TestFixture]
    public class CenturyFromYearTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(18, CenturyFromYear.СenturyFromYear(1705));
            Assert.AreEqual(19, CenturyFromYear.СenturyFromYear(1900));
            Assert.AreEqual(17, CenturyFromYear.СenturyFromYear(1601));
            Assert.AreEqual(20, CenturyFromYear.СenturyFromYear(2000));
        }
    }

    internal static class CenturyFromYear
    {
        public static int СenturyFromYear(int year) =>
            year % 100 == 0 ? year / 100 : (year / 100) + 1;
    }
}