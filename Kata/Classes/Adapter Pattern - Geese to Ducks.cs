namespace Kata.Classes
{
    /// <summary>
    /// Given an interface IDuck, you are to create an Object Adapter (using Composition) in order to adapt the Goose class to support the IDuck interface.
    ///
    /// </summary>
    internal class Adapter_Pattern___Geese_to_Ducks
    {
        public class GooseToIDuckAdapter : IDuck
        {
            private Goose _goose;

            public GooseToIDuckAdapter(Goose goose)
            {
                _goose = goose;
            }

            public void Fly()
            {
                _goose.Fly();
            }

            public string Quack() =>
                _goose.Honk();
        }

        public interface IDuck
        {
            string Quack();

            void Fly();
        }

        public class Goose
        {
            public string Honk()
            { 
                return string.Empty;
            }

            public void Fly()
            {
                //dummy
            }
        }
    }
}