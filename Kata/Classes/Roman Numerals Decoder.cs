using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class Roman_Numerals_Decoder
    {
        /// <summary>
        /// Create a function that takes a Roman numeral as its argument and returns its value as a numeric decimal integer. You don't need to validate the form of the Roman numeral.
        /// Modern Roman numerals are written by expressing each decimal digit of the number to be encoded separately, starting with the leftmost digit and skipping any 0s. 
        /// So 1990 is rendered "MCMXC" (1000 = M, 900 = CM, 90 = XC) and 2008 is rendered "MMVIII" (2000 = MM, 8 = VIII). The Roman numeral for 1666, "MDCLXVI", uses each letter in descending order.
        /// </summary>
        public class RomanDecode
        {
            public static int Solution(string roman)
            {
                Dictionary<int, string> rDict = new Dictionary<int, string>
                {
                    {1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"},
                    {100, "C"}, {90, "XC"}, {50, "L"}, {40, "XL"},
                    {10, "X"}, {9, "IX"}, {5, "V"}, {4, "IV"}, {1, "I"}
                };

                var arr = roman
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
