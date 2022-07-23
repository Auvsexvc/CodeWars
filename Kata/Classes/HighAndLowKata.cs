using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class HighAndLowKata
    {
        public static string HighAndLow(string numbers) =>
            string.Join(" ", numbers.Split().Max(s=> int.Parse(s)), numbers.Split().Min(s => int.Parse(s)));
    }

    [TestFixture]
    public class ExampleTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual("42 -9", HighAndLowKata.HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual("3 1", HighAndLowKata.HighAndLow("1 2 3"));
        }
    }
}
