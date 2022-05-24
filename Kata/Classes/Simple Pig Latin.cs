using System;
using System.Linq;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.
    /// </summary>
    internal class Simple_Pig_Latin
    {
        public static string PigIt(string str) =>
            String.Join(" ", str.Split(' ').Select(s => s.Length>1 && char.IsPunctuation(s[0]) ? s.Substring(1) + s[0].ToString() + "ay" : s).ToArray());
    }
}