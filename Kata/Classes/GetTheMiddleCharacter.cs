using NUnit.Framework;

namespace Kata.Classes
{
    [TestFixture]
    public class GetTheMiddleCharacterTest
    {
        [Test]
        public void GenericTests()
        {
            Assert.AreEqual("es", GetTheMiddleCharacter.GetMiddle("test"));
            Assert.AreEqual("t", GetTheMiddleCharacter.GetMiddle("testing"));
            Assert.AreEqual("dd", GetTheMiddleCharacter.GetMiddle("middle"));
            Assert.AreEqual("A", GetTheMiddleCharacter.GetMiddle("A"));
        }
    }

    internal class GetTheMiddleCharacter
    {
        public static string GetMiddle(string s) =>
            s.Length % 2 == 0 ? s.Substring((s.Length / 2) - 1, 2) : s.Substring(s.Length / 2, 1);
    }
}