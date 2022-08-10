using NUnit.Framework;

namespace Kata.Classes
{
    public class FourSevenKata
    {
        public static int FourSeven(int num)
        {
            while (num == 4)
            {
                return 7;
            }
            while (num == 7)
            {
                return 4;
            }
            return 0;
        }
    }

    [TestFixture]
    public class FourSevenTest
    {
        [Test]
        public void CorrectTests()
        {
            Assert.AreEqual(7, FourSevenKata.FourSeven(4));
            Assert.AreEqual(4, FourSevenKata.FourSeven(7));
        }

        [Test]
        public void WrongTests()
        {
            Assert.AreEqual(0, FourSevenKata.FourSeven(100));
            Assert.AreEqual(0, FourSevenKata.FourSeven(-17));
        }
    }
}