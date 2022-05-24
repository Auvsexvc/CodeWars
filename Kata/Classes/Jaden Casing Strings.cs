using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Kata.Classes
{
    /// <summary>
    /// Your task is to convert strings to how they would be written by Jaden Smith.
    /// The strings are actual quotes from Jaden Smith, but they are not capitalized in the same way he originally typed them.
    /// </summary>
    internal static class Jaden_Casing_Strings
    {
        public static string ToJadenCase(string phrase)
        {
            StringBuilder sbPhrase = new StringBuilder(phrase);
            var arr = phrase.ToCharArray().Prepend(' ')
                  .Select((c, index) => new { CharAtIndex = c, Idx = index })
                  .Where(indexedList => Char.IsWhiteSpace(indexedList.CharAtIndex))
                  .Select(selected => selected.Idx)
                  .Select(idx => sbPhrase[idx] = char.ToUpper(sbPhrase[idx]))
                  .ToArray();
            return sbPhrase.ToString();
        }

        public static string ToJadenCaseTrick(this string phrase)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
        }
    }
}