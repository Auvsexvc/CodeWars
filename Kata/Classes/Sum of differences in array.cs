using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Your task is to sum the differences between consecutive pairs in the array in descending order.
    /// If the array is empty or the array has only one element the result should be 0 ( Nothing in Haskell ).
    /// </summary>
    internal class Sum_of_differences_in_array
    {
        public static int SumOfDifferences(int[] arr)
        {
            int sumOfDifferences = 0;

            Array.Sort(arr);
            Array.Reverse(arr);

            if (arr.Length > 1)
                for (int i = 1; i < arr.Length; i++)
                    sumOfDifferences += Math.Abs(arr[i] - arr[i - 1]);

            return sumOfDifferences;
        }
    }
}