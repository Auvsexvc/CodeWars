using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    public class ReversedStrings
    {
        public static string Solution(string str) => string.Concat(str.Reverse());
    }

    [TestFixture]
    public class ReversedStringsTests
    {
        [Test]
        public void World()
        {
            Assert.AreEqual("dlrow", ReversedStrings.Solution("world"));
        }
    }
}