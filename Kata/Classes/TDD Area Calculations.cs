using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Finish this kata with the unit tests as your only help!
    /// Implement: Calculator.GetTotalArea()
    /// Define the different shapes: `Square`, `Rectangle`, `Circle` and `Triangle`
    /// </summary>
    internal class TDD_Area_Calculations
    {
        public class Calculator
        {
            public double GetTotalArea() => 0;

            public double GetTotalArea(params Shape[] shapes) => Math.Round(shapes.Select(s => s.GetTotalArea()).Sum(), 2);
        }

        public abstract class Shape
        {
            protected string _name;

            public string Name { get => _name; }

            public Shape() => _name = GetType().Name;

            public abstract double GetTotalArea();
        }

        public class Square : Shape
        {
            private double _side;
            public double Side { get => _side; }

            public Square(double side) => _side = side;

            public override double GetTotalArea() => Math.Pow(_side, 2);
        }

        public class Rectangle : Shape
        {
            private double _height;
            private double _width;
            public double Height { get => _height; }
            public double Width { get => _width; }

            public Rectangle(double height, double width)
            {
                _height = height;
                _width = width;
            }

            public override double GetTotalArea() => _height * _width;
        }

        public class Circle : Shape
        {
            private double _radius;
            public double Radius { get => _radius; }

            public Circle(double radius) => _radius = radius;

            public override double GetTotalArea() => Math.PI * Math.Pow(_radius, 2);
        }

        public class Triangle : Shape
        {
            private double _triangleBase;
            private double _triangleHeight;

            public double TriangleBase { get => _triangleBase; }
            public double TriangleHeight { get => _triangleHeight; }

            public Triangle(double triangleBase, double triangleHeight)
            {
                _triangleBase = triangleBase;
                _triangleHeight = triangleHeight;
            }

            public override double GetTotalArea() => _triangleBase * _triangleHeight / 2;
        }
    }
}