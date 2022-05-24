using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Now that we have a Block let's move on to something slightly more complex a Sphere.
    /// #Arguments for the constructor
    /// radius -> integer
    /// mass -> integer
    /// #Methods to be defined
    /// GetRadius() => radius of the Sphere
    /// GetMass() => mass of the Sphere
    /// GetVolume() => volume of the Sphere(a double rounded to 5 place after the decimal)
    /// GetSurfaceArea() => surface area of the Sphere(a double rounded to 5 place after the decimal)
    /// GetDensity() => density of the Sphere(a double rounded to 5 place after the decimal)
    /// ##Example
    /// Sphere ball = new Sphere(2, 50)
    /// ball.GetRadius() ->       2
    /// ball.GetMass() ->         50
    /// ball.GetVolume() ->       33.51032
    /// ball.GetSurfaceArea() ->  50.26548
    /// ball.GetDensity() ->      1.49208
    /// </summary>
    internal class Building_Spheres
    {
        public class Sphere
        {
            private int radius;
            private int mass;

            public Sphere(int r, int m)
            {
                radius = r;
                mass = m;
            }

            public int GetRadius() => radius;
            public int GetMass() => mass;
            public double GetVolume() => Math.Round((4.0/3.0)*Math.PI*Math.Pow(radius,3),5);
            public double GetSurfaceArea() => Math.Round(4 *Math.PI*Math.Pow(radius,2),5);
            public double GetDensity() => Math.Round(mass / GetVolume(),5);
        }
    }
}
