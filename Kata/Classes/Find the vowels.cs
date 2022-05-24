using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// We want to know the index of the vowels in a given word, for example, there are two vowels in the word super (the second and fourth letters).
    /// </summary>
    internal class Find_the_vowels
    {
        public static int[] VowelIndices(string word) =>
            word.Select((c, i) => new char[] { 'a', 'e', 'i', 'o', 'u', 'y' }.Contains(char.ToLower(c)) ? i + 1 : 0).Where(i=> i>0).ToArray();
}
}
