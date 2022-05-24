using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class Circle_area_inside_square
    {
        /// <summary>
        /// Turn an area of a square in to an area of a circle that fits perfectly inside the square.
        /// You get the blue+red area and need to calculate the red area.
        /// Your function gets a number which represents the area of the square and should return the area of the circle. The tests are rounded by 8 decimals to make sure multiple types of solutions work.
        /// You don't have to worry about error handling or negative number input: area >= 0
        /// </summary>
        public class Convert
        {
            public static double SquareAreaToCircle(double size)=>
                Math.PI * Math.Pow(Math.Sqrt(size) / 2,2);
        }
    }
}
