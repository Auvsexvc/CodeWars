using NUnit.Framework;
using System;

namespace Kata.Classes
{
  internal class RiggedDice
  {
    public class Kata
    {
      public static int ThrowRigged()
      {
        return (new Random().Next(1, 101) <= 22) ? 6 : new Random().Next(1, 6);
      }
    }

    [TestFixture]
    public class KataTests
    {
      [Test]
      public void Test1()
      {
        for (var i = 0; i < 10; i++)
        {
          var tr = Kata.ThrowRigged();
          Assert.IsTrue(tr > 0 && tr < 7, "Your code generated number is out of range 1-6");
        }
      }

      [Test]
      public void Test2()
      {
        var arrr = "";

        for (int i = 0; i < 10; i++)
        {
          var tmp = "";
          for (int j = 0; j < 20; j++)
          {
            tmp += Kata.ThrowRigged().ToString();
          }
          Assert.IsTrue(arrr.IndexOf(tmp) == -1, "Your code generates duplicate results.");
          arrr += tmp;
        }
      }

      [Test]
      public void Test3()
      {
        var count = 0;
        for (var i = 0; i < 100000; i++)
        {
          if (Kata.ThrowRigged() == 6)
          {
            count++;
          }
        }
        Assert.IsTrue(count >= 21700 && count <= 22300, "Your code generates " + count + " times number 6");
      }
    }
  }
}