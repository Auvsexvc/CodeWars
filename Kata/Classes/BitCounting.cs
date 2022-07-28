using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class BitCountingTest
    {
        [Test]
        public void CountBits()
        {
            Assert.AreEqual(0, BitCounting.CountBits(0));
            Assert.AreEqual(1, BitCounting.CountBits(4));
            Assert.AreEqual(3, BitCounting.CountBits(7));
            Assert.AreEqual(2, BitCounting.CountBits(9));
            Assert.AreEqual(2, BitCounting.CountBits(10));
        }
    }

    internal class BitCounting
    {
        public static int CountBits(int n)
        {
            //BitArray b = new BitArray(new int[] { n });
            //bool[] bits = new bool[b.Count];
            //b.CopyTo(bits, 0);
            //byte[] bitValues = bits.Select(bit=>(byte)(bit ? 1 : 0)).ToArray();
            //return bitValues.Count(b=>b==1);

            return Convert.ToString(n, 2).Count(b => b == '1');
        }
    }
}