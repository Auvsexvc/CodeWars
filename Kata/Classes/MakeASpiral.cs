using NUnit.Framework;
using System;

namespace Kata.Classes
{
  internal class MakeASpiral
  {
    public class Spiralizor
    {
      public static int[,] Spiralize(int size)
      {
        return CreateSpiral(size);
      }

      public static int Sum(int size) => (2 * size) + (int)(Math.Pow(size - 1, 2) / 2) - 1;

      public static int[,] CreateSpiral(int n)
      {
        int[,] ret = new int[n, n];
        int val = 1;
        int c1 = 0, c2 = n - 1;
        int ct1 = c1;
        int ct2 = c2;
        while (val <= Sum(n))
        {
          for (int i = ct1; i <= c2; i++)
          {
            ret[c1, i] = 1;
            val++;
          }

          for (int j = c1 + 1; j <= c2; j++)
          {
            ret[j, c2] = 1;
            val++;
          }

          for (int i = c2 - 1; i >= c1; i--)
          {
            ret[c2, i] = 1;
            val++;
          }

          for (int j = c2 - 1; j >= c1 + 2; j--)
          {
            ret[j, c1] = 1;
            val++;
          }
          ct1 = c1 + 1;
          c1 = c1 + 2;
          c2 = c2 - 2;
        }
        if (n % 2 == 0) ret[n / 2, n / 2 - 1] = 0;
        return ret;
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      [Test]
      public void Test05()
      {
        int input = 5;
        int[,] expected = new int[,]{
            {1, 1, 1, 1, 1},
            {0, 0, 0, 0, 1},
            {1, 1, 1, 0, 1},
            {1, 0, 0, 0, 1},
            {1, 1, 1, 1, 1}
        };

        int[,] actual = Spiralizor.Spiralize(input);
        Assert.AreEqual(expected, actual);
      }

      [Test]
      public void Test08()
      {
        int input = 8;
        int[,] expected = new int[,]{
            {1, 1, 1, 1, 1, 1, 1, 1},
            {0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1},
        };

        int[,] actual = Spiralizor.Spiralize(input);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}