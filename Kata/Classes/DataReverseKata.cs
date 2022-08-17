using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class DataReverseKataTests
    {
        [Test]
        public static void test1()
        {
            int[] data1 = new int[32] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0 };
            int[] data2 = new int[32] { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 };
            Assert.AreEqual(data2, DataReverseKata.DataReverse(data1));
        }

        [Test]
        public static void test2()
        {
            int[] data1 = new int[16] { 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1 };
            int[] data2 = new int[16] { 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0 };
            Assert.AreEqual(data2, DataReverseKata.DataReverse(data1));
        }
    }

    public class DataReverseKata
    {
        public static int[] DataReverse(int[] data)
        {
            return Enumerable
                .Range(0, data.Length / 8)
                .Select(i => data
                    .Skip(i * 8)
                    .Take(8))
                .Reverse()
                .SelectMany(x => x)
                .ToArray();
        }
    }
}