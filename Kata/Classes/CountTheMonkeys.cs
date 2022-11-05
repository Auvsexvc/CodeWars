using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
  internal class CountTheMonkeys
  {
    public static class MonkeyCounter
    {
      public static int[] MonkeyCount(int n)
      {
        return Enumerable.Range(1, n).ToArray();
      }
    }

    [TestFixture]
    public class Tests
    {
      public static object[] FixedTests =
      {
    new object[] { MonkeyCounter.MonkeyCount(5), new int[]{1,2,3,4,5} },
    new object[] { MonkeyCounter.MonkeyCount(3), new int[]{1,2,3} },
    new object[] { MonkeyCounter.MonkeyCount(9), new int[]{1,2,3,4,5,6,7,8,9} },
    new object[] { MonkeyCounter.MonkeyCount(10), new int[]{1,2,3,4,5,6,7,8,9,10} },
    new object[] { MonkeyCounter.MonkeyCount(20), new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20} }
  };

      [Test, TestCaseSource("FixedTests")]
      public void FixedTest(int[] r, int[] e)
      {
        Apesert.AreEqual(e, r);
      }
    }

    public static class Apesert
    {
      public static void AreEqual(int[] a, int[] b)
      {
        Assert.AreEqual("[" + String.Join(", ", a) + "]",
                        "[" + String.Join(", ", b) + "]",
                        "Array did not match expected.");
      }
    }
  }
}