using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class SumOfPrimeIndexedElementsTest
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(0, SumOfPrimeIndexedElements.solve(new int[] { }));
            Assert.AreEqual(7, SumOfPrimeIndexedElements.solve(new int[] { 1, 2, 3, 4 }));
            Assert.AreEqual(13, SumOfPrimeIndexedElements.solve(new int[] { 1, 2, 3, 4, 5, 6 }));
            Assert.AreEqual(47, SumOfPrimeIndexedElements.solve(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }));
        }
    }

    internal class SumOfPrimeIndexedElements
    {
        public static int solve(int[] arr)
        {
            return arr.Where((_,i) => IsPrime(i)).Sum();
        }

        private static bool IsPrime(int n)
        {
            return n > 1 && Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0);
        }
    }
}