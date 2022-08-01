using NUnit.Framework;
using System;

namespace Kata.Classes
{
    public class CockTest1
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(30, Kmph2Cmps.CockroachSpeed(1.08));
            Assert.AreEqual(30, Kmph2Cmps.CockroachSpeed(1.09));
            Assert.AreEqual(0, Kmph2Cmps.CockroachSpeed(0));
        }
    }

    internal class Kmph2Cmps
    {
        public static int CockroachSpeed(double x) => (int)Math.Floor(x / 0.036);
    }
}