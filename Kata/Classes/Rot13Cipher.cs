using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// ROT13 is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in the alphabet. ROT13 is an example of the Caesar cipher.
    /// Create a function that takes a string and returns the string ciphered with Rot13.If there are numbers or special characters included in the string, they should be returned as they are. Only letters from the latin/english alphabet should be shifted, like in the original Rot13 "implementation".
    /// test - grfg, Test - Grfg etc
    /// </summary>

    internal static class Rot13Cipher
    {
        public static string Rot13(string message)
        {
            const int Rot13 = 13;
            foreach (char symbol in message)
            {
                if (char.IsLetter(symbol))
                {
                    int charToInt = 0;
                    if (char.ToUpper(symbol) + Rot13 > char.ToUpper('Z'))
                        charToInt -= (char.ToUpper('Z') - char.ToUpper('A')) + 1;

                    if (char.IsLower(symbol))
                        message += char.ToLower((char)(charToInt + char.ToUpper(symbol) + Rot13));
                    else message += (char)(charToInt + symbol + Rot13);
                }
                else message += symbol;
            }
            return message.Substring(message.Length / 2);
        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++
        // Other Katas
        public static string Rot13Linq(string message)
        {
            return String.Join("", message.Select(x => char.IsLetter(x) ? (x >= 65 && x <= 77) || (x >= 97 && x <= 109) ? (char)(x + 13) : (char)(x - 13) : x));
        }

        public static string Rot13Linq2(string message)
        {
            return string.Concat(message.Select(c => char.IsLetter(c) ? (char)(c + (char.ToLower(c) > 'm' ? -13 : 13)) : c));
        }
    }
}