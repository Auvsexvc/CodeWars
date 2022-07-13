using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class CapitalizationAndMutability
    {
        public static string CapitalizeWord(string word)
        {
            return string.Join("", word.Select((c, i) => i == 0 ? char.ToUpper(c) : c));
        }

    }
}
