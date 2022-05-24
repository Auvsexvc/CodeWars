using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes.Unfinished
{
    internal class Roman_Numerals_Helper
    {
        public class RomanNumerals
        {
            private static Dictionary<int, string> rDict = new Dictionary<int, string>
                {
                    {1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"},
                    {100, "C"}, {90, "XC"}, {50, "L"}, {40, "XL"},
                    {10, "X"}, {9, "IX"}, {5, "V"}, {4, "IV"}, {1, "I"}
                };

            public static string ToRoman(int n) =>
                rDict
                    .Where(p => n >= p.Key)
                    .Select(p => p.Value + ToRoman(n - p.Key))
                    .FirstOrDefault();

            public static int FromRoman(string romanNumeral)
            {
                var arr = romanNumeral
                    .Select(s => rDict
                        .Where(d => d.Value == s.ToString())
                        .Select(d => d.Key)
                        .FirstOrDefault())
                    .Reverse()
                    .ToArray();

                for (int i = 1; i < arr.Length; i++)
                    if (arr[i] < arr[i - 1])
                        arr[i] = -arr[i];

                return arr.Aggregate((a, b) => a + b);
            }
        }
    }
}