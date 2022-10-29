using NUnit.Framework;
using System.Linq;
using System.Numerics;

namespace Kata.Classes
{
  public class SumStringsAsNumbers
  {
    public static class Kata
    {
      public static string sumStrings(string a, string b)
      {
        return new string[] { a, b }
          .Select(x => BigInteger.TryParse(x, out BigInteger number) ? number : 0)
          .Aggregate((x, y) => BigInteger.Add(x, y))
          .ToString();
      }
    }

    [TestFixture]
    public class CodeWarsTest
    {
      [Test]
      public void Given123And456Returns579()
      {
        Assert.AreEqual("579", Kata.sumStrings("123", "456"));
      }

      [Test]
      public void GivenEmptyAnd5Returns5()
      {
        Assert.AreEqual("5", Kata.sumStrings("", "5"));
      }
    }
  }
}