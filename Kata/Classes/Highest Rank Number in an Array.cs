using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Complete the method which returns the number which is most frequent in the given input array. If there is a tie for most frequent number, return the largest number among them.
    /// Note: no empty arrays will be given.
    /// </summary>
    internal class Highest_Rank_Number_in_an_Array
    {
        public static int HighestRank(int[] arr) =>
            arr.OrderByDescending(i => i).GroupBy(i => i).OrderByDescending(g => g.Count()).Select(g=>g.Key).FirstOrDefault();
        
    }
}