using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    public class OddOrEvenKata
    {
        public static string OddOrEven(int[] array)
        {
            return array.Count(x => x % 2 != 0) % 2 == 0 ? "even" : "odd";
        }
    }

    [TestFixture]
    public class OddOrEvenKataTest
    {
        [Test, Description("Edge tests")]
        public void EdgeTests()
        {
            Assert.AreEqual("even", OddOrEvenKata.OddOrEven(new int[] { 0 }));
            Assert.AreEqual("odd", OddOrEvenKata.OddOrEven(new int[] { 1 }));
            Assert.AreEqual("even", OddOrEvenKata.OddOrEven(new int[] { }));
        }

        [Test, Description("Even tests")]
        public void EvenTests()
        {
            Assert.AreEqual("even", OddOrEvenKata.OddOrEven(new int[] { 0, 1, 5 }));
            Assert.AreEqual("even", OddOrEvenKata.OddOrEven(new int[] { 0, 1, 3 }));
            Assert.AreEqual("even", OddOrEvenKata.OddOrEven(new int[] { 1023, 1, 2 }));
        }

        [Test, Description("Negative Even tests")]
        public void NegativeEvenTests()
        {
            Assert.AreEqual("even", OddOrEvenKata.OddOrEven(new int[] { 0, -1, -5 }));
            Assert.AreEqual("even", OddOrEvenKata.OddOrEven(new int[] { 0, -1, -3 }));
            Assert.AreEqual("even", OddOrEvenKata.OddOrEven(new int[] { -1023, 1, -2 }));
        }

        [Test, Description("Odd tests")]
        public void OddTests()
        {
            Assert.AreEqual("odd", OddOrEvenKata.OddOrEven(new int[] { 0, 1, 2 }));
            Assert.AreEqual("odd", OddOrEvenKata.OddOrEven(new int[] { 0, 1, 4 }));
            Assert.AreEqual("odd", OddOrEvenKata.OddOrEven(new int[] { 1023, 1, 3 }));
        }

        [Test, Description("Negative Odd tests")]
        public void NegativeOddTests()
        {
            Assert.AreEqual("odd", OddOrEvenKata.OddOrEven(new int[] { 0, -1, 2 }));
            Assert.AreEqual("odd", OddOrEvenKata.OddOrEven(new int[] { 0, 1, -4 }));
            Assert.AreEqual("odd", OddOrEvenKata.OddOrEven(new int[] { -1023, -1, 3 }));
        }
    }
}