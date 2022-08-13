using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class FormTheMinimumTests
    {
        [TestCase(13, 1, 3, 1)]
        [TestCase(457, 4, 7, 5, 7)]
        [TestCase(148, 4, 8, 1, 4)]
        [TestCase(579, 5, 7, 9, 5, 7)]
        [TestCase(678, 6, 7, 8, 7, 6, 6)]
        [TestCase(45679, 5, 6, 9, 9, 7, 6, 4)]
        [TestCase(134679, 1, 9, 1, 3, 7, 4, 6, 6, 7)]
        [TestCase(356789, 3, 6, 5, 5, 9, 8, 7, 6, 3, 5, 9)]
        public void BasicTests(long res, params int[] a)
        {
            Assert.That(FormTheMinimum.MinValue(a), Is.EqualTo(res));
        }
    }

    internal class FormTheMinimum
    {
        public static long MinValue(int[] a)
        {
            return long.Parse(string.Concat(a.Distinct().OrderBy(x => x)));
        }
    }
}