using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class PositionAverageTests
    {
        private static Random rnd = new Random();

        [Test]
        public static void test1()
        {
            Console.WriteLine("Fixed Tests");
            assertFuzzy("466960, 069060, 494940, 060069, 060090, 640009, 496464, 606900, 004000, 944096", 26.6666666667);
            assertFuzzy("444996, 699990, 666690, 096904, 600644, 640646, 606469, 409694, 666094, 606490", 29.2592592593);
            assertFuzzy("4444444, 4444444, 4444444, 4444444, 4444444, 4444444, 4444444, 4444444", 100);
        }

        private static void assertFuzzy(string s, double exp)
        {
            Console.WriteLine("Testing " + s);
            bool inrange;
            double merr = 1e-9;
            double actual = PositionAverage.PosAverage(s);
            inrange = Math.Abs(actual - exp) <= merr;
            if (inrange == false)
            {
                Console.WriteLine("Expected mean must be near " + exp + ", got " + actual);
            }
            Assert.AreEqual(true, inrange);
        }
    }

    internal class PositionAverage
    {
        public static double PosAverage(string s)
        {
            int[] result = Enumerable
                .Range(0, s.Split(", ").Length)
                .SelectMany(i => s
                    .Split(", ")
                    .Skip(i + 1)
                    .SelectMany(j => Enumerable
                        .Range(0, j.Length)
                        .Select(c => j[c] == s.Split(", ")[i][c] ? 1 : 0)))
                .ToArray();

            return result.Count(r => r > 0) / (result.Length * 1.00) * 100.00;
        }

        public static double PosAverageZip(string s)
        {
            var strings = s.Split(", ");
            var matches = strings.SelectMany((x, i) => strings
                .Skip(i + 1)
                .SelectMany(y => x.Zip(y, (a, b) => a == b)));

            return 100.0 * matches.Count(x => x) / matches.Count();
        }
    }
}