using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Given an array of integers your solution should find the smallest integer.
    /// You can assume, for the purpose of this kata, that the supplied array will not be empty.
    /// </summary>
    internal class FindSmallestInt
    {
        public static int FSInt(int[] args) => args.Min();
    }
}