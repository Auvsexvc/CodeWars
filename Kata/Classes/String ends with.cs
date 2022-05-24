using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Complete the solution so that it returns true if the first argument(string) passed in ends with the 2nd argument (also a string).
    /// </summary>
    internal class String_ends_with
    {
        public static bool Solution(string str, string ending) =>
            str.EndsWith(ending);
    
    }
}
