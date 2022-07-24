using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class SumOfDigits
    {
        public int DigitalRoot(long n)
        {
            int i = n.ToString().Sum(c => int.Parse($"{c}"));
            return i.ToString().Length == 1 ? i : DigitalRoot(i);
        }
    }

    [TestFixture]
    public class NumberTest
    {
        private SumOfDigits _num;

        [SetUp]
        public void SetUp()
        {
            _num = new SumOfDigits();
        }

        [TearDown]
        public void TearDown()
        {
            _num = null;
        }

        [Test]
        public void Tests()
        {
            Assert.AreEqual(7, _num.DigitalRoot(16));
            Assert.AreEqual(6, _num.DigitalRoot(456));
        }
    }
}
