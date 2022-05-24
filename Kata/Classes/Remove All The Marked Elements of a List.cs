using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Define a method/function that removes from a given array of integers all the values contained in a second array.
    /// </summary>
    internal class Remove_All_The_Marked_Elements_of_a_List
    {
        public static int[] Remove(int[] integerList, int[] valuesList) =>
            integerList.Where(v => !valuesList.Contains(v)).ToArray();
    }
}
