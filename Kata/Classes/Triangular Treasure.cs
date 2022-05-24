using System.Linq;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// Triangular numbers are so called because of the equilateral triangular shape that they occupy when laid out as dots.
    /// You need to return the nth triangular number. You should return 0 for out of range values.
    /// </summary>
    internal class Triangular_Treasure
    {
        public static int Triangular(int n) => n > 0 ? Enumerable.Range(1, n).Sum() : 0;
    }
}