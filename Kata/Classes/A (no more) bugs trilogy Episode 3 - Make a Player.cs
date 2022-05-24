namespace Kata.Classes
{
    /// <summary>
    /// Pac succesfully passed the first & second test.
    /// Pac has to create a Football Player object with the following attributes :
    /// Name      => (string)
    /// Position  => (string)
    /// Age => (int)
    /// Dribbling => (int)
    /// Pass => (int)
    /// Shoot     => (int)
    /// Note: If applicable, these properties need to be public.
    /// </summary>
    internal class A__no_more__bugs_trilogy_Episode_3___Make_a_Player
    {
        public class Player
        {
            public string Name { get; private set; }
            public string Position { get; private set; }
            public int Age { get; private set; }
            public int Dribbling { get; private set; }
            public int Pass { get; private set; }
            public int Shoot { get; private set; }

            public Player(string name, string position, int age, int dribbling, int pass, int shoot)
            {
                Name = name;
                Position = position;
                Age = age;
                Dribbling = dribbling;
                Pass = pass;
                Shoot = shoot;
            }
        }
    }
}