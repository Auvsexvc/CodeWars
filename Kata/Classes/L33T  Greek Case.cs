using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Getting Familiar: LEET: (sometimes written as "1337" or "l33t"), also known as eleet or leetspeak, is another alphabet for the English language that is used mostly on the internet. It uses various combinations of ASCII characters to replace Latinate letters. For example, leet spellings of the word leet include 1337 and l33t; eleet may be spelled 31337 or 3l33t.
    /// GREEK: The Greek alphabet has been used to write the Greek language since the 8th century BC. It was derived from the earlier Phoenician alphabet, and was the first alphabetic script to have distinct letters for vowels as well as consonants. It is the ancestor of the Latin and Cyrillic scripts.Apart from its use in writing the Greek language, both in its ancient and its modern forms, the Greek alphabet today also serves as a source of technical symbols and labels in many domains of mathematics, science and other fields.
    /// You have to create a function **GrεεκL33t** which
    ///takes a string as input and returns it in the form of
    ///(L33T+Grεεκ)Case.
    ///Note: The letters which are not being converted in
    ///(L33T+Grεεκ)Case should be returned in the lowercase.
    /// </summary>
    internal class L33T__Greek_Case
    {
        public class L33TGreekCase
        {
            private static readonly Dictionary<string, string> greekAlpha = new Dictionary<string, string>()
            {
                { "A","α" },{ "B" , "β" },{ "D" , "δ"},{ "E" , "ε" },{ "I" , "ι" },{ "K" , "κ" },{ "N" , "η" },{ "O" , "θ" },{ "P" , "ρ" },{ "R" , "π" },{ "T" , "τ" },{ "U" , "μ" },{ "V" , "υ"},{ "W" , "ω" },{ "X" , "χ" },{ "Y" , "γ" }
            };

            public static string GreekL33t(string str) =>
                string.Join("", str
                    .Select(c => greekAlpha
                        .ContainsKey(char.ToUpper(c).ToString())
                        ? greekAlpha.FirstOrDefault(d => d.Key == char.ToUpper(c).ToString()).Value
                        : char.ToLower(c).ToString())
                    .ToList());
        }
    }
}