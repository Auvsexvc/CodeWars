using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Kata.Classes.AFunctionalDeckOfCards;

namespace Kata.Classes
{
    /// <summary>
    /// Build a deck of playing cards by generating 52 strings representing cards. There are no jokers.
    /// Each card string will have the format of:
    /// "ace of hearts"
    /// </summary>
    public static class AFunctionalDeckOfCards
    {
        public static class DeckOfCards
        {
            public static string[] BuildDeck() =>
                new List<string>() { "clubs", "diamonds", "hearts", "spades" }
                    .SelectMany(s => new List<string>() { "ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king" }
                        .Select(r => $"{r} of {s}"))
                    .ToArray();
        }
    }

    [TestFixture]
    public class DeckOfCardsSolutionTest
    {
        private enum Suit { hearts, diamonds, spades, clubs }
        private enum Ranks { ace, two, three, four, five, six, seven, eight, nine, ten, jack, queen, king }
        private static string[] BuildDeck()
        {
            return Enum.GetNames(typeof(Ranks)).Select(x => Enum.GetNames(typeof(Suit)).Select(z => $"{x} of {z}")).SelectMany(x => x).ToArray();
        }

        [Test]
        public void CheckCards()
        {
            string[] deck = DeckOfCards.BuildDeck().OrderBy(s => s).ToArray();
            Assert.AreEqual(expected: deck.Length, actual: 52, message: "Your deck should have 52 cards");
            string[] myDeck = DeckOfCardsSolutionTest.BuildDeck().OrderBy(s => s).ToArray();
            Assert.AreEqual(myDeck, deck, "Your deck should contain all 52 cards");
        }
    }
}