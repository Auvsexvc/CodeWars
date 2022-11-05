using NUnit.Framework;
using System;

namespace Kata.Classes
{
  public class SuperDuperEasy
  {
    public class Kata
    {
      public static string Problem(String a)
      {
        return double.TryParse(a, out double result) ? ((result * 50) + 6).ToString() : "Error";
      }
    }

    [TestFixture]
    public class EasyTests
    {
      [Test]
      public void Test1()
      {
        Assert.AreEqual("Error", Kata.Problem("hello"));
        Assert.AreEqual("56", Kata.Problem("1"));
        Assert.AreEqual("256", Kata.Problem("5"));
        Assert.AreEqual("6", Kata.Problem("0"));
        Assert.AreEqual("66", Kata.Problem("1.2"));
      }
    }
  }
}