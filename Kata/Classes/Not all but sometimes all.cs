using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Write a method that takes in a string str(text in Python) and an object/hash/dict/Dictionary what and returns a string with the chars removed in what .
    /// </summary>
    internal class Not_all_but_sometimes_all
    {
        public static string Remove(string str, Dictionary<char, int> what)
        {
            foreach (var d in what)
                for (int i = 0; i < d.Value && str.Contains(d.Key); i++)
                    str = str.Remove(str.ToList().FindIndex(s => s == d.Key), 1);
            return str;
        }
    }
}
