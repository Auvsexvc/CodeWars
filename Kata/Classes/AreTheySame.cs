using NUnit.Framework;
using System.Collections.Generic;

namespace Kata.Classes
{
  public static class AreTheySame
  {
    public static bool Comp(int[] a, int[] b)
    {
      try
      {
        var stackA = new Stack<int>(a);
        var stackB = new List<int>(b);

        while (stackA.Count > 0)
        {
          var x = stackA.Pop();
          if (!stackB.Contains(x * x))
            return false;
          stackB.Remove(x * x);
        }
        return stackA.Count == 0 && stackB.Count == 0;
      }
      catch (System.ArgumentNullException)
      {
        return false;
      }
    }
  }

  [TestFixture]
  public class AreTheySameTests
  {
    [Test]
    public void Test1()
    {
      int[] a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
      int[] b = new int[] { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };
      bool r = AreTheySame.Comp(a, b); // True
      Assert.AreEqual(true, r);
    }

    [Test]
    public void Test1a()
    {
      int[] a = new int[] { 2, 2, 3 };
      int[] b = new int[] { 4, 9, 9 };
      bool r = AreTheySame.Comp(a, b); // false
      Assert.AreEqual(false, r);
    }

    [Test]
    public void Test2a()
    {
      int[] a = new int[] { 4, 4 };
      int[] b = new int[] { 1, 31 };
      bool r = AreTheySame.Comp(a, b); // false
      Assert.AreEqual(false, r);
    }

    [Test]
    public void Test2()
    {
      int[] a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
      int[] b = new int[] { 11 * 11, 121 * 121, 144 * 144, 190 * 190, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };
      bool r = AreTheySame.Comp(a, b); // False
      Assert.AreEqual(false, r);
    }

    [Test]
    public void Test3()
    {
      int[] a = new int[0];
      int[] b = new int[] { 1 };
      bool r = AreTheySame.Comp(a, b); // False
      Assert.AreEqual(false, r);
    }

    [Test]
    public void Test4()
    {
      int[] a = new int[0];
      int[] b = null;
      bool r = AreTheySame.Comp(a, b); // False
      Assert.AreEqual(false, r);
    }

    [Test]
    public void Test5()
    {
      int[] a = new int[0];
      int[] b = new int[0];
      bool r = AreTheySame.Comp(a, b); // True
      Assert.AreEqual(true, r);
    }

    [Test]
    public void Test6()
    {
      int[] a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11, 1008 };
      int[] b = new int[] { 11 * 11, 121 * 121, 144 * 144, 190 * 190, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };
      bool r = AreTheySame.Comp(a, b); // False
      Assert.AreEqual(false, r);
    }

    [Test]
    public void Test7()
    {
      int[] a = new int[] { 121, 1440, 191, 161, 19, 144, 195, 11 };
      int[] b = new int[] { 11 * 11, 121 * 121, 1440 * 1440, 191 * 191, 161 * 161, 19 * 19, 144 * 144, 195 * 195 };
      bool r = AreTheySame.Comp(a, b); // True
      Assert.AreEqual(true, r);
    }

    [Test]
    public void Test8()
    {
      int[] a = new int[] { 0, 14, 191, 161, 19, 144, 195, 1 };
      int[] b = new int[] { 1, 0, 14 * 14, 191 * 191, 161 * 161, 19 * 19, 144 * 144, 195 * 195 };
      bool r = AreTheySame.Comp(a, b); // True
      Assert.AreEqual(true, r);
    }

    [Test]
    public void Test9()
    {
      int[] a = new int[] { 0, 14, 191, 161, 19, 144, 195, 1, 2 };
      int[] b = new int[] { 1, 0, 14 * 14, 191 * 191, 161 * 161, 19 * 19, 144 * 144, 195 * 195, 3 };
      bool r = AreTheySame.Comp(a, b); // True
      Assert.AreEqual(false, r);
    }

    [Test]
    public void Test1b()
    {
      int[] a = new int[] { 2, 2, 3 };
      int[] b = new int[] { 4, 4, 9 };
      bool r = AreTheySame.Comp(a, b); // false
      Assert.AreEqual(true, r);
    }

    [Test]
    public void Test2b()
    {
      int[] a = new int[] { 3, 4 };
      int[] b = new int[] { 0, 25 };
      bool r = AreTheySame.Comp(a, b); // false
      Assert.AreEqual(false, r);
    }
  }
}