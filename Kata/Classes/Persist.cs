using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class PersistTests
    {
        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            Assert.AreEqual(3, Persist.Persistence(39));
            Assert.AreEqual(0, Persist.Persistence(4));
            Assert.AreEqual(2, Persist.Persistence(25));
            Assert.AreEqual(4, Persist.Persistence(999));
        }
    }

    internal class Persist
    {
        public static int Persistence(long n)
        {
            int count = 0;
            while (n.ToString().Length > 1)
            {
                n = n.ToString().Select(c => int.Parse(c.ToString())).Aggregate((a, b) => a * b);
                count++;
            }
            return count;
        }
    }
}