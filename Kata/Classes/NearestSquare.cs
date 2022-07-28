using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class NearestSquare
    {
        public static int NearestSq(int n) => (int)Math.Pow(Math.Round(Math.Sqrt(n)), 2);
    }

    [TestFixture]
    public class NearestSquareTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.That(NearestSquare.NearestSq(1), Is.EqualTo(1));
            Assert.That(NearestSquare.NearestSq(2), Is.EqualTo(1));
            Assert.That(NearestSquare.NearestSq(10), Is.EqualTo(9));
            Assert.That(NearestSquare.NearestSq(111), Is.EqualTo(121));
            Assert.That(NearestSquare.NearestSq(9999), Is.EqualTo(10000));
        }
    }
}
