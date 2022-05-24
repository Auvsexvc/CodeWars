using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:
    /// maxSequence[-2, 1, -3, 4, -1, 2, 1, -5, 4]
    /// -- should be 6: [4, -1, 2, 1]
    /// Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array.
    /// If the list is made up of only negative numbers, return 0 instead.
    /// Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.
    /// </summary>
    internal class Maximum_subarray_sum
    {
        public static List<int> maxRecordsList = new List<int>();
        public static List<int> arrClone = new List<int>();

        public static int MaxSequence(int[] arr)
        {
            if (arr.Count() > arrClone.Count())
                arrClone = arr.ToList();

            if (!arrClone.All(value => value > 0) ? arr.Count() >= 1 : false)
            {
                for (int i = 0; i < arr.Length; i++)
                    maxRecordsList.Add(arr.SkipLast(i).ToArray().Sum());

                return MaxSequence(arr.Skip(1).ToArray());
            }
            else if (arrClone.All(value => value > 0)) return 0;
            else maxRecordsList.Add(0);

            int result = maxRecordsList.Max();
            maxRecordsList.Clear();
            arrClone.Clear();
            return result;
        }

        public static int MaxSequence(List<int> list) =>
            MaxSequence(list.ToArray());

        public static int MaxSequenceAkozhanov(int[] arr)
        {
            return arr.Aggregate((0, 0), (t, c) =>
            {
                Console.WriteLine($"Math.Max(0, {t.Item1} + {c}) Math.Max({t.Item2}, {t.Item1} + {c})");
                Console.WriteLine($"{Math.Max(0, t.Item1 + c)} {Math.Max(t.Item2, t.Item1 + c)}");
                return (Math.Max(0, (t.Item1) + c), Math.Max(t.Item2, t.Item1 + c));
            }).Item2;
        }
    }
}