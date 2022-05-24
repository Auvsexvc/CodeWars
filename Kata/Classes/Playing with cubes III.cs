using System;

namespace Kata.Classes
{
    /// <summary>
    /// Now we want to provide some more information about cubes. First, we implement two new properties: Volume and Surface.
    /// Additional to this task we are going to refactor our code, so it will be bit more like professional C# code!
    /// You change the variable Side to a public property and remove the 'Getter' and 'Setter'.
    /// The properties Volume and Surface should each have a public get-accessor and private set-accessor.
    /// Their correct mathematical values should be set in the cubes constructor and if Side's values is changed.
    /// </summary>
    internal class Playing_with_cubes_III
    {
        public class Cube
        {
            private int _side;

            public int Side
            {
                get { return _side; }
                set { _side = Math.Abs(value); }
            }

            public int Volume
            { get { return (int)Math.Pow(Side, 3); } private set { } }
            public int Surface
            { get { return 6 * (int)Math.Pow(Side, 2); } private set { } }

            public Cube(int s)
            {
                Side = Math.Abs(s);
                Volume = (int)Math.Pow(Side, 3);
                Surface = 6 * (int)Math.Pow(Side, 2);
            }

            public Cube()
            {
            }
        }
    }
}