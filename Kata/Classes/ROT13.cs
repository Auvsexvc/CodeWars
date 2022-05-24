using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// How can you tell an extrovert from an introvert at NSA? Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.
    /// I found this joke on USENET, but the punchline is scrambled. Maybe you can decipher it? According to Wikipedia,
    /// ROT13 (http://en.wikipedia.org/wiki/ROT13) is frequently used to obfuscate jokes on USENET.
    /// Hint: For this task you're only supposed to substitue characters. Not spaces, punctuation, numbers etc.
    /// </summary>
    internal class ROT13
    {
        public static string Rot13(string input) =>
            string.Concat(input.Select(c => char.IsLetter(c) ? (char)(c + (char.ToLower(c) > 'm' ? -13 : 13)) : c));
    }
}