using System;
using System.Linq;

namespace Kata.Classes
{
    internal class CharCodeCalculation
    {
        public static Int32 Calc(string s, int numberToReplaceWithOne = 7) =>
            string.Join("", s.Select(c => (int)c)).Select(c => int.Parse(c.ToString())).Count(x => x == 7) * (numberToReplaceWithOne - 1);
    }
}