using System;

namespace Kata.Classes
{
    /// <summary>
    /// ##What are you dealing with...
    /// You're a clever programmer and too lazy to calculate integrals by your own!
    /// So you decide to write a method which will do your calculations.
    /// ##TODO Here it is up to you! Implement two methods GetY(double x) and CalcIntegral(int from, int to)
    /// </summary>
    internal class Calculate_Integral
    {
        public class LinFunc
        {
            public double M { get; set; }
            public double B { get; set; }

            public double GetY(double x) =>
                x * M + B;

            public double CalcIntegral(int a, int b) =>
                (M * Math.Pow(b,2) / 2 + B * b) - (M * Math.Pow(a, 2) / 2 + B * a);
        }
    }
}