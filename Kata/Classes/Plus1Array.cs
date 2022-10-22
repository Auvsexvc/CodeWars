using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
  internal class Plus1Array
  {
    public static class Kata
    {
      public static int[] UpArray(int[] num)
      {
        if (num.Length == 0 || num.Any(x => x < 0 || x.ToString().Length > 1))
        {
          return null;
        }

        for (int i = num.Length - 1; i >= 0; i--)
        {
          num[i] = (++num[i]) % 10;
          if (num[i] > 0)
          {
            return num;
          }
        }

        return num.Prepend(1).ToArray();
      }
    }

    [TestFixture]
    public class ArrayTest
    {
      [Test]
      public void Test1()
      {
        var num = new int[] { 2, 3, 9 };
        var newNum = new int[] { 2, 4, 0 };
        Assert.AreEqual(newNum, Kata.UpArray(num));
      }

      [Test]
      public void Test2()
      {
        var num = new int[] { 4, 3, 2, 5 };
        var newNum = new int[] { 4, 3, 2, 6 };
        Assert.AreEqual(newNum, Kata.UpArray(num));
      }
    }
  }
}