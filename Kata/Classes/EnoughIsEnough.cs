﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Kata.Classes
{
    [TestFixture]
    public class DeleteNthTests
    {
        [Test]
        public void TestSimple()
        {
            var expected = new int[] { 20, 37, 21 };

            var actual = EnoughIsEnough.DeleteNth(new int[] { 20, 37, 20, 21 }, 1);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSimple2()
        {
            var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };

            var actual = EnoughIsEnough.DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);

            CollectionAssert.AreEqual(expected, actual);
        }
    }

    internal class EnoughIsEnough
    {
        public static int[] DeleteNth(int[] arr, int x)
        {
            return arr.Where((t, i) => arr.Take(i + 1).Count(s => s == t) <= x).ToArray();
        }
    }
}