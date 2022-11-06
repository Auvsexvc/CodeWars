using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
  public class WriteNumberInExpandedForm
  {
    public static class Kata
    {
      public static string ExpandedForm(long num)
      {
        return string.Join(
          " + ",
          num
            .ToString()
            .Select((d, i) => (int.Parse(d.ToString()) * Math.Pow(10, num.ToString().Length - i - 1)).ToString())
            .Where(s => s != "0"));
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      [Test]
      public void BasicTests()
      {
        Assert.That(Kata.ExpandedForm(12), Is.EqualTo("10 + 2"));
        Assert.That(Kata.ExpandedForm(42), Is.EqualTo("40 + 2"));
        Assert.That(Kata.ExpandedForm(70304), Is.EqualTo("70000 + 300 + 4"));
      }
    }
  }
}