namespace Kata.Classes
{
    /// <summary>
    /// Create a class Ball. Ball objects should accept one argument for "ball type" when instantiated.
    /// If no arguments are given, ball objects should instantiate with a "ball type" of "regular."
    /// </summary>
    internal class Regular_Ball_Super_Ball
    {
        public class Ball
        {
            public string ballType { get; set; }

            public Ball()
            {
                ballType = "regular";
            }

            public Ball(string ballType)
            {
                this.ballType = ballType;
            }
        }
    }
}