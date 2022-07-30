using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Kata.Classes
{
    [TestFixture]
    public class CollatzTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("3->10->5->16->8->4->2->1", CollatzKata.Collatz(3));
        }
    }

    internal static class CollatzKata
    {
        public static string Collatz(int n)
        {
            List<string> returnList = new() { n.ToString() };
            while (n > 1)
            {
                n = (n % 2) switch
                {
                    0 => n / 2,
                    _ => (3 * n) + 1,
                };
                returnList.Add($"{n}");
            }

            return String.Join("->", returnList);
        }
    }
}