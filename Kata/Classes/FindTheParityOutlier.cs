using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
  public class FindTheParityOutlier
  {
    public class Kata
    {
      public static int Find(int[] integers)
      {
        return integers
          .GroupBy(k => k % 2 == 0)
          .First(g => g.Count() == 1)
          .Single();
      }
    }

    [TestFixture]
    public class Tests
    {
      [Test]
      public static void Test1()
      {
        int[] exampleTest1 = { 2, 6, 8, -10, 3 };
        Assert.IsTrue(3 == Kata.Find(exampleTest1));
      }

      [Test]
      public static void Test2()
      {
        int[] exampleTest2 = { 206847684, 1056521, 7, 17, 1901, 21104421, 7, 1, 35521, 1, 7781 };
        Assert.IsTrue(206847684 == Kata.Find(exampleTest2));
      }

      [Test]
      public static void Test3()
      {
        int[] exampleTest3 = { int.MaxValue, 0, 1 };
        Assert.IsTrue(0 == Kata.Find(exampleTest3));
      }
    }
  }
}