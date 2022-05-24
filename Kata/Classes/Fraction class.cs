using System;

namespace Kata.Classes
{
    /// <summary>
    /// You are provided with a skeleton of the class 'Fraction', which accepts two arguments (numerator, denominator).
    /// Your task is to make this class string representable, and addable while keeping the result in the minimum representation possible.
    /// NB: DON'T use the built_in class 'fractions.Fraction'
    /// </summary>
    internal class Fraction_class
    {
        public class Fraction
        {
            private long Top { get; set; }
            private long Bottom { get; set; }

            public Fraction(long numerator, long denominator)
            {
                if (denominator == 0)
                    throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
                Top = numerator;
                Bottom = denominator;
            }

            // Equality checking
            public override int GetHashCode() => this.GetHashCode(); // not actually used

            public override bool Equals(object o) => Compare(this, o as Fraction) == 0;

            public static bool operator ==(Fraction f1, Fraction f2) => Compare(f1, f2) == 0;

            public static bool operator !=(Fraction f1, Fraction f2) => Compare(f1, f2) != 0;

            private static long Compare(Fraction f1, Fraction f2) => f1.Top * f2.Bottom - f2.Top * f1.Bottom;

            // Your work here!
            public static Fraction operator +(Fraction a) => a;

            public static Fraction operator -(Fraction a) => new Fraction(-a.Top, a.Bottom);

            public static Fraction operator +(Fraction a, Fraction b)
                => new Fraction(a.Top * Lcm(a.Bottom, b.Bottom) / a.Bottom + b.Top * Lcm(a.Bottom, b.Bottom) / b.Bottom, Lcm(a.Bottom, b.Bottom));

            public static Fraction operator -(Fraction a, Fraction b)
                => a + (-b);

            public static Fraction operator *(Fraction a, Fraction b)
                => new Fraction(a.Top * b.Top, a.Bottom * b.Bottom);

            public static Fraction operator /(Fraction a, Fraction b)
            {
                if (b.Top == 0)
                    throw new DivideByZeroException();
                return new Fraction(a.Top * b.Bottom, a.Bottom * b.Top);
            }

            public override string ToString() => $"{Top / Gcf(Top, Bottom)}/{Bottom / Gcf(Top, Bottom)}";

            private static long Gcf(long a, long b)
            {
                while (b != 0)
                {
                    long temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }

            private static long Lcm(long a, long b)
            {
                return (a / Gcf(a, b)) * b;
            }
        }
    }
}