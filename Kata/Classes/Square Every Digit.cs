using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Welcome. In this kata, you are asked to square every digit of a number and concatenate them.
    /// For example, if we run 9119 through the function, 811181 will come out, because 92 is 81 and 12 is 1.
    /// Note: The function accepts an integer and returns an integer
    /// </summary>
    internal class Square_Every_Digit
    {
        public static int SquareDigits(int n) =>
            int.Parse(string.Join("", n.ToString().Select(c => Math.Pow(char.GetNumericValue(c), 2))));
    }
}