using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// A startup office has an ongoing problem with its bin. Due to low budgets, they don't hire cleaners. As a result, the staff are left to voluntarily empty the bin. It has emerged that a voluntary system is not working and the bin is often overflowing. One staff member has suggested creating a rota system based upon the staff seating plan.
    /// Create a function binRota that accepts a 2D array of names. The function will return a single array containing staff names in the order that they should empty the bin.\
    /// Adding to the problem, the office has some temporary staff. This means that the seating plan changes every month. Both staff members' names and the number of rows of seats may change. Ensure that the function binRota works when tested with these changes.
    /// Notes:
    ///    All the rows will always be the same length as each other.
    ///    There will be no empty spaces in the seating plan.
    ///    There will be no empty arrays.
    /// Each row will be at least one seat long.
    /// </summary>
    internal class The_Lazy_Startup_Office
    {
        public static string[] BinRota(string[][] input)
        {
            List<string> rota = new List<string>();
            for (int row = 0; row < input.Length; row++)
            {
                if (row % 2 == 0)
                    for (int i = 0; i < input[row].Length; i++)
                        rota.Add(input[row][i]);
                else
                    for (int i = input[row].Length - 1; i >= 0; i--)
                        rota.Add(input[row][i]);
            }
            return rota.ToArray();
        }

        public static string[] BinRotaLinq(string[][] input)
        {
            return input.SelectMany((e, i) => i % 2 == 0 ? e : e.Reverse()).ToArray();
        }
    }
}