using NUnit.Framework;
using System.Collections.Generic;

namespace Kata.Classes
{
    public class IsThisMyTail
    {
        public static bool CorrectTail(string body, string tail)
        {
            string sub = body[^tail.Length..];

            return sub == tail;
        }

        [TestFixture]
        public class Sample_Test
        {
            private static IEnumerable<TestCaseData> TestCases
            {
                get
                {
                    yield return new TestCaseData("Fox", "x").Returns(true);
                    yield return new TestCaseData("Rhino", "o").Returns(true);
                    yield return new TestCaseData("Meerkat", "t").Returns(true);
                    yield return new TestCaseData("Emu", "t").Returns(false);
                    yield return new TestCaseData("Badger", "s").Returns(false);
                    yield return new TestCaseData("Giraffe", "d").Returns(false);
                }
            }

            [Test, TestCaseSource("TestCases")]
            public bool Test(string body, string tail) => IsThisMyTail.CorrectTail(body, tail);
        }
    }
}