using System.Linq;

namespace Kata.Classes
{
    internal class Highest_Scoring_Word
    {
        /// <summary>
        /// Given a string of words, you need to find the highest scoring word.
        /// Each letter of a word scores points according to its position in the alphabet: a = 1, b = 2, c = 3 etc.
        /// You need to return the highest scoring word as a string.
        /// If two words score the same, return the word that appears earliest in the original string.
        /// All letters will be lowercase and all inputs will be valid.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string High(string s)
        {
            return s.Split(new char[] { ' ', ',', '.', ':', '\t' }).
                Aggregate((c, t) =>
                {
                    return c.Select((w, i) => c.Select(v => (int)char.ToLower(v) - (int)'a' + 1).Sum() < t.Select(v => (int)char.ToLower(v) - (int)'a' + 1).Sum() ? c = t : c)
                            .LastOrDefault();
                });
        }
    }
}