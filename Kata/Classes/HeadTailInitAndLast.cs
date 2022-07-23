using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class HeadTailInitAndLastTest
    {
        [Test, Description("Sample Tests")]
        public void SampleTest()
        {
            Assert.AreEqual(5, new List<int> { 5, 1 }.Head());
            Assert.AreEqual(new List<int> { 2, 3 }, new List<int> { 1, 2, 3 }.Tail());
            Assert.AreEqual(new List<int> { 1, 5, 7 }, new List<int> { 1, 5, 7, 9 }.Init());
            Assert.AreEqual(2, new List<int> { 7, 2 }.Last_());
        }
    }

    internal static class HeadTailInitAndLast
    {
        public static TSource Head<TSource>(this List<TSource> list)
        {
            return list.FirstOrDefault();
        }

        public static List<TSource> Tail<TSource>(this List<TSource> list)
        {
            return list.Skip(1).ToList();
        }

        public static List<TSource> Init<TSource>(this List<TSource> list)
        {
            return list.SkipLast(1).ToList();
        }

        public static TSource Last_<TSource>(this List<TSource> list)
        {
            return list.LastOrDefault();
        }
    }
}