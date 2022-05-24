using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// The Adapter Design Pattern can be used, for example in the StarCraft game, to insert an external character in the game.
    /// The pattern consists in having a wrapper class that will adapt the code from the external source.
    /// The adapter receives an instance of the object that it is going to adapt and handles it in a way that works with our application.
    /// Complete the code so that we can create a MarioAdapter that can attack as other units do.
    /// Note to calculate how much damage mario is going to do you have to call the jumpAttack method.
    /// </summary>
    internal class PatternCraft___Adapter
    {
        public class MarioAdapter : IUnit
        {
            private Mario _mario;

            public MarioAdapter(Mario mario)
            {
                _mario = mario;
            }

            public void Attack(Target target)
            {
                target.Health -= _mario.jumpAttack();
            }
        }
        public class Target
        {
            public int Health { get; set; }
        }
        public interface IUnit
        {
            void Attack(Target target);
        }

        public class Marine : IUnit
        {
            public void Attack(Target target)
            {
                target.Health -= 6;
            }
        }

        public class Zealot : IUnit
        {
            public void Attack(Target target)
            {
                target.Health -= 8;
            }
        }

        public class Zergling : IUnit
        {
            public void Attack(Target target)
            {
                target.Health -= 5;
            }
        }

        public class Mario
        {
            public int jumpAttack()
            {
                Console.WriteLine("Mamamia!");
                return 3;
            }
        }
    }
}
