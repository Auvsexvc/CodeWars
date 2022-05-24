using System;

namespace Kata.Classes
{
    /// <summary>
    /// What better way to explain the Singleton pattern than to use the metaphore of the origin of mankind.
    /// </summary>
    internal class Singleton_Adam_and_Eve
    {
        public sealed class Adam : Male
        {
            private Adam()
            {
                Name = "Adam";
            }

            public static Adam _instance = null;

            private static readonly object lck = new object();

            public static Adam GetInstance()
            {
                if (_instance == null)
                {
                    lock (lck)
                    {
                        if (_instance == null)
                            _instance = new Adam();
                    }
                }
                return _instance;
            }
        }

        public sealed class Eve : Female
        {
            private Eve()
            {
                Name = "Eve";
            }

            public static Eve _instance = null;

            private static readonly object lck = new object();

            public static Eve GetInstance(Adam adam)
            {
                if (_instance == null && adam != null)
                {
                    lock (lck)
                    {
                        if (_instance == null)
                            _instance = new Eve();
                    }
                }
                else if (adam == null) 
                    throw new ArgumentNullException(nameof(adam));
                return _instance;
            }
        }

        public class Male : Human
        {
            protected Male()
            {
            }

            public Male(string name, Female mother, Male father) : base(name, mother, father)
            {
            }
        }

        public class Female : Human
        {
            protected Female()
            {
            }

            public Female(string name, Female mother, Male father) : base(name, mother, father)
            {
            }
        }

        public abstract class Human
        {
            public string Name { get; set; }
            public Female Mother { get; set; }
            public Male Father { get; set; }

            protected Human()
            {
            }

            public Human(string name, Female mother, Male father)
            {
                if (father == null || mother == null)
                    throw new ArgumentNullException();
                Name = name;
                Mother = mother;
                Father = father;
            }
        }
    }
}