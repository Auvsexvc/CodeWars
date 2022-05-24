using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    /// <summary>
    /// Write a function that takes a single string (word) as argument. The function must return an ordered list containing the indexes of all capital letters in the string.
    /// </summary>
    public static class Find_the_capitals
    {
        public static int[] Capitals(string word)
        {
            List<int> retList = new List<int>();

            for (int i = 0; i < word.Length; i++)
                if (char.IsUpper(word[i]) && char.IsLetter(word[i]))
                    retList.Add(i);

            return retList.ToArray();
        }

        public static int[] CapitalsRegex(string word)
        {
            return Regex.Matches(word, "[A-Z]").Select(m => m.Index).ToArray();
        }

        public static int[] CapitalsLinq(string word)
        {
            return word.ToCharArray()
                  .Select((c, index) => new { CharAtIndex = c, Idx = index })  // Select word and project to array "char with Index"
                  .Where(indexedList => Char.IsUpper(indexedList.CharAtIndex))   // Filter where char is upp
                  .Select(selected => selected.Idx) // return what is required: list of indices
                  .ToArray();
        }

        public static int[] CapitalsEnum(string word)
        {
            return Enumerable.Range(0, word.Length).Where(i => char.IsUpper(word, i)).ToArray();
        }
    }
}