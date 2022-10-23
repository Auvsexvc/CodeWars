using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
  class AreaOfASquare
  {
    public class Kata
    {
      public static double SquareArea(double A)
      {
        var r = (2 * A) / Math.PI;
        var rectSurface = Math.Pow(r, 2);
        return Math.Round(rectSurface, 2);
      }
    }

    [TestFixture]
    public class Sample_Tests
    {
      private static double[][] testCases = new double[][]
      {
      new double[] {2, 1.62},
      new double[] {0, 0},
      new double[] {14.05, 80},
      };

      [Test, TestCaseSource("testCases")]
      public void SampleTest(double A, double expected)
      {
        Assert.AreEqual(expected, Kata.SquareArea(A));
      }
    }
  }
}
