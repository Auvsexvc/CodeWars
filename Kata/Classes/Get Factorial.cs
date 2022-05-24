using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class Get_Factorial
    {
        public static int GetFactorial(int number) =>
            number == 0 ? 1 : number * GetFactorial(number - 1);
    }
}
