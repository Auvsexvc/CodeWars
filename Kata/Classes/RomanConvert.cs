using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    /// <summary>
    /// Create a function taking a positive integer as its parameter and returning a string containing the Roman Numeral representation of that integer.
    /// Modern Roman numerals are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero.
    /// In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.
    /// </summary>
    internal class RomanConvert
    {
        public static string Solution(int n)
        {
            string result = "";
            List<string> arabicComponents = new List<string>();
            Dictionary<int, string> romanDict = new Dictionary<int, string> { { 1, "I" }, { 5, "V" }, { 10, "X" }, { 50, "L" }, { 100, "C" }, { 500, "D" }, { 1000, "M" } };

            for (int i = 0; i < n.ToString().Length; i++)
            {
                arabicComponents.Add(n.ToString()[i].ToString());
                for (int j = n.ToString().Length - i - 1; j > 0; j--) arabicComponents[i] = string.Concat(arabicComponents[i], "0");
            }
            for (int i = 0; i < arabicComponents.Count; i++)
            {
                int multiplier = 1;
                if ((int)Math.Pow(10, arabicComponents.Count - i - 1) < Int32.Parse(arabicComponents[i])) multiplier = Int32.Parse(arabicComponents[i]) / (int)Math.Pow(10, arabicComponents.Count - i - 1);

                foreach (var element in romanDict)
                {
                    if (Int32.Parse(arabicComponents[i]) / multiplier == element.Key)
                    {
                        int multiplierRest = multiplier;
                        if (multiplier >= 9)
                        {
                            result += romanDict[element.Key];
                            multiplierRest = multiplier - 5;
                            result += romanDict[element.Key * 10];
                        }
                        else if (multiplier >= 5 && multiplier <= 8)
                        {
                            result += romanDict[element.Key * 5];
                            multiplierRest = multiplier - 5;
                            while (multiplierRest >= 1 && multiplierRest <= 3)
                            {
                                result += element.Value;
                                multiplierRest--;
                            }
                        }
                        else if (multiplier == 4)
                        {
                            result += romanDict[element.Key];
                            result += romanDict[element.Key * 5];
                        }
                        while (multiplierRest >= 1 && multiplierRest <= 3)
                        {
                            result += element.Value;
                            multiplierRest--;
                        }
                    }
                }
            }
            return result;
        }

        public static string SolutionLinq(int n)
        {
            return new Dictionary<int, string>
            {
                {1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"},
                {100, "C"}, {90, "XC"}, {50, "L"}, {40, "XL"},
                {10, "X"}, {9, "IX"}, {5, "V"}, {4, "IV"}, {1, "I"}
            }
                .Where(p => n >= p.Key)
                .Select(p => p.Value + SolutionLinq(n - p.Key))
                .FirstOrDefault();
        }
    }
}