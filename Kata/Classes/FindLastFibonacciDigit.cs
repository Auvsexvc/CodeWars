using NUnit.Framework;

namespace Kata.Classes
{
  internal class FindLastFibonacciDigit
  {
    public class Kata
    {
      public static int LastFibDigit(long n)
      {
        int[] f = new int[60];
        Fib(f);

        int index = (int)(n % 60);

        return f[index];
      }

      private static void Fib(int[] f)
      {
        f[0] = 0;
        f[1] = 1;

        for (int i = 2; i <= 59; i++)
        {
          f[i] = (f[i - 1] + f[i - 2]) % 10;
        }
      }
    }

    [TestFixture]
    public class KataTests
    {
      [Test]
      public void BasicTests()
      {
        Assert.AreEqual(1, Kata.LastFibDigit(1));
        Assert.AreEqual(6, Kata.LastFibDigit(21));
        Assert.AreEqual(1, Kata.LastFibDigit(302));
        Assert.AreEqual(7, Kata.LastFibDigit(4003));
        Assert.AreEqual(8, Kata.LastFibDigit(50004));
        Assert.AreEqual(5, Kata.LastFibDigit(600005));
        Assert.AreEqual(3, Kata.LastFibDigit(7000006));
        Assert.AreEqual(8, Kata.LastFibDigit(80000007));
        Assert.AreEqual(1, Kata.LastFibDigit(900000008));
        Assert.AreEqual(9, Kata.LastFibDigit(1000000009));
      }
    }
  }
}