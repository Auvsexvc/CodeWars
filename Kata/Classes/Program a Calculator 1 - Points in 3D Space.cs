using System;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// Create a class called Point which represents a point in 3D space. This class should have three public (i.e. accessible anywhere within the program/script) properties, x, y and z (X, Y, and Z in C#) which are anticipated to be numbers (integers and/or floats, doesn't matter) (double type in C#).  This class should have a constructor which accepts exactly three required arguments in the following order: x, y and z. All three of them are expected to be numbers but you will not be required to check this. Your constructor should then assign the arguments x, y and z to the properties x, y and z respectively.  The origin is considered a special point of reference in 3D space so it is referred to quite often. Create a public, static (i.e. invoked directly from the class itself) method getOrigin (GetOrigin in C#) which accepts no arguments and returns an instance of Point representing the origin.  In many cases, it is good to know the distance of a particular point from the origin. Declare and define a public class method getDistanceFromOrigin (GetDistanceFromOrigin in C#) which accepts no arguments and returns the distance of that point from the origin. No rounding is necessary as the test cases will allow for floating point errors.  Furthermore, it is often advantageous to know the distance of one point relative to another point. Declare and define a public class method getDistanceFromPoint (GetDistanceFromPoint in C#) which accepts exactly one required argument, another Point in 3D space (no type checking required), and returns the distance between those two points. Again, no rounding is necessary.
    /// </summary>
    internal class Program_a_Calculator_1___Points_in_3D_Space
    {
        public class Point
        {
            public double X { get; }
            public double Y { get; }
            public double Z { get; }

            public Point(double x, double y, double z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public static Point GetOrigin() => new Point(0, 0, 0);

            public double GetDistanceFromOrigin() => GetDistanceFromPoint(GetOrigin());

            public double GetDistanceFromPoint(Point point) => Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2) + Math.Pow(Z - point.Z, 2));
        }
    }
}