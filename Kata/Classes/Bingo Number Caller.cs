using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
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
    internal class Bingo_Number_Caller
    {
        public class BingoCaller
        {
            private Random _random;
            private int _number;
            private bool[] list = new bool[75];

            public BingoCaller(Random random)
            {
                _random = random;
            }

            public string GetNumber()
            {
                
                if(list.All(x => x))
                    return String.Empty;
                do
                {
                    _number = _random.Next(1, 76);
                }
                while (list[_number - 1]);
                list[_number-1] = true;

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