using NUnit.Framework;

namespace Kata.Classes
{
  public class BouncingBall
  {
    public static int bouncingBall(double h, double bounce, double window)
    {
      if (!(h > 0
        && (bounce > 0 && bounce < 1)
        && window < h))
      {
        return -1;
      }

      int n = 1;
      h *= bounce;
      while (h > window)
      {
        n += 2;
        h *= bounce;
      }
      return n;
    }
  }

  [TestFixture]
  public class BouncingBallTests
  {
    [Test]
    public void Test1()
    {
      Assert.AreEqual(3, BouncingBall.bouncingBall(3.0, 0.66, 1.5));
    }

    [Test]
    public void Test2()
    {
      Assert.AreEqual(15, BouncingBall.bouncingBall(30.0, 0.66, 1.5));
    }
  }
}