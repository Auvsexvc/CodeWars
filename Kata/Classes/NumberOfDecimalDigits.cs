﻿using NUnit.Framework;

namespace Kata.Classes
{
    [TestFixture]
    public class SampleTests
    {
        [Test]
        public void Digits()
        {
            Assert.AreEqual(1, NumberOfDecimalDigits.Digits(5ul));
            Assert.AreEqual(5, NumberOfDecimalDigits.Digits(12345ul));
            Assert.AreEqual(10, NumberOfDecimalDigits.Digits(9876543210ul));
        }
    }

    internal static class NumberOfDecimalDigits
    {
        public static int Digits(ulong n) => n.ToString("D").Length;
    }
}