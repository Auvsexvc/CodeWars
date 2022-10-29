using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
  internal class SpeedControl
  {
    public class GpsSpeed
    {
      public static int Gps(int s, double[] x)
      {
        return x.Length <= 1
          ? 0
          : Enumerable
            .Range(0, x.Length - 1)
            .Max(i => (int)Math.Floor(3600.00 * (x[i + 1] - x[i]) / s));
      }
    }

    [TestFixture]
    public static class GpsSpeedTests
    {
      private static void testing(long act, long exp)
      {
        long r = Math.Abs(act - exp);
        bool inrange = r <= 1;
        if (inrange == false)
        {
          string specifier = "#.0";
          Console.WriteLine("abs(actual - expected) must be <= 1 but was " + r.ToString(specifier));
        }
        Assert.AreEqual(true, inrange);
      }

      [Test]
      public static void test1()
      {
        Console.WriteLine("Testing Gps");
        double[] x = new double[] { 0.0, 0.23, 0.46, 0.69, 0.92, 1.15, 1.38, 1.61 };
        testing(GpsSpeed.Gps(20, x), 41);
        x = new double[] { 0.0, 0.11, 0.22, 0.33, 0.44, 0.65, 1.08, 1.26, 1.68, 1.89, 2.1, 2.31, 2.52, 3.25 };
        testing(GpsSpeed.Gps(12, x), 219);
        x = new double[] { 0.0, 0.18, 0.36, 0.54, 0.72, 1.05, 1.26, 1.47, 1.92, 2.16, 2.4, 2.64, 2.88, 3.12, 3.36, 3.6, 3.84 };
        testing(GpsSpeed.Gps(20, x), 80);
        x = new double[] { 0.0, 0.01, 0.36, 0.6, 0.84, 1.05, 1.26, 1.47, 1.68, 1.89, 2.1, 2.31, 2.52, 2.73, 2.94, 3.15 };
        testing(GpsSpeed.Gps(14, x), 90);
        x = new double[] { 0.0, 0.02, 0.36, 0.54, 0.72, 0.9, 1.08, 1.26, 1.44, 1.62, 1.8 };
        testing(GpsSpeed.Gps(17, x), 72);
        x = new double[] { 0.0, 0.24, 0.48, 0.72, 0.96, 1.2, 1.44, 1.68, 1.92, 2.16, 2.4 };
        testing(GpsSpeed.Gps(12, x), 72);
        x = new double[] { 0.0, 0.02, 0.44, 0.66, 0.88, 1.1, 1.32, 1.54, 1.76 };
        testing(GpsSpeed.Gps(17, x), 88);
        x = new double[] { 0.0, 0.2, 0.4, 0.6, 0.8, 1.0, 1.32, 1.54, 1.76, 1.98, 2.2, 2.42, 2.76, 2.99, 3.22, 3.45 };
        testing(GpsSpeed.Gps(16, x), 76);
        x = new double[] { 0.0, 0.01, 0.36, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0, 2.25, 2.5, 2.75, 3.0, 3.25, 3.5, 3.75, 4.0, 4.25, 4.5, 4.75 };
        testing(GpsSpeed.Gps(17, x), 82);
        x = new double[] { 0.0, 0.2, 0.4, 0.69, 0.92, 1.15, 1.38, 1.61, 1.92, 2.16, 2.4, 2.64, 2.88, 3.12, 3.36 };
        testing(GpsSpeed.Gps(19, x), 58);
        x = new double[] { };
        testing(GpsSpeed.Gps(19, x), 0);
        x = new double[] { 0.0 };
        testing(GpsSpeed.Gps(19, x), 0);
      }
    }
  }
}