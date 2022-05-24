using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Simple, remove the spaces from the string, then return the resultant string.
    /// </summary>
    internal class Remove_String_Spaces
    {
        public static class SpacesRemover
        {
            public static string NoSpace(string input) =>
                String.Join("", input.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToList());
        }
    }
}