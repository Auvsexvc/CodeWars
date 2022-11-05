using NUnit.Framework;
using System;

namespace Kata.Classes
{
  internal class YouReASquare
  {
    public class Kata
    {
      public static bool IsSquare(int n)
      {
        return Math.Sqrt(n) % 1 == 0;
      }
    }

    [TestFixture]
    public class Tests
    {
      [Test]
      public static void ShouldWorkForSomeExamples()
      {
        Assert.AreEqual(false, Kata.IsSquare(-1), "negative numbers aren't square numbers");
        Assert.AreEqual(false, Kata.IsSquare(3), "3 isn't a square number");
        Assert.AreEqual(true, Kata.IsSquare(4), "4 is a square number");
        Assert.AreEqual(true, Kata.IsSquare(25), "25 is a square number");
        Assert.AreEqual(false, Kata.IsSquare(26), "26 isn't a square number");
      }
    }
  }
}