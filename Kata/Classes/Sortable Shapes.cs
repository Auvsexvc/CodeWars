using System;
using System.Collections.Generic;

namespace Kata.Classes
{
    /// <summary>
    /// Although shapes can be very different by nature, they can be sorted by the size of their area.
    /// Create different shapes that can be part of a sortable list. The sort order is based on the size of their respective areas:
    /// The area of a Square is the square of its side
    /// The area of a Rectangle is width multiplied by height
    /// The area of a Triangle is base multiplied by height divided by 2
    /// The area of a Circle is the square of its radius multiplied by π
    /// The area of a CustomShape is given
    /// The default sort order of a list of shapes is ascending on area size.
    /// </summary>
    internal class Sortable_Shapes
    {
        public abstract class Shape : IComparable<Shape>
        {
            public string Name { get; set; }
            public double Area { get; set; }
            public List<Shape> Shapes { get; set; }

            public int CompareTo(Shape shape)
            {
                if (this.Area < shape.Area) return -1;
                if (this.Area == shape.Area) return 0;
                return 1;
            }
        }

        public class Square : Shape
        {
            public double Side { get; set; }

            public Square(double side)
            {
                Side = side;
                Area = Math.Pow(Side, 2);
            }
        }

        public class Rectangle : Shape
        {
            public double Height { get; set; }
            public double Width { get; set; }

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
                Area = Width * Height;
            }
        }

        public class Triangle : Shape
        {
            public double TriangleBase { get; set; }
            public double Height { get; set; }

            public Triangle(double triangleBase, double height)
            {
                Height = height;
                TriangleBase = triangleBase;
                Area = (TriangleBase * Height) / 2;
            }
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }

            public Circle(double radius)
            {
                Radius = radius;
                Area = Math.PI * Math.Pow(Radius, 2);
            }
        }

        public class CustomShape : Shape
        {
            public CustomShape(double area)
            {
                Area = area;
            }
        }
    }
}