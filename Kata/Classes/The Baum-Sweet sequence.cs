using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    /// <summary>
    /// Wikipedia: The Baum–Sweet sequence is an infinite automatic sequence of 0s and 1s defined by the rule:

    /// bn = 1 if the binary representation of n contains no block of consecutive 0s of odd length;
    ///     bn = 0 otherwise;

    /// for n ≥ 0.

    /// Define an iterator BaumSweet that sequentially generates the values of this sequence.
    /// It will be tested for up to 1 000 000 values.
    /// Note that the binary representation of 0 used here is not 0 but the empty string (which does not contain any blocks of consecutive 0s ).
    /// </summary>
    internal class The_Baum_Sweet_sequence
    {
        public static IEnumerable<int> BaumSweet()
        {
            yield return 1;
            var n = 1;
            var r = new Regex("0+");
            while (true)
            {
                var m = r.Matches(Convert.ToString(n, 2)).Cast<Match>().ToArray();
                if (m.Any(_ => (_.Length & 1) != 0))
                    yield return 0;
                else
                    yield return 1;
                n += 1;
            }
        }
    }
}