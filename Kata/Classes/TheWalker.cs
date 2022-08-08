using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class WalkerTests
    {
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests");
            dotest(12, 20, 18, 45, 30, 60, "15, 135, 49, 18");
            dotest(15, 15, 19, 50, 29, 55, "12, 133, 18, 44");
            dotest(14, 25, 17, 41, 35, 59, "20, 129, 41, 57");
        }

        private static void dotest(int a, int b, int c, int alpha, int beta, int gamma, string expect)
        {
            int[] d = TheWalker.Solve(a, b, c, alpha, beta, gamma);
            String actual = String.Join(", ", d.Select(p => p.ToString()).ToArray());
            Assert.AreEqual(expect, actual);
        }
    }

    public class TheWalker
    {
        public static int[] Solve(int a, int b, int c, int alpha, int beta, int gamma)
        {
            (double, double) pointO = (0, 0);
            (double, double) pointC = CalculatePointCoors(CalculatePointCoors(CalculatePointCoors((0, 0), a, alpha, 0), b, beta, 90), c, gamma, 180);

            (int D, int M, int S) tOC = GetAngle(pointO, pointC);

            return new int[] { (int)GetLength(pointO, pointC), tOC.D, tOC.M, tOC.S };
        }

        private static (int D, int M, int S) GetAngle((double, double) start, (double, double) end)
        {
            double angle = 180 + (Math.Atan((end.Item2 - start.Item2) / (end.Item1 - start.Item1)) * 180 / Math.PI);

            int degrees = (int)Math.Floor(angle);
            int totalSeconds = (int)Math.Floor(3600.0 * (angle - degrees));
            int seconds = totalSeconds % 60;
            int minutes = (int)Math.Floor(totalSeconds / 60.0);

            return (degrees, minutes, seconds);
        }

        private static double GetLength((double, double) start, (double, double) end) =>
            Math.Round(Math.Sqrt(Math.Pow(end.Item1 - start.Item1, 2) + Math.Pow(end.Item2 - start.Item2, 2)));

        private static (double, double) CalculatePointCoors((double, double) start, int a, int alpha, int offset) =>
            (start.Item1 + (Math.Cos(ToRadians(alpha + offset)) * a), start.Item2 + (Math.Sin(ToRadians(alpha + offset)) * a));

        private static double ToRadians(int alpha) =>
            alpha * 2 * Math.PI / 360;
    }
}