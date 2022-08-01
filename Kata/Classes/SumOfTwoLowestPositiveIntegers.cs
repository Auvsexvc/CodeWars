using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class SumOfTwoLowestPositiveIntegersTests
    {
        [Test]
        public void Test1()
        {
            int[] numbers = { 5, 8, 12, 19, 22 };
            Assert.AreEqual(13, SumOfTwoLowestPositiveIntegers.sumTwoSmallestNumbers(numbers));
        }

        [Test]
        public void Test2()
        {
            int[] numbers = { 19, 5, 42, 2, 77 };
            Assert.AreEqual(7, SumOfTwoLowestPositiveIntegers.sumTwoSmallestNumbers(numbers));
        }

        [Test]
        public void Test3()
        {
            int[] numbers = { 10, 343445353, 3453445, 2147483647 };
            Assert.AreEqual(3453455, SumOfTwoLowestPositiveIntegers.sumTwoSmallestNumbers(numbers));
        }
    }

    internal class SumOfTwoLowestPositiveIntegers
    {
        public static int sumTwoSmallestNumbers(int[] numbers) =>
            numbers.OrderBy(x => x).Take(2).Sum();
    }
}