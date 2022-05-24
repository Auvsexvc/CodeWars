using System.Text.RegularExpressions;

namespace Kata.Classes
{
    /// <summary>
    /// The look and say sequence is a sequence in which each number is the result of a "look and say" operation on the previous element.
    /// Considering for example the classical version startin with "1": ["1", "11", "21, "1211", "111221", ...]. You can see that the second element describes the first as "1(times number)1", the third is "2(times number)1" describing the second, the fourth is "1(times number)2(and)1(times number)1" and so on.
    /// Your goal is to create a function which takes a starting string (not necessarily the classical "1", much less a single character start) and return the nth element of the series.
    /// </summary>
    internal class Look_and_say_sequence_generator
    {
        public static string LookAndSaySequence(string firstElement, long n) =>
            n == 1
            ? firstElement
            : Regex.Replace(LookAndSaySequence(firstElement, n - 1), @"(\w)\1*", x => $"{x.Length}{x.Groups[1]}");

        public static string LookAndSaySequence1(string firstElement, long n)
        {
            if (n == 1) return firstElement;

            string retStr = firstElement;

            for (int i = 2; i <= n; i++)
            {
                retStr += '$';
                int charCounter = 1;
                string tmpStr = string.Empty;
                for (int j = 1; j < retStr.Length; j++)
                {
                    if (retStr[j] != retStr[j - 1])
                    {
                        tmpStr += charCounter + 0;
                        tmpStr += retStr[j - 1];
                        charCounter = 1;
                    }
                    else charCounter++;
                }
                retStr = tmpStr;
            }

            return retStr;
        }


    }
}