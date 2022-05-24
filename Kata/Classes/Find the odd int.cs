using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Given an array of integers, find the one that appears an odd number of times.
    /// There will always be only one integer that appears an odd number of times.
    /// </summary>
    internal class Find_the_odd_int
    {
        public static int find_it(int[] seq) =>
            seq.Distinct().Where(dsv => seq.Where(sv => sv == dsv).Count() % 2 != 0).FirstOrDefault();
    }
}