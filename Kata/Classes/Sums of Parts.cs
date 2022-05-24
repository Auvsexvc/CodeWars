using System.Linq;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// The function parts_sums (or its variants in other languages) will take as parameter a list ls and return a list of the sums of its parts.
    /// </summary>
    internal class Sums_of_Parts
    {
        public static int[] PartsSums(int[] ls) =>
            ls.Reverse().Aggregate(Enumerable.Repeat(0, 1), (a, i) => a.Prepend(a.First() + i)).ToArray();

        //{
        //    int[] arr = new int[ls.Length + 1];
        //    for (int i = 0; i <= ls.Length; i++)
        //        arr[i] = i > 0 ? arr[i - 1] - ls[i - 1] : ls.Sum();
        //    return arr;
        //}
    }
}