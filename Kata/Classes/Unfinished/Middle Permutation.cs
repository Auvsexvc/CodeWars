using System;
using System.Linq;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// You are given a string s. Every letter in s appears once.
    /// Consider all strings formed by rearranging the letters in s. After ordering these strings in dictionary order, return the middle term. (If the sequence has a even length n, define its middle term to be the (n/2)th term.)
    /// </summary>
    internal class Middle_Permutation
    {
        public static string MiddlePermutation(string s)
        {
            char[] str = s.ToCharArray();
            Array.Sort(str);
            string retString = string.Empty;
            int dividend = Factorial(s.Length) / 2 - 1;

            for (int i = 0; i < s.Length; i++)
            {
                int perms = Factorial(str.Length) / str.Length;
                if (str.Length == 1)
                {
                    retString += str[0];
                    break;
                }
                char letter = str[dividend / perms];
                retString += letter;
                str = str.Where(x => x != letter).ToArray();
                dividend -= perms * (dividend / perms);
            }
            Console.WriteLine(retString);
            return retString;

            //int n;

            //while (retString.Length < s.Length)
            //{
            //    if (str.Length % 2 == 0)
            //        n = str.Length / 2 -1;
            //    else
            //        n = str.Length / 2;
            //    retString += str[n];
            //    str = string.Join("", str).Remove(n, 1).ToCharArray();
            //    str = Permute(str, n);
            //}
            //Console.WriteLine(retString);
            //return retString;
        }

        private static char[] Permute(char[] str, int n)
        {
            //Array.Sort(str);
            int i = 1;
            do
            {
                if (i == n)
                    break;

                i++;
            } while (NextPermutation(str));

            return str;
        }

        private static bool NextPermutation(char[] p)
        {
            for (int a = p.Length - 2; a >= 0; --a)
                if (p[a] < p[a + 1])
                    for (int b = p.Length - 1; ; --b)
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
            return false;
        }

        private static int Factorial(int f)
        {
            if (f == 0)
                return 1;
            else
                return f * Factorial(f - 1);
        }
    }
}