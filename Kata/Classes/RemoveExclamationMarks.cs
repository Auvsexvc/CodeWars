using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
  internal class RemoveExclamationMarks
  {
    public class Kata
    {
      public static string RemoveExclamationMarks(string s)
      {
        return Regex.Replace(s, "[!]", "");
      }
    }

    [TestFixture]
    public class Tests
    {
      [Test]
      public static void MyTests()
      {
        Assert.AreEqual("", Kata.RemoveExclamationMarks(""), "Input: Empty string");
        Assert.AreEqual("", Kata.RemoveExclamationMarks("!"), "Input: " + "!");
        Assert.AreEqual("", Kata.RemoveExclamationMarks("!!"), "Input: " + "!!");
        Assert.AreEqual("Hi", Kata.RemoveExclamationMarks("Hi!"), "Input: " + "Hi!");
        Assert.AreEqual("?", Kata.RemoveExclamationMarks("!?!"), "Input: " + "!?!");
      }
    }
  }
}