using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Deoxyribonucleic acid (DNA) is a chemical found in the nucleus of cells and carries the "instructions" for the development and functioning of living organisms.
    /// If you want to know more: http://en.wikipedia.org/wiki/DNA
    /// In DNA strings, symbols "A" and "T" are complements of each other, as "C" and "G". You function receives one side of the DNA(string, except for Haskell); you need to return the other complementary side.DNA strand is never empty or there is no DNA at all (again, except for Haskell).
    /// </summary>
    public static class Complementary_DNA
    {
        public static string MakeComplement(string dna)
        {
            foreach (var symbol in new Dictionary<char, char> { { 'A', 'T' }, { 'C', 'G' } })
                dna = dna.Replace(symbol.Key, char.ToLower(symbol.Value)).Replace(symbol.Value, char.ToLower(symbol.Key));
            return dna.ToUpper();
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Other Kata Solutions
        public static string MakeComplementArtoria(string dna)
        {
            return String.Join("",
                   from ch in dna
                   select "AGCT"["TCGA".IndexOf(ch)]
                  );
        }

        public static string MakeComplement2(string dna)
        {
            return string.Concat(dna.Select(GetComplement));
        }

        public static char GetComplement(char symbol)
        {
            switch (symbol)
            {
                case 'A':
                    return 'T';

                case 'T':
                    return 'A';

                case 'C':
                    return 'G';

                case 'G':
                    return 'C';

                default:
                    throw new ArgumentException();
            }
        }
    }
}