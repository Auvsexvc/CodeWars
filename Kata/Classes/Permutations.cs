using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// In this kata you have to create all permutations of a non empty input string and remove duplicates, if present. This means, you have to shuffle all letters from the input in all possible orders.
    /// </summary>
    internal class Permutations
    {
        public static List<string> SinglePermutations(string set) =>
            set.Length == 1
                ? new List<string> { set }
                : set.SelectMany(c => SinglePermutations(set.Remove(set.IndexOf(c), 1)).Select(t => c.ToString() + t)).Distinct().ToList();
    }
}