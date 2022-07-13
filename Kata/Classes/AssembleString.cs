using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Classes
{
    /// <summary>
    /// In this task, you need to restore a string from a list of its copies.
    /// You will receive an array of strings. All of them are supposed to be the same as the original but, unfortunately, they were corrupted which means some of the characters were replaced with asterisks ("*").
    /// You have to restore the original string based on non-corrupted information you have. If in some cases it is not possible to determine what the original character was, use "#" character as a special marker for that.
    /// If the array is empty, then return an empty string.
    /// </summary>
    internal static class AssembleString
    {
        public static string Assemble(string[] copies)
        {
            string retString = string.Empty;
            if (copies.Length == 0) return retString;
            for (int i = 0; i < copies.FirstOrDefault().Length; i++)
            {
                for (int j = 0; j < copies.Length; j++)
                {
                    if (copies[j][i] != '*')
                    {
                        retString += copies[j][i];
                        break;
                    }
                    if (j == copies.Length - 1) retString += '#';
                }
            }

            return retString;
        }

        public static string Assemble2(string[] arr)
        {
            if (arr.Length == 0) return String.Empty;

            var result = Enumerable.Range(0, arr[0].Length)
                                   .Select(i => arr[0][i] != '*'
                                                ? arr[0][i] : arr[1][i] != '*'
                                                ? arr[1][i] : arr[2][i] != '*'
                                                ? arr[2][i] : '#');
            return String.Concat(result);
        }
    }

    [TestFixture]
    public class AssembleStringTest
    {
        [Test]
        public void SampleTests()
        {
            Assert.AreEqual("abcde", AssembleString.Assemble(new string[] { "a*cde", "*bcde", "abc*e" }));
            Assert.AreEqual("a#cd#", AssembleString.Assemble(new string[] { "a*c**", "**cd*", "a*cd*" }));
            Assert.AreEqual("hashtag -> #", AssembleString.Assemble(new string[] { "*ashtag ** *", "h*sht*g *> *", "has*tag -* *" }));
        }

        [Test]
        public void SpecialTests()
        {
            Assert.AreEqual("abcde", AssembleString.Assemble(new string[] { "abcde", "abcde", "abcbe" }));
            Assert.AreEqual("#####", AssembleString.Assemble(new string[] { "*****", "*****", "*****" }));
            Assert.AreEqual("", AssembleString.Assemble(Array.Empty<string>()));
            Assert.AreEqual("", AssembleString.Assemble(new string[] { "", "", "" }));
        }
        [Test]
        public void RandomTests()
        {
            // Declare vars
            Random rand = new();
            char[] validCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz./-][+-0123456789'".ToCharArray();
            // 70characters

            StringBuilder orginal = new();
            List<string> copies = new();
            StringBuilder current = new();
            _ = Array.Empty<string>();

            for (int i = 0; i < 50; i++)
            {
                // Create new word
                int lengthOfWord = rand.Next(4, 10);
                for (int j = 0; j < lengthOfWord; j++) orginal.Append(validCharacters[rand.Next(0, 70)]);
                string orginalS = orginal.ToString();

                // Create copies

                for (int j = rand.Next(3, 6); j > 0; j--)
                {
                    current.Clear();
                    foreach (char c in orginalS)
                    {
                        if (rand.Next(0, 4) == 0) current.Append('*');
                        else current.Append(c);
                    }
                    copies.Add(current.ToString());
                }

                // Check for equality
                string[] copiesArray = copies.ToArray();
                Assert.AreEqual(AssembleStringTest.AssembleSol(copiesArray), AssembleString.Assemble(copiesArray));
                orginal.Clear();
            }
        }

        private static string AssembleSol(string[] copies)
        {
            int amountOfCopies = copies.Length;

            if (amountOfCopies == 0) return string.Empty;

            int wordLength = copies[0].Length;
            StringBuilder output = new StringBuilder().Insert(0, "*", wordLength);

            for (int i = 0; i < wordLength; i++)
            {
                for (int j = 0; j < amountOfCopies; j++)
                {
                    if (copies[j][i] != '*')
                    {
                        output[i] = copies[j][i];
                        break;
                    }
                }
                if (output[i] == '*') output[i] = '#';
            }

            return output.ToString();
        }
    }
}