using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// Build a deck of playing cards by generating 52 strings representing cards. There are no jokers.
    /// Each card string will have the format of:
    /// "ace of hearts"
    /// </summary>
    public class A_functional_deck_of_cards
    {
        public class DeckOfCards
        {
            public static string[] BuildDeck() =>
                new List<string>() { "clubs", "diamonds", "hearts", "spades" }
                    .SelectMany(s => new List<string>() { "ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king" }
                        .Select(r => $"{r} of {s}"))
                    .ToArray();
        }
    }
}