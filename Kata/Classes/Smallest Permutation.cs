using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Given a number, find the permutation with the smallest absolute value (no leading zeros).
    /// </summary>
    public class Smallest_Permutation
    {
        public static int MinPermutation(int n) =>
            n < 0
                ? Int32.Parse("-" + Permutations(n.ToString().Remove(0, 1)).Where(f => f.Length == n.ToString().Remove(0, 1).Length && !f.StartsWith('0')).Min())
                : ((n == 0) ? 0 : Int32.Parse(Permutations(n.ToString()).Where(f => f.Length == n.ToString().Length && !f.StartsWith('0')).Min()));

        private static List<string> Permutations(string set) =>
            set.Length == 1
                ? new List<string> { set }
                : set.SelectMany(c => Permutations(set.Remove(set.IndexOf(c), 1)).Select(t => c.ToString() + t)).ToList();

    }
}