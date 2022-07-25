using NUnit.Framework;
using System.Numerics;

namespace Kata.Classes
{
    [TestFixture]
    public class AddingBigNumbersTest
    {
        [Test]
        public void ASimpleKataTest()
        {
            Assert.AreEqual("110", AddingBigNumbers.Add("91", "19"));
            Assert.AreEqual("1111111111", AddingBigNumbers.Add("123456789", "987654322"));
            Assert.AreEqual("1000000000", AddingBigNumbers.Add("999999999", "1"));
        }
    }

    internal class AddingBigNumbers
    {
        public static string Add(string a, string b) =>
            BigInteger.Add(BigInteger.Parse(a), BigInteger.Parse(b)).ToString();
    }
}