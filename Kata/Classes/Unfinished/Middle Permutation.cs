using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes.Unfinished
{
    [TestFixture]
    public class myjinxin
    {
        [Test]
        public void BasicTests()
        {
            MiddlePermutationKata kata = new MiddlePermutationKata();

            Assert.AreEqual("bac", kata.MiddlePermutation("abc"));

            Assert.AreEqual("bdca", kata.MiddlePermutation("abcd"));

            Assert.AreEqual("cbxda", kata.MiddlePermutation("abcdx"));

            Assert.AreEqual("cxgdba", kata.MiddlePermutation("abcdxg"));

            Assert.AreEqual("dczxgba", kata.MiddlePermutation("abcdxgz"));

            Assert.AreEqual("lbfcgtmnxsiprkqh", kata.MiddlePermutation("ftlcmbhqprgnkxis"));

            Assert.AreEqual("jgqfx", kata.MiddlePermutation("jgxqf"));
        }
    }

    /// <summary>
    /// You are given a string s. Every letter in s appears once. Consider all strings formed by
    /// rearranging the letters in s. After ordering these strings in dictionary order, return the
    /// middle term. (If the sequence has a even length n, define its middle term to be the (n/2)th term.)
    /// </summary>
    internal class MiddlePermutationKata
    {
        public string MiddlePermutation(string s)
        {
            char[] str = s.ToCharArray();
            Array.Sort(str);
            string retString = string.Empty;
            int dividend = s.Length.Factorial() / 2 - 1;

            for (int i = 0; i < s.Length; i++)
            {
                int perms = str.Length.Factorial() / str.Length;
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
    }
}