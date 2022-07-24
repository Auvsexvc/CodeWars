using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class SumOddNumbers
    {
        public static long RowSumOddNumbers(long n) =>
            Enumerable.Range(0, (int)n).Select(i => (n * (n - 1)) + 1 + (2 * i)).Sum();
    }

    [TestFixture]
    public class SumOddNumbersTest
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(1, SumOddNumbers.RowSumOddNumbers(1));
            Assert.AreEqual(74088, SumOddNumbers.RowSumOddNumbers(42));
        }
    }
}
