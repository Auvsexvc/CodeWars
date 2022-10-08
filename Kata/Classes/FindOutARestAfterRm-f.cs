using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    internal class FindOutARestAfterRm_f
    {
        public class Kata
        {
            public static int CountRestAfterRmF(string mask, List<string> files)
            {
                return string.IsNullOrEmpty(mask)
                    ? files.Count
                    : files.Count(f => !Regex.IsMatch(f,
                                                      new StringBuilder(mask)
                                                          .Replace(".", @"\.")
                                                          .Replace("*", ".*")
                                                          .Replace("?", ".?")
                                                          .Insert(0, '^')
                                                          .Append('$')
                                                          .ToString()));
            }
        }

        [TestFixture]
        public class KataTests
        {
            [Test]
            public void BasicTest1()
            {
                string mask = "?a*";

                List<string> files = new List<string> { "5", "a", "mama.jpg", "ma", "aa", "bb" };

                Assert.AreEqual(2, Kata.CountRestAfterRmF(mask, files));
            }

            [Test]
            public void BasicTest2()
            {
                string mask = "";

                List<string> files = new List<string> { "fotos", "trash.tar", "june2016", "codewars", "dad", "mom" };

                Assert.AreEqual(6, Kata.CountRestAfterRmF(mask, files));
            }
        }
    }
}