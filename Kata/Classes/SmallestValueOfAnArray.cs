using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class FindSmallest
    {
        [Test]
        public void Test_54321_value()
        {
            Assert.AreEqual(1, SmallestValueOfAnArray.FindSmallest(new int[] { 5, 4, 3, 2, 1 }, "value"));
        }

        [Test]
        public void Test_54321_index()
        {
            Assert.AreEqual(4, SmallestValueOfAnArray.FindSmallest(new int[] { 5, 4, 3, 2, 1 }, "index"));
        }
    }

    internal class SmallestValueOfAnArray
    {
        public static int FindSmallest(int[] numbers, string toReturn) => toReturn switch
        {
            "index" => Enumerable.Range(0, numbers.Length).First(i => numbers[i] == numbers.Min()),
            _ => numbers.Min(),
        };
    }
}