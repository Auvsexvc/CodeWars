using NUnit.Framework;

namespace Kata.Classes
{
  internal class Pillars
  {
    public static class Kata
    {
      public static int Pillars(int numPill, int dist, int width)
      {
        return numPill > 1 ? dist * 100 * (numPill - 1) + width * (numPill - 2) : 0;
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      [Test]
      public void BasicTest1()
      {
        Assert.AreEqual(0, Kata.Pillars(1, 10, 10), "Testing for number of pillars: 1, distance: 10 m and width: 10 cm");
      }

      [Test]
      public void BasicTest2()
      {
        Assert.AreEqual(2000, Kata.Pillars(2, 20, 25), "Testing for number of pillars: 2, distance: 20 m and width: 25 cm");
      }

      [Test]
      public void BasicTest3()
      {
        Assert.AreEqual(15270, Kata.Pillars(11, 15, 30), "Testing for number of pillars: 11, distance: 15 m and width: 30 cm");
      }
    }
  }
}