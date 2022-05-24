using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Common denominators
    /// You will have a list of rationals in the form
    ///   { { numer_1, denom_1} , ... { numer_n, denom_n} }
    ///   or
    ///    [[numer_1, denom_1] , ... [numer_n, denom_n] ]
    ///or
    ///[(numer_1, denom_1), ... (numer_n, denom_n)]
    ///where all numbers are positive ints.You have to produce a result in the form:
    ///(N_1, D) ... (N_n, D)
    ///or
    ///[[N_1, D] ... [N_n, D] ]
    ///or
    ///[(N_1', D) , ... (N_n, D) ]
    ///or
    ///{{N_1, D
    ///}
    ///... { N_n, D}}
    ///or
    ///"(N_1, D) ... (N_n, D)"
    ///depending on the language (See Example tests) in which D is as small as possible and
    ///N_1/D == numer_1/denom_1 ... N_n/D == numer_n,/denom_n.
    ///Example:
    ///convertFracs[(1, 2), (1, 3), (1, 4)] `shouldBe` [(6, 12), (4, 12), (3, 12)]
    ///Note:
    ///Due to the fact that the first translations were written long ago - more than 6 years - these first translations have only irreducible fractions.
    ///Newer translations have some reducible fractions. To be on the safe side it is better to do a bit more work by simplifying fractions even if they don't have to be.
    /// </summary>
    internal class Common_Denominators
    {
        public static string convertFrac(long[,] lst)
        {
            List<long> plainLst = new List<long>();
            long lcd = 1;

            if (lst.LongLength == 0)
                return string.Empty;

            for (int row = 0; row < lst.GetLength(0); row++)
                for (int col = 0; col < lst.GetLength(1); col++)
                    plainLst.Add(lst[row, col]);

            return string
                .Join("", plainLst
                    .Where((x, i) => i % 2 != 0)
                    .ToList()
                    .Select((v, i) => string
                        .Join("(", "", (plainLst
                            .Where((x, i) => i % 2 == 0)
                            .ToList()
                            .ElementAt(i) * plainLst
                            .Where((x, i) => i % 2 != 0)
                            .ToList()
                            .Select(d => Lcm(lcd, d) > lcd ? lcd = Lcm(lcd, d) : lcd)
                            .Select(l => l)
                            .Max() / v)
                            .ToString() + "," + lcd + ")"
                            )
                        )
                    );
        }

        private static long Gcf(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static long Lcm(long a, long b)
        {
            return (a / Gcf(a, b)) * b;
        }
    }
}