using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
  public class WeightForWeight
  {
    public class WeightSort
    {
      public static string orderWeight(string strng)
      {
        return string.Join(
          " ",
          strng
            .Split(" ")
            .OrderBy(x => x.Sum(d => int.Parse(d.ToString())))
            .ThenBy(x => x));
      }
    }

    [TestFixture]
    public class WeightSortTests
    {
      [Test]
      public void Test1()
      {
        Console.WriteLine("****** Basic Tests");
        Assert.AreEqual("2000 103 123 4444 99", WeightSort.orderWeight("103 123 4444 99 2000"));
        Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", WeightSort.orderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
      }
    }
  }
}