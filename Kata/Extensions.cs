using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public static class Extensions
    {
        public static char[] PermuteNTimes(this char[] str, int n)
        {
            int i = 1;
            do
            {
                if (i == n)
                    break;

                i++;
            } while (NextPermutation(str));

            return str;
        }

        public static int Factorial(this int f)
        {
            if (f == 0)
                return 1;
            else
                return f * (f - 1).Factorial();
        }

        private static bool NextPermutation(char[] p)
        {
            for (int a = p.Length - 2; a >= 0; --a)
            {
                if (p[a] < p[a + 1])
                {
                    for (int b = p.Length - 1; ; --b)
                    {
                        if (p[b] > p[a])
                        {
                            char t = p[a];
                            p[a] = p[b];
                            p[b] = t;
                            for (++a, b = p.Length - 1; a < b; ++a, --b)
                            {
                                t = p[a];
                                p[a] = p[b];
                                p[b] = t;
                            }
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
