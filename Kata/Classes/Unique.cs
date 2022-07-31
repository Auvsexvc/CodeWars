using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    public class Unique
    {
        public static int GetUnique(IEnumerable<int> numbers) =>
            numbers
                .GroupBy(x => x)
                .OrderBy(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

        public static int GetUnique2(IEnumerable<int> numbers)
        {
            return numbers.GroupBy(x => x).Single(x => x.Count() == 1).Key;
        }
    }

    [TestFixture]
    public class UniqueTest
    {
        [TestCase(new[] { 1, 2, 2, 2 }, ExpectedResult = 1)]
        [TestCase(new[] { -2, 2, 2, 2 }, ExpectedResult = -2)]
        [TestCase(new[] { 11, 11, 14, 11, 11 }, ExpectedResult = 14)]
        public int BaseTest(IEnumerable<int> numbers)
        {
            return Unique.GetUnique(numbers);
        }
    }
}