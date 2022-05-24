using System.Dynamic;

namespace Kata.Classes
{
    /// <summary>
    /// The State Design Pattern can be used, for example, to manage the state of a tank in the StarCraft game.
    /// The pattern consists in isolating the state logic in different classes rather than having multiple ifs to determine what should happen.
    /// Complete the code so that when a Tank goes into SiegeMode it cannot move and its damage goes to 20. When it goes to TankMode it should be able to move and the damage should be set to 5.
    /// Note: The tank initial state should be TankState.
    /// </summary>
    internal class PatternCraft___State
    {
        public interface IUnit
        {
            IUnitState State { get; set; }
            bool CanMove { get; }
            int Damage { get; }
        }

        public interface IUnitState
        {
            bool CanMove { get; set; }
            int Damage { get; set; }
        }

        public class SiegeState : IUnitState
        {
            public SiegeState()
            {
                CanMove = false;
                Damage = 20;
            }

            public bool CanMove { get; set; }
            public int Damage { get; set; }
        }

        public class TankState : IUnitState
        {
            public TankState()
            {
                CanMove = true;
                Damage = 5;
            }

            public bool CanMove { get; set; }
            public int Damage { get; set; }
        }

        public class Tank : IUnit
        {
            public Tank()
            {
                State = new TankState();
            }

            public IUnitState State { get; set; }

            public bool CanMove { get { return State.CanMove; } }
            public int Damage { get { return State.Damage; } }


        }
    }
}