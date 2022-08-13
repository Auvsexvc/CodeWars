using NUnit.Framework;
using static Kata.Classes.RockPaperScissorsLizardSpock;

namespace Kata.Classes
{
    public class RockPaperScissorsLizardSpock
    {
        public enum Value
        { Scissors, Paper, Rock, Lizard, Spock }

        public enum Ordering
        { LT, EQ, GT }

        public static Ordering Rpsls(Value a, Value b)
        {
            if ((int)a < (int)b)
            {
                return (((int)a - (int)b) % 2 == 0) ? Ordering.LT : Ordering.GT;
            }
            else if ((int)a > (int)b)
            {
                return (((int)a - (int)b) % 2 == 0) ? Ordering.GT : Ordering.LT;
            }

            return Ordering.EQ;
        }

        public static Ordering Rpslsbouchert(Value a, Value b)
        => ((a - b + 4) % 5) switch
        {
            0 or 2 => Ordering.LT,
            1 or 3 => Ordering.GT,
            4 => Ordering.EQ
        };
    }

    [TestFixture]
    public class RockPaperScissorsLizardSpockTest
    {
        [TestCase(Value.Rock, Value.Lizard, Ordering.GT)]
        [TestCase(Value.Paper, Value.Rock, Ordering.GT)]
        [TestCase(Value.Scissors, Value.Lizard, Ordering.GT)]
        [TestCase(Value.Lizard, Value.Paper, Ordering.GT)]
        [TestCase(Value.Spock, Value.Rock, Ordering.GT)]
        public void Player1Wins(Value a, Value b, Ordering expected)
        {
            Act(a, b, expected);
        }

        [TestCase(Value.Rock, Value.Lizard, Ordering.LT)]
        [TestCase(Value.Paper, Value.Rock, Ordering.LT)]
        [TestCase(Value.Scissors, Value.Lizard, Ordering.LT)]
        [TestCase(Value.Lizard, Value.Paper, Ordering.LT)]
        [TestCase(Value.Spock, Value.Rock, Ordering.LT)]
        public void Player2Wins(Value a, Value b, Ordering expected)
        {
            // note that a and b are swapped
            Act(b, a, expected);
        }

        [TestCase(Value.Rock, Value.Rock, Ordering.EQ)]
        [TestCase(Value.Spock, Value.Spock, Ordering.EQ)]
        public void Draw(Value a, Value b, Ordering expected)
        {
            Act(a, b, expected);
        }

        private static void Act(Value a, Value b, Ordering expected)
        {
            var msg = $"Invalid answer for a: {a}, b = {b}";
            var actual = RockPaperScissorsLizardSpock.Rpsls(a, b);
            Assert.AreEqual(expected, actual, msg);
        }
    }
}