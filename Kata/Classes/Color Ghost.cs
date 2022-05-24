using System;

namespace Kata.Classes
{
    internal class Color_Ghost
    {
        /// <summary>
        /// Create a class Ghost
        /// Ghost objects are instantiated without any arguments.
        /// Ghost objects are given a random color attribute of "white" or "yellow" or "purple" or "red" when instantiated
        /// </summary>
        public class Ghost
        {
            private enum Colors
            { white, yellow, purple, red }

            public string Color { get; private set; }

            public Ghost()
            {
                Color = Enum
                    .GetValues(typeof(Colors))
                    .GetValue(new Random().Next(0, Enum.GetValues(typeof(Colors)).Length))
                    .ToString();
            }

            public string GetColor() => this.Color;
        }
    }
}