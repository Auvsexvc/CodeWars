using System;

namespace Kata.Classes
{
    /// <summary>
    /// Hey Codewarrior!
    /// You already implemented a Cube class, but now we need your help again! I'm talking about constructors.
    /// We don't have one.Let's code two: One taking an integer and one handling no given arguments!
    /// Also we got a problem with negative values.Correct the code so negative values will be switched to positive ones!
    /// The constructor taking no arguments should assign 0 to Cube's Side property.
    /// </summary>
    internal class Playing_with_cubes_II
    {
        public class Cube
        {
            private int Side;

            public Cube()
            {
                Side = 0;
            }

            public Cube(int side)
            {
                Side = Math.Abs(side);
            }

            public int GetSide()
            {
                return this.Side;
            }

            public void SetSide(int s)
            {
                this.Side = Math.Abs(s);
            }
        }
    }
}