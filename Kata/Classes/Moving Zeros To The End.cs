using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.
    /// </summary>
    internal class Moving_Zeros_To_The_End
    {
        public static int[] MoveZeroes(int[] arr) =>
            arr.Where(x => x != 0).Concat(arr.Where(x => x == 0)).ToArray();
    }
}
