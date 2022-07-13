using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static Kata.Classes.BingoNumberCaller;

namespace Kata.Classes
{
    [TestFixture]
    public class BingoCallerTests
    {
        [TestCase(1, "B1")]
        [TestCase(16, "I16")]
        [TestCase(31, "N31")]
        [TestCase(46, "G46")]
        [TestCase(61, "O61")]
        [TestCase(15, "B15")]
        [TestCase(30, "I30")]
        [TestCase(45, "N45")]
        [TestCase(60, "G60")]
        [TestCase(75, "O75")]
        [TestCase(8, "B8")]
        [TestCase(29, "I29")]
        [TestCase(44, "N44")]
        [TestCase(50, "G50")]
        [TestCase(72, "O72")]
        public void BingoCallerReturnsCorrectString(int number, string expected)
        {
            var sut = new BingoCaller(new gsfgsfgdgr4(number));
            var actual = sut.GetNumber();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EachNumberIsBetween1And75()
        {
            var caller = new BingoCaller(new Random());

            for (var i = 1; i <= 75; i++)
            {
                var number = caller.GetNumber();
                var n = Convert.ToInt32(number.Substring(1));
                Assert.LessOrEqual(1, n);
                Assert.GreaterOrEqual(75, n);
            }
        }

        [Test]
        public void RandomNumberGeneratorReturnsAllNumbersOnlyOnce()
        {
            var list = new List<string>();
            var sut = new BingoCaller(new Random());

            for (var i = 1; i <= 75; i++)
            {
                list.Add(sut.GetNumber());
            }

            Assert.AreEqual(list.Count, list.Distinct().Count());
        }

        [Test]
        public void RandomNumberGeneratorReturnsEmptyStringWhenAllNumbersAreCalled()
        {
            var sut = new BingoCaller(new Random());

            for (var i = 1; i <= 75; i++)
            {
                sut.GetNumber();
            }

            Assert.AreEqual("", sut.GetNumber());
        }

        [Test]
        public void RandomnessTest()
        {
            var random = new Random();

            for (var k = 0; k < 100; k++)
            {
                var numbers = new Dictionary<string, int>();

                for (var i = 0; i < 1000; i++)
                {
                    var caller = new BingoCaller(random);
                    for (var j = 0; j < 75; j++)
                    {
                        var n = caller.GetNumber();
                        if (j > 65)
                        {
                            if (numbers.ContainsKey(n))
                            {
                                numbers[n]++;
                            }
                            else
                            {
                                numbers.Add(n, 1);
                            }
                        }
                    }
                }
                var max = numbers.OrderByDescending(x => x.Value).First();
                var min = numbers.OrderBy(x => x.Value).First();

                Assert.AreEqual(75, numbers.Count, string.Format("Unlikely event happened: not all numbers were drawn during a 1000 attemps in the last 10 numbers of the sequence. Found: {0}.", numbers.Count));
                Assert.Greater(min.Value, 20, string.Format("Unlikely event happened: '{0}' was drawn {1} times during 1000 drawings in the last 10 numbers of the sequence.", min.Key, min.Value));
                Assert.LessOrEqual(max.Value, 500, string.Format("Unlikely event happened: '{0}' was drawn {1} times out of 1000 in the last 10 numbers of the sequence.", max.Key, max.Value));
            }
        }
    }

    public class gsfgsfgdgr4 : Random
    {
        private int value;

        public gsfgsfgdgr4(int values)
        {
            this.value = values;
        }

        public override int Next()
        {
            return value;
        }

        public override int Next(int maxValue)
        {
            return value;
        }

        public override int Next(int minValue, int maxValue)
        {
            return value;
        }
    }

    /// <summary>
    /// After yet another dispute on their game the Bingo Association decides to change course and automize the game.
    ///     Can you help the association by writing a method that replaces their Bingo machine?
    ///     Task:
    /// Finish method:
    /// BingoCaller.GetNumber()
    /// Return all numbers in the range of 1 until 75 once and in random order
    /// If there are no numbers left, return an empty string
    /// The numbers are returned one by one in Bingo style:
    /// "I27", "N40", "B5", "B12", "I28", "O69", "B1", ...
    /// These are the ranges that you must follow:
    /// A number within range 1 to 15 starts with a 'B'
    /// A number within range 16 to 30 starts with an 'I'
    /// A number within range 31 to 45 starts with an 'N'
    /// A number within range 46 to 60 starts with a 'G'
    /// A number within range 61 to 75 starts with an 'O'
    /// Use ```System.Random``` to generate your random numbers.Pass via the constructor for testing purposes.
    /// </summary>
    internal class BingoNumberCaller
    {
        public class BingoCaller
        {
            private readonly Random _random;
            private int _number;
            private readonly bool[] list = new bool[75];

            public BingoCaller(Random random)
            {
                _random = random;
            }

            public string GetNumber()
            {
                if (list.All(x => x))
                    return String.Empty;
                do
                {
                    _number = _random.Next(1, 76);
                }
                while (list[_number - 1]);
                list[_number - 1] = true;

                string retString = string.Empty;
                if (_number < 16) retString += "B";
                else if (_number >= 16 && _number < 31) retString += "I";
                else if (_number >= 31 && _number < 46) retString += "N";
                else if (_number >= 46 && _number < 61) retString += "G";
                else retString += "O";

                return retString + _number.ToString();
            }
        }
    }
}