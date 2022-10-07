using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Here's another staple for the functional programmer. You have a sequence of values and some predicate for those values. You want to get the longest prefix of elements such that the predicate is true for each element. We'll call this the takeWhile function. It accepts two arguments. The first is the sequence of values, and the second is the predicate function. The function does not change the value of the original sequence.
    /// </summary>
    internal class The_takeWhile_Function
    {
        public static int[] TakeWhile(int[] arr, Func<int, bool> pred)
        {
            List<int> list = new List<int>();
            foreach (var item in arr)
            {
                if (!pred(item)) break;
                list.Add(item);
            }
            return list.ToArray();
        }
    }
}
