using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    public class GetNthEvenNumber
    {
        public static int NthEven(int n) => 2 * (n - 1);
    }

    [TestFixture]
    public class GetNthEvenNumberTest
    {
        [Test]
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(3, ExpectedResult = 4)]
        [TestCase(100, ExpectedResult = 198)]
        [TestCase(1298734, ExpectedResult = 2597466)]
        public int FixedTest(int n)
        {
            return GetNthEvenNumber.NthEven(n);
        }

        [Test]
        public void RandomTest([Random(1, 1000000, 100)] int n)
        {
            Assert.AreEqual(Solution(n), GetNthEvenNumber.NthEven(n));
        }

        private int Solution(int n) => n * 2 - 2;
    }
}
