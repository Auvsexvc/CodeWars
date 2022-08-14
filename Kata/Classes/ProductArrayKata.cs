using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    internal class ProductArrayKata
    {
        public static int[] ProductArray(int[] array)
        {
            return Enumerable
                .Range(0, array.Length)
                .Select(i => array
                    .Where((_, idx) => idx != i)
                    .Aggregate((p, n) => p * n))
                .ToArray();
        }
    }

    [TestFixture]
    internal class ProductArrayKataTests
    {
        [TestCase("12 20", "20 12")]
        [TestCase("12 20", "20 12")]
        [TestCase("3 27 4 2", "216 24 162 324")]
        [TestCase("13 10 5 2 9", "900 1170 2340 5850 1300")]
        [TestCase("16 17 4 3 5 2", "2040 1920 8160 10880 6528 16320")]
        public void BasicTest(string s, string str)
        {
            Assert.That(ProductArrayKata.ProductArray(Foo(s)), Is.EqualTo(Foo(str)));
        }

        private int[] Foo(string s) => s.Split().Select(int.Parse).ToArray();
    }
}