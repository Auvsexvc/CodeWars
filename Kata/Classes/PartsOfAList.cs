using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    internal class PartsOfAList
    {
        public static string[][] Partlist(string[] arr) =>
            Enumerable
                .Range(1, arr.Length - 1)
                .Select(i => new string[2]
                {
                    string.Join(" ", arr.Take(i)),
                    string.Join(" ", arr.Skip(i))
                })
                .ToArray();
    }
}