using System.Linq;

namespace Kata
{
    /// <summary>
    /// Can you find the needle in the haystack?
    /// Write a function findNeedle() that takes an array full of junk but containing one "needle"
    ///After your function finds the needle it should return a message(as a string) that says:
    ///"found the needle at position " plus the index it found the needle, so:
    ///find_needle(['hay', 'junk', 'hay', 'hay', 'moreJunk', 'needle', 'randomJunk'])
    ///should return "found the needle at position 5" (in COBOL "found the needle at position 6")
    /// </summary>
    public class A_Needle_in_the_Haystack
    {
        public static string FindNeedle(object[] haystack) =>
            string.Join($"found the needle at position ", haystack.Select((v, i) => i).FirstOrDefault(i => haystack.ElementAtOrDefault(i) is object && haystack.ElementAtOrDefault(i).ToString() == ("needle")));
    }
}