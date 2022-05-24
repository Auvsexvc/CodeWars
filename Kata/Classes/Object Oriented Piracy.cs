namespace Kata.Classes
{
    /// <summary>
    /// Ahoy matey!
    /// You are a leader of a small pirate crew.And you have a plan.With the help of OOP you wish to make a pretty efficient system to identify ships with a heavy booty on board.
    /// Unfortunattely for you, people weigh a lot this days, so how do you know if a ship if full of gold and not people?
    /// Every time your spies see a new ship enter the dock, they will create a new ship object based on their observations:
    ///draft - an estimate of the ship's weight based on how low it is in the water
    ///crew - the count of crew on board
    ///Ship titanic = new Ship(15, 10);
    ///Taking into account that an average crew member on board adds 1.5 units to the draft, a ship that has a draft of more than 20 without crew is considered worthy to loot.Any ship weighing that much must have a lot of booty!
    ///    Add the method
    ///    IsWorthIt
    ///    to decide if the ship is worthy to loot.For example:
    ///    titanic.IsWorthIt() => false
    /// This Kata teaches you the very basic of method creation.
    ///   Good luck!
    /// </summary>
    internal class Object_Oriented_Piracy
    {
        public class Ship
        {
            public int Draft;
            public int Crew;

            public Ship(int draft, int crew)
            {
                Draft = draft;
                Crew = crew;
            }

            public bool IsWorthIt()
            {
                return Draft - Crew * 1.5 > 20;
            }
        }
    }
}