using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class CodeDecodeTests
    {
        [Test]
        public static void Test1()
        {
            Console.WriteLine("Fixed Tests code");
            TestingCode("62", "0011100110");
            TestingCode("55337700", "001101001101011101110011110011111010");
            TestingCode("1119441933000055", "1111110001100100110000110011000110010111011110101010001101001101");
            TestingCode("69", "00111000011001");
            TestingCode("86", "00011000001110");
        }

        [Test]
        public static void Test2()
        {
            Console.WriteLine("Fixed Tests decode");
            TestingDecode("10001111", "07");
            TestingDecode("001100001100001100001110001110001110011101110111001110001110001110001111001111001111001100001100001100", "444666333666777444");
            TestingDecode("01110111110001100100011000000110000011110011110111011100110000110001100110", "33198877334422");
            TestingDecode("0011010011010011011010101111110011000011000011000011100011100011100011100011100011100001100100011001000110011100011001001111001111001111001111001111001111", "55500011144466666699919777777");
            TestingDecode("01110111011111000110010011110011110011110011110011110011110111011101110110011001100110011001101111111010101100011001000110000001100000011000", "3331977777733322222211100019888");
        }

        private static void TestingCode(string s, string expected)
        {
            string actual = CodeDecode.Code(s);
            Assert.AreEqual(expected, actual);
        }

        private static void TestingDecode(string s, string expected)
        {
            string actual = CodeDecode.Decode(s);
            Assert.AreEqual(expected, actual);
        }
    }

    public static class CodeDecode
    {
        public static string Code(string strng)
        {
            string retString = string.Empty;

            foreach (var item in strng.Select(x => (int)char.GetNumericValue(x)).ToArray())
            {
                string b = string.Empty;

                for (int i = 0; i < CountBits(item) - 1; i++)
                {
                    b += "0";
                }
                b += 1;

                string c = Convert.ToString(item, 2);
                retString += string.Concat(b, c);
            }

            return retString;
        }

        public static string Decode(string str)
        {
            string retString = string.Empty;
            Dictionary<int, string> substrings = Enumerable.Range(1, 10).Select(d => d - 1).ToDictionary(d => d, d => Code((d).ToString()));

            while (str.Length > 0)
            {
                for (int j = 2; j <= str.Length; j++)
                {
                    if (substrings.ContainsValue(string.Concat(str.Take(j))))
                    {
                        retString += substrings.FirstOrDefault(d => d.Value == string.Concat(str.Take(j))).Key;
                        str = str.Remove(0, j);
                        break;
                    }
                }
            }

            return retString;
        }

        private static int CountBits(int number) =>
            (int)Math.Log(number, 2.0) + 1;
    }
}