using System;
using System.Linq;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// In this task, you need to restore a string from a list of its copies.
    /// You will receive an array of strings. All of them are supposed to be the same as the original but, unfortunately, they were corrupted which means some of the characters were replaced with asterisks ("*").
    /// You have to restore the original string based on non-corrupted information you have. If in some cases it is not possible to determine what the original character was, use "#" character as a special marker for that.
    /// If the array is empty, then return an empty string.
    /// </summary>
    internal class Assemble_string
    {
        public static string Assemble(string[] copies)
        {
            string retString = string.Empty;
            if (!copies.Any()) return retString;
            for (int i = 0; i < copies.FirstOrDefault().Length; i++)
                for (int j = 0; j < copies.Length; j++)
                {
                    if (copies[j][i] != '*')
                    {
                        retString += copies[j][i];
                        break;
                    }
                    if (j == copies.Length - 1) retString += '#';
                }

            return retString;
        }

        public static string Assemble2(string[] arr)
        {

            if (arr.Length == 0) return String.Empty;

            var result = Enumerable.Range(0, arr[0].Length)
                                   .Select(i => arr[0][i] != '*'
                                                ? arr[0][i] : arr[1][i] != '*'
                                                ? arr[1][i] : arr[2][i] != '*'
                                                ? arr[2][i] : '#');
            return String.Concat(result);
        }
    }
}