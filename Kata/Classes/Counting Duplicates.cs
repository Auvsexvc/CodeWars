using System.Linq;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string. The input string can be assumed to contain only alphabets (both uppercase and lowercase) and numeric digits.
    /// </summary>
    internal class Counting_Duplicates
    {
        public static int DuplicateCount(string str) =>
            str.ToUpper().Distinct().Where(c => str.ToList().RemoveAll(x => char.ToUpper(x) == c) > 1).Count();

        public static int DuplicateCount2(string str)
        {
            return str.ToLower().GroupBy(c => c).Where(g => g.Count() > 1).Count();
        }
    }
}