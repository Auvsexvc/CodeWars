using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class XShapeTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.That(XShape.X(3), Is.EqualTo("■□■\n□■□\n■□■"));
            Assert.That(XShape.X(5), Is.EqualTo("■□□□■\n□■□■□\n□□■□□\n□■□■□\n■□□□■"));
        }
    }

    internal class XShape
    {
        public static string X(int n) =>
            string.Join(
                '\n',
                Enumerable
                    .Range(0, n)
                    .Select(row => string.Concat(Enumerable
                        .Range(0, n)
                        .Select(col => col == row || col == Math.Abs(row - (n - 1))
                            ? '■'
                            : '□'))));
    }
}