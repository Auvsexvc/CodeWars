using NUnit.Framework;
using System;

namespace Kata.Classes
{
    internal class TheClosestNumberMultipleOf10
    {
        public int ClosestMultiple10(int num) => num % 10 < 5 ? num - (num % 10) : num - (num % 10) + 10;

        public int ClosestMultiple10Midpoint(int num) => (int)(Math.Round(num / 10d, MidpointRounding.AwayFromZero) * 10);
    }


    [TestFixture]
    public class TheClosestNumberMultipleOf10Test
    {
        private TheClosestNumberMultipleOf10 kata = new TheClosestNumberMultipleOf10();

        [Test]
        public void _0_ShouldReturn10ForNumbersFrom10To14()
        {
            for (int i = 10; i <= 14; ++i)
            {
                Assert.AreEqual(10, kata.ClosestMultiple10(i));
            }
        }

        [Test]
        public void _1_ShouldReturn20ForNumbersFrom15To20()
        {
            for (int i = 15; i <= 20; ++i)
            {
                Assert.AreEqual(20, kata.ClosestMultiple10(i));
            }
        }
    }
}