using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Return the number (count) of vowels in the given string.
    /// We will consider a, e, i, o, u as vowels for this Kata (but not y).
    /// The input string will only consist of lower case letters and/or spaces.
    /// </summary>
    internal class Vowel_Count
    {
        public static int GetVowelCount(string str) =>
            str.Where((c, i) => new char[] { 'a', 'e', 'i', 'o', 'u' }.Contains(char.ToLower(c))).Count();
       
    }
}
