using System;
using System.Linq;

namespace Kata.Classes
{
    //Write a function, factory, that takes a number as its parameter and returns another function.
    //The returned function should take an array of numbers as its parameter, and return an array of those numbers multiplied by the number that was passed into the first function.
    //In the example below, 5 is the number passed into the first function.So it returns a function that takes an array and multiplies all elements in it by five.

    internal class FirstClassFunctionFactory
    {
        public static Func<int[], int[]> Factory(int x)
        {
            return f => f.Select(d => d * x).ToArray();
        }
    }
}