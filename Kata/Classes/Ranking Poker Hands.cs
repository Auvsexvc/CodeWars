using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// Create a poker hand that has a method to compare itself to another poker hand:
    /// Result PokerHand.CompareWith(PokerHand hand);
    /// A poker hand has a constructor that accepts a string containing 5 cards:
    /// PokerHand hand = new PokerHand("KS 2H 5C JD TD");
    /// The characteristics of the string of cards are:
    /// Each card consists of two characters, where
    /// The first character is the value of the card: 2, 3, 4, 5, 6, 7, 8, 9, T(en), J(ack), Q(ueen), K(ing), A(ce)
    /// The second character represents the suit: S(pades), H(earts), D(iamonds), C(lubs)
    /// A space is used as card separator between cards
    /// The result of your poker hand compare can be one of these 3 options:
    ///
    /// </summary>
    internal class Ranking_Poker_Hands
    {
        public enum Result
        {
            Win,
            Loss,
            Tie
        }

        public class PokerHand
        {
            private static List<string> suits = new List<string>() { "C", "D", "H", "S" };

            private static Dictionary<string, int> ranksAndValues = new Dictionary<string, int>()
                { { "A", 14 },{ "2", 2 },{ "3", 3 },{ "4", 4 },{ "5", 5 },{ "6", 6 },{ "7", 7 },{ "8", 8 },{ "9", 9 },{ "T", 10 },{ "J", 11 },{ "Q", 12 },{ "K", 13 } };

            private List<Card> _handCards;
            private int _rank;

            public int Rank => _rank;

            public PokerHand(string hand)
            {
                _handCards = HandBuilder(hand);
                SetTheRank();
            }

            public Result CompareWith(PokerHand hand)
            {
                if(this.CompareTo(hand) == -1)
                    return Result.Win;
                if(this.CompareTo(hand) == 1)
                    return Result.Loss;
                return Result.Tie;
            }

            public void SetTheRank()
            {
                _rank = _handCards.Select(c => c.Value).Sum();
                if (IsRoyalFlush()) _rank += 1000000;
                else if (IsStraightFlush()) _rank += 950000;
                else if (IsStraightFlushLow()) _rank += 900000;
                else if (IsFourOfAKind()) _rank += 800000;
                else if (IsFullHouse()) _rank += 700000;
                else if (IsFlush()) _rank += 600000;
                else if (IsStraight()) _rank += 500000;
                else if (IsStraightLow()) _rank += 400000;
                else if (IsThreeOfAKind()) _rank += 300000;
                else if (IsTwoPairs()) _rank += 200000;
                else if (IsPair()) _rank += 100000 + 10 * (this._handCards.Select(c => c.Value).Sum() - this._handCards.Select(c => c.Value).Distinct().Sum());
                else
                {
                    _rank = 0;
                    var tmp = _handCards.OrderByDescending(c => c.Value).Select(c => c.Value).ToList();
                    for (int i = 0; i < 5; i++)
                    {
                        if (i == 0) _rank += tmp[i] * 5;
                        else
                            _rank += (tmp[i] * (6 - i)) / ((tmp[i - 1] - tmp[i]) * (i));
                    }
                }
            }

            private List<Card> HandBuilder(string hand) =>
                hand.Split(" ").Select(c => new Card(c)).ToList();

            public bool IsPair() =>
                this._handCards.Select(c => c.Value).Distinct().Count() == this._handCards.Count() - 1
                    && this._handCards.Select(c => c.Value).Distinct().Any(c => _handCards.Where(d => d.Value == c).Count() == 2);

            public bool IsTwoPairs() =>
                this._handCards.Select(c => c.Value).Distinct().Count() == this._handCards.Count() - 2
                    && this._handCards.Select(c => c.Value).Distinct().Any(c => _handCards.Where(d => d.Value == c).Count() == 2);

            public bool IsThreeOfAKind() =>
                this._handCards.Select(c => c.Value).Distinct().Count() == this._handCards.Count() - 2
                    && this._handCards.Select(c => c.Value).Distinct().Any(c => _handCards.Where(d => d.Value == c).Count() == 3);

            public bool IsStraightLow() =>
                this._handCards.Select(c => c.Value).Distinct().Count() == this._handCards.Count()
                    && (_handCards.Where(c => c.Value == 14).Count() == 1 && _handCards.Where(c => c.Value != 14).Select(c => c.Value).Max() == 5 && _handCards.Select(c => c.Value).Min() == 2);

            public bool IsStraight() =>
                this._handCards.Select(c => c.Value).Distinct().Count() == this._handCards.Count()
                    && this._handCards.Select(c => c.Value).Max() - this._handCards.Select(c => c.Value).Min() == 4;

            public bool IsFlush() =>
                this._handCards.Select(c => c.Value).Distinct().Count() == this._handCards.Count()
                && this._handCards.Select(c => c.Suit).Distinct().Count() == 1;

            public bool IsFullHouse() =>
                this._handCards.Select(c => c.Value).Distinct().Count() == this._handCards.Count() - 3;

            public bool IsFourOfAKind() =>
                this._handCards.Distinct().Count() == this._handCards.Count() - 3
                    && this._handCards.Select(c => c.Value).Distinct().Any(c => _handCards.Where(d => d.Value == c).Count() == 4);

            public bool IsStraightFlushLow() =>
                this._handCards.Select(c => c.Suit).Distinct().Count() == 1
                    && (_handCards.Where(c => c.Value == 14).Count() == 1 && _handCards.Where(c => c.Value != 14).Select(c => c.Value).Max() == 5 && _handCards.Select(c => c.Value).Min() == 2);

            public bool IsStraightFlush() =>
                this._handCards.Select(c => c.Value).Max() - this._handCards.Select(c => c.Value).Min() == 4
                    && this._handCards.Select(c => c.Suit).Distinct().Count() == 1;

            public bool IsRoyalFlush() =>
                this._handCards.Select(c => c.Value).Sum() == 60
                    && this._handCards.Select(c => c.Suit).Distinct().Count() == 1;

            public int CompareTo(PokerHand other)
            {
                if (this.Rank > other.Rank) return -1;
                if (this.Rank == other.Rank) return 0;
                return 1;
            }

            private class Card
            {
                public string Suit { get; set; }
                public int Value { get; set; }

                public Card(string cardName)
                {
                    Suit = suits.Where(s => s == cardName[1].ToString()).FirstOrDefault();
                    Value = ranksAndValues.Where(s => s.Key == cardName[0].ToString()).FirstOrDefault().Value;
                }
            }
        }
    }
}