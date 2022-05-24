using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    
    /// <summary>
    /// Create an extension method IsUpperCase to see whether the string is ALL CAPS.
    /// In this Kata, a string is said to be in ALL CAPS whenever it does not contain any lowercase letter so any string containing no letters at all is trivially considered to be in ALL CAPS.
    /// </summary>

    public static class StringExtensions
    {
        public static bool IsUpperCase(this string text) =>
            text.Where(c => char.IsLetter(c)).All(c => char.IsUpper(c));
    }
}
