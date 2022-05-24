using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Write a function that calculates the least common multiple of its arguments; 
    /// each argument is assumed to be a non-negative integer. 
    /// In the case that there are no arguments (or the provided array in compiled languages is empty), return 1.
    /// </summary>
    internal class Least_Common_Multiple
    {
        public static int Lcm(List<int> nums) =>
            nums.Count!=0 ? nums.Aggregate((a, b) => Lcm(a,b)) : 1;

        private static int Lcm(int a, int b) =>
            (a / Gcf(a, b)) * b;

        private static int Gcf(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
