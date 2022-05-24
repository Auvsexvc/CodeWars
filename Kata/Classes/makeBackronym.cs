using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Complete the function to create backronyms. Transform the given string (without spaces) to a backronym,
    /// using the preloaded dictionary and return a string of words, separated with a single space (but no trailing spaces).
    /// The keys of the preloaded dictionary are uppercase letters A-Z and the values are predetermined words
    /// </summary>
    internal class makeBackronym
    {
        private static Dictionary<char, string> dict = new Dictionary<char, string>(); //dummy ;-)

        public static string MakeBackronym(string s) =>
            String.Join(" ", s.Select(c => dict[char.ToUpper(c)]));
    }
}