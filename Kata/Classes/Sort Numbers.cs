using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Finish the solution so that it sorts the passed in array of numbers. If the function passes in an empty array or null/nil value then it should return an empty array.
    /// </summary>
    internal class Sort_Numbers
    {
        public static int[] SortNumbers(int[] nums) =>
            nums?.ToList().OrderBy(x => x).ToArray() ?? new int[0];
    }
}