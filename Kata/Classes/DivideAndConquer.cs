using System;
using System.Linq;

namespace Kata.Classes
{
    internal class DivideAndConquer
    {
        public static int DivCon(Object[] objArray) =>
            objArray.Select(obj => obj is string str ? -int.Parse(str) : (int)obj).Sum();
    }
}