using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    internal static class LastSurvivorsEp2
    {
        public static string Last_survivors(string str)
        {
            var chr = str.FirstOrDefault(x => str.Count(c => c == x) > 1);
            var nxtChr = chr != 'z' ? (char)(chr + 1) : 'a';
            var charList = str.Where(x => x != chr).ToList();

            for (int i = 0; i < str.Count(x => x == chr) / 2; i++)
                charList.Add(nxtChr);

            if (str.ToList().RemoveAll(x => x == chr) % 2 != 0)
                charList.Add(chr);

            return str.Any(x => str.Count(c => c == x) > 1) ? Last_survivors(String.Concat(charList)) : str;
        }

        public static string Last_survivors_regex(string str)
        {
            const string pattern = @"(\w)(\w*)\1";
            var res = Regex.Replace(str, pattern, m => (char)(((m.Groups[1].Value[0] - 'a' + 1) % 26) + 97) + m.Groups[2].Value);
            return Regex.IsMatch(res, pattern) ? Last_survivors_regex(res) : res;
        }

        [TestFixture]
        public class SolutionTest
        {
            public string Fixup(string s)
            {
                List<char> chars = s.ToList();
                chars.Sort();
                return (string.Join("", chars));
            }

            [Test, Description("Sample Tests abaa")]
            public void Given_abaa()
            {
                Assert.AreEqual("ac", Fixup(LastSurvivorsEp2.Last_survivors("abaa")));
            }


            [Test, Description("Sample Tests zzab")]
            public void Given_zzab()
            {
                Assert.AreEqual("c", Fixup(LastSurvivorsEp2.Last_survivors("zzab")));
            }

            [Test, Description("Zero Length")]
            public void Empty_String()
            {
                Assert.AreEqual("", LastSurvivorsEp2.Last_survivors(""));
            }

            [Test, Description("A longer string")]
            public void Longer_String()
            {
                string expected = "acdeghlmnqrvyz";
                string provided = "xsdlafqpcmjytoikojsecamgdkehrqqgfknlhoudqygkbxftivfbpxhxtqgpkvsrfflpgrlhkbfnyftwkdebwfidmpauoteahyh";

                Assert.AreEqual(expected, Fixup(LastSurvivorsEp2.Last_survivors(provided)));
            }
        }
    }
}