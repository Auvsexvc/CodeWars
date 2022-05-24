using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    /// <summary>
    /// Complete the solution so that it strips all text that follows any of a set of comment markers passed in.
    /// Any whitespace at the end of the line should also be stripped out.
    /// </summary>
    public class StripCommentsSolution
    {
        public static string StripComments(string text, string[] commentSymbols) =>
            String.Join("", Regex.Split(text, @"(?=\n)").Select(splitText => String.Concat(splitText.TakeWhile(c => !commentSymbols.ToList().Contains(c.ToString()))).TrimEnd(' ')));
    }
}