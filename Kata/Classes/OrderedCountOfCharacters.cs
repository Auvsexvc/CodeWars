using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class OrderedCountOfCharactersTestSuite
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(
                new List<Tuple<char, int>>() {
                    tuple('a', 5),
                    tuple('b', 2),
                    tuple('r', 2),
                    tuple('c', 1),
                    tuple('d', 1)
                },
                OrderedCountOfCharacters.OrderedCount("abracadabra")
            );
            Assert.AreEqual(
                new List<Tuple<char, int>>() {
                    tuple('C', 1),
                    tuple('o', 1),
                    tuple('d', 1),
                    tuple('e', 1),
                    tuple(' ', 1),
                    tuple('W', 1),
                    tuple('a', 1),
                    tuple('r', 1),
                    tuple('s', 1)
                },
                OrderedCountOfCharacters.OrderedCount("Code Wars")
            );
        }

        private static Tuple<char, int> tuple(char character, int count)
        {
            return new Tuple<char, int>(character, count);
        }
    }

    internal class OrderedCountOfCharacters
    {
        public static List<Tuple<char, int>> OrderedCount(string input) =>
            input.Distinct().Select(x => (x, input.Count(c => c == x)).ToTuple()).ToList();

        public static IEnumerable<Tuple<char, int>> OrderedCount1(string input)
        {
            return input.GroupBy(x => x, (c, g) => (c, g.Count()).ToTuple());
        }

        public static List<Tuple<char, int>> OrderedCount2(string input)
        {
            return input
                    .GroupBy(x => x)
                    .Select(x => Tuple.Create(x.Key, x.Count()))
                    .ToList();
        }
    }
}