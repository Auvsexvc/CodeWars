using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
  internal class IsThereAVowelInThere
  {
    public class Kata
    {
      public static object[] IsVow(object[] a)
      {
        return a
          .Select(numb => new char[] { 'a', 'e', 'i', 'o', 'u' }.Contains(Convert.ToChar(numb))
            ? Convert.ToChar(numb).ToString()
            : numb)
          .ToArray();
      }
    }

    [TestFixture]
    public class KataTests
    {
      [Test]
      public void BasicTests()
      {
        Assert.AreEqual(new object[] { 118, "u", 120, 121, "u", 98, 122, "a", 120, 106, 104, 116, 113, 114, 113, 120, 106 }, Kata.IsVow(new object[] { 118, 117, 120, 121, 117, 98, 122, 97, 120, 106, 104, 116, 113, 114, 113, 120, 106 }));
        Assert.AreEqual(new object[] { "e", 121, 110, 113, 113, 103, 121, 121, "e", 107, 103 }, Kata.IsVow(new object[] { 101, 121, 110, 113, 113, 103, 121, 121, 101, 107, 103 }));
      }
    }
  }
}