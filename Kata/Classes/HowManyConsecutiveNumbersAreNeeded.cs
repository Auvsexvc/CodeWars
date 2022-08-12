using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class HowManyConsecutiveNumbersAreNeededTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(2, HowManyConsecutiveNumbersAreNeeded.Consecutive(new int[] { 4, 8, 6 }));
            Assert.AreEqual(0, HowManyConsecutiveNumbersAreNeeded.Consecutive(new int[] { 1, 2, 3, 4 }));
            Assert.AreEqual(0, HowManyConsecutiveNumbersAreNeeded.Consecutive(new int[] { }));
            Assert.AreEqual(0, HowManyConsecutiveNumbersAreNeeded.Consecutive(new int[] { 1 }));
        }
    }

    internal class HowManyConsecutiveNumbersAreNeeded
    {
        public static int Consecutive(int[] arr)
        {
            return arr.Length != 0 ? Enumerable.Range(arr.Min(), arr.Max() - arr.Min()).Count(i => !arr.Contains(i)) : 0;
        }
    }
}