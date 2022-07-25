using NUnit.Framework;
using System;

namespace Kata.Classes
{
    [TestFixture]
    public static class MagnetsTests
    {
        private static Random rnd = new Random();

        [Test]
        public static void test1()
        {
            Console.WriteLine("Fixed Tests: Doubles");
            assertFuzzyEquals(Magnets.Doubles(1, 10), 0.5580321939764581); // 0.5580321939764581
            assertFuzzyEquals(Magnets.Doubles(10, 1000), 0.6921486500921933); // 0.6921486500921933
            assertFuzzyEquals(Magnets.Doubles(10, 10000), 0.6930471674194457); // 0.6930471674194457
            assertFuzzyEquals(Magnets.Doubles(20, 10000), 0.6930471955575918); // 0.6930471955575918
        }

        private static void assertFuzzyEquals(double act, double exp)
        {
            bool inrange = Math.Abs(act - exp) <= 1e-6;
            if (inrange == false)
            {
                string specifier = "#0.000000";
                Console.WriteLine(
                    "At 1e-6: Expected must be " + exp.ToString(specifier) + ", but got " + act.ToString(specifier));
            }
            Assert.AreEqual(true, inrange);
        }
    }

    internal class Magnets
    {
        public static double Doubles(int maxk, int maxn) =>
            S(maxk, maxn);

        private static double V(int k, int n) =>
            1 / (k * Math.Pow(n + 1, 2 * k));

        private static double U(int k, int n)
        {
            double sum = 0;
            while (n > 0)
            {
                sum += V(k, n);
                n--;
            }
            return sum;
        }

        private static double S(int k, int n)
        {
            double vsum = 0;
            while (k > 0)
            {
                vsum += U(k, n);
                k--;
            }
            return vsum;
        }
    }
}