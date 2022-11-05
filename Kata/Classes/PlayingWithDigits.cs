using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
  public class PlayingWithDigits
  {
    public static class DigPow
    {
      public static long DigPower(int n, int p)
      {
        return long.TryParse((n
          .ToString()
          .Select((v, i) => Math.Pow(int.Parse(v.ToString()), p + i))
          .Sum() / n)
          .ToString(), out long result)
          ? result
          : -1;
      }
    }

    [TestFixture]
    public class DigPowTests
    {
      [Test]
      public void Test1()
      {
        Assert.AreEqual(1, DigPow.DigPower(89, 1));
      }

      [Test]
      public void Test2()
      {
        Assert.AreEqual(-1, DigPow.DigPower(92, 1));
      }

      [Test]
      public void Test3()
      {
        Assert.AreEqual(51, DigPow.DigPower(46288, 3));
      }
    }
  }
}