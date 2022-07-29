using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class PrinterTests
    {
        [Test]
        public static void test1()
        {
            Console.WriteLine("Testing PrinterError");
            string s = "aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz";
            Assert.AreEqual("3/56", PrinterErrors.PrinterError(s));
        }
    }

    internal class PrinterErrors
    {
        public static string PrinterError(String s) =>
            string.Join("/", s.Count(c => c > 'm'), s.Length);
    }
}