using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class ScrambliesTests
    {
        [Test]
        public static void test1()
        {
            testing(Scramblies.Scramble("rkqodlw", "world"), true);
            testing(Scramblies.Scramble("cedewaraaossoqqyt", "codewars"), true);
            testing(Scramblies.Scramble("katas", "steak"), false);
            testing(Scramblies.Scramble("scriptjavx", "javascript"), false);
            testing(Scramblies.Scramble("scriptingjava", "javascript"), true);
            testing(Scramblies.Scramble("scriptsjava", "javascripts"), true);
            testing(Scramblies.Scramble("javscripts", "javascript"), false);
            testing(Scramblies.Scramble("aabbcamaomsccdd", "commas"), true);
            testing(Scramblies.Scramble("commas", "commas"), true);
            testing(Scramblies.Scramble("sammoc", "commas"), true);
        }

        private static void testing(bool actual, bool expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }

    internal class Scramblies
    {
        public static bool Scramble(string str1, string str2)
        {
            var firstCheck = str2.All(str1.Contains);
            var secondCheck = str2.Distinct().All(x => str1.Count(c => c == x) >= str2.Count(c => c == x));

            return firstCheck && secondCheck;
        }
    }
}