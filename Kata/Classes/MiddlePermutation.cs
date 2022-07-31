using NUnit.Framework;
using System;
using System.Linq;
using System.Numerics;

namespace Kata.Classes
{
    [TestFixture]
    public class myjinxin
    {
        [Test]
        public void BasicTests()
        {
            MiddlePermutationKata kata = new MiddlePermutationKata();

            Assert.AreEqual("nmyxwvutsrqpoljigfedcba", kata.MiddlePermutation("rypbnlvowmdfcxaetugiqsj"));
            Assert.AreEqual("bxva", kata.MiddlePermutation("bavx"));

            Assert.AreEqual("bac", kata.MiddlePermutation("abc"));

            Assert.AreEqual("bdca", kata.MiddlePermutation("abcd"));

            Assert.AreEqual("cbxda", kata.MiddlePermutation("abcdx"));

            Assert.AreEqual("cxgdba", kata.MiddlePermutation("abcdxg"));

            Assert.AreEqual("dczxgba", kata.MiddlePermutation("abcdxgz"));

            Assert.AreEqual("lxtsrqpnmkihgfcb", kata.MiddlePermutation("ftlcmbhqprgnkxis"));
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
            if (s.Length == 1)
                return s;

            char[] sCharArr = s.ToCharArray();
            BigInteger dividend = Factorial(sCharArr.Length) / 2 - 1;
            Array.Sort(sCharArr);

            string retString = string.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                BigInteger perms = Factorial(sCharArr.Length) / sCharArr.Length;
                retString += sCharArr[(int)(dividend / perms)];
                sCharArr = sCharArr.Where(x => x != sCharArr[(int)(dividend / perms)]).ToArray();
                dividend -= perms * (dividend / perms);
            }

            return retString;
        }

        private static BigInteger Factorial(BigInteger f)
        {
            if (f == 0)
                return 1;
            else
                return f * Factorial(f - 1);
        }
    }
}