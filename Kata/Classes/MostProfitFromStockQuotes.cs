using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class MostProfitFromStockQuotesTest
    {
        [TestCase("[1, 2, 3, 4, 5, 6]", 15)]
        [TestCase("[6, 5, 4, 3, 2, 1]", 0)]
        [TestCase("[1, 6, 5, 10, 8, 7]", 18)]
        [TestCase("[1, 2, 3, 5, 1, 2, 3, 5]", 18)]
        [TestCase("[1,2,3,10,1,2,3,7,1,2,5]", 46)]
        [TestCase("[31,312,3,35,33,3,44,123,126,2,4,1]", 798)]
        [TestCase("[1,20,1,30,1,40,1,50,1,40,1,30,1,20,1]", 343)]
        public void SampleTests(string input, int expected)
        {
            var quotes = input.Substring(1, input.Length - 2).Split(',').Select(n => int.Parse(n.Trim())).ToArray();
            Act(quotes, expected);
        }

        private static void Act(int[] quotes, int expected)
        {
            var msg = $"Invalid answer for quotes: [{string.Join(",", quotes)}]";
            var actual = MostProfitFromStockQuotes.GetMostProfitFromStockQuotes(quotes);
            Assert.AreEqual(expected, actual, msg);
        }
    }

    internal class MostProfitFromStockQuotes
    {
        public static int GetMostProfitFromStockQuotes(int[] quotes)
        {
            int result = 0;

            while (quotes.Length > 0)
            {
                var localMostProfitSeq = Enumerable
                    .Range(0, quotes.Length)
                    .ToDictionary(k => k, v => quotes[v] - quotes[0])
                    .Aggregate((a, b) => a.Value > b.Value ? a : b);

                result += quotes
                    .Take(localMostProfitSeq.Key + 1)
                    .Select(v => quotes[localMostProfitSeq.Key] - v)
                    .Sum();

                quotes = quotes
                    .Skip(localMostProfitSeq.Key + 1)
                    .ToArray();
            }

            return result;
        }

        public static int GetMostProfitFromStockQuotesKartoffelsalat(int[] quotes)
        {
            return quotes.Select((q, i) => quotes[i..].Max() - q).Sum();
        }
    }
}