using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Create a function that takes an integer as an argument and returns "Even" for even numbers or "Odd" for odd numbers.
    /// </summary>
    internal class Even_Or_Odd
    {
        public static string EvenOrOdd(int number) => (number % 2).Equals(0) ? "Even" : "Odd";
    }
}
