namespace Kata.Classes
{
    /// <summary>
    /// According to the creation myths of the Abrahamic religions, Adam and Eve were the first Humans to wander the Earth.
    /// You have to do God's job. The creation method must return an array of length 2 containing objects (representing Adam and Eve). 
    /// The first object in the array should be an instance of the class Man. The second should be an instance of the class Woman. 
    /// Both objects have to be subclasses of Human. Your job is to implement the Human, Man and Woman classes.
    /// </summary>
    internal class Basic_subclasses___Adam_and_Eve
    {
        public static Human[] Create() =>
            new Human[2] { new Man(), new Woman() };
    }

    public class Human
    {
    }

    public class Man : Human
    {
    }

    public class Woman : Human
    {
    }
}