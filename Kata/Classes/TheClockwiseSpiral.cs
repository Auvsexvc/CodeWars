using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class TheClockwiseSpiral
    {
        public static int[,] CreateSpiral(int n)
        {
            int[,] ret = new int[n, n];
            int val = 1;
            int c1 = 0, c2 = n - 1;
            while (val <= n * n)
            {
                for (int i = c1; i <= c2; i++)
                    ret[c1, i] = val++;
                for (int j = c1 + 1; j <= c2; j++)
                    ret[j, c2] = val++;
                for (int i = c2 - 1; i >= c1; i--)
                    ret[c2, i] = val++;
                for (int j = c2 - 1; j >= c1 + 1; j--)
                    ret[j, c1] = val++;
                c1++;
                c2--;
            }

            return ret;
        }
    }

    [TestFixture]
    public class TheClockwiseSpiralTest
    {
        [Test]
        public void Test1()
        {
            var expected = new int[,] { { 1 } };
            Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(1));
        }
        [Test]
        public void Test2()
        {
            var expected = new int[,]
            {
            {1, 2},
            {4, 3},
            };
            Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(2));
        }
        [Test]
        public void Test3()
        {
            var expected = new int[,]
            {
            {1, 2, 3},
            {8, 9, 4},
            {7, 6, 5}
            };
            Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(3));
        }
    }
}
