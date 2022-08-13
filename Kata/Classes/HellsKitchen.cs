using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    public class HellsKitchen
    {
        public static string Gordon(string a)
        {
            return string
                .Concat(a.Select(c => char.ToLower(c) == 'a'
                    ? '@'
                    : new char[] { 'e', 'i', 'o', 'u' }.Contains(char.ToLower(c))
                        ? '*'
                        : c))
                .ToUpper()
                .Replace(" ", "!!!! ") + "!!!!";
        }
    }

    [TestFixture]
    public class HellsKitchenTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("WH@T!!!! F*CK!!!! D@MN!!!! C@K*!!!!", HellsKitchen.Gordon("What feck damn cake"));
            Assert.AreEqual("@R*!!!! Y**!!!! ST*!!!! P*D!!!!", HellsKitchen.Gordon("are you stu pid"));
            Assert.AreEqual("*!!!! @M!!!! @!!!! CH*F!!!!", HellsKitchen.Gordon("i am a chef"));
        }
    }
}