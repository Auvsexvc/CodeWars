using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Create a function that returns the name of the winner in a fight between two fighters.
    /// Each fighter takes turns attacking the other and whoever kills the other first is victorious. Death is defined as having health <= 0
    /// Each fighter will be a Fighter object/instance. See the Fighter class below in your chosen language.
    /// Both health and damagePerAttack (damage_per_attack for python) will be integers larger than 0. You can mutate the Fighter objects.
    /// </summary>
    internal class Two_fighters_one_winner
    {
        public class Fighter
        {
            public string Name;
            public int Health, DamagePerAttack;

            public Fighter(string name, int health, int damagePerAttack)
            {
                this.Name = name;
                this.Health = health;
                this.DamagePerAttack = damagePerAttack;
            }
        }

        public static string declareWinnerLinq(Fighter fighter1, Fighter fighter2, string firstAttacker)
        {
            var fighters = new[] { fighter1, fighter2 };

            var Attacker = fighters.Single(f => f.Name == firstAttacker);
            var Defender = fighters.Single(f => f.Name != firstAttacker);
            Defender.Health -= Attacker.DamagePerAttack;
            if (Defender.Health <= 0)
            {
                return Attacker.Name;
            }
            return declareWinner(fighter1, fighter2, Defender.Name);
        }

        public static string declareWinner(Fighter fighter1, Fighter fighter2, string firstAttacker)
        {
            Fighter a, b;
            int turn = 0;

            if (fighter1.Name == firstAttacker)
                ++turn;
            do
            {
                if (turn % 2 != 0)
                {
                    a = fighter1;
                    b = fighter2;
                }
                else
                {
                    a = fighter2;
                    b = fighter1;
                }
                b.Health -= a.DamagePerAttack;
                Console.Write($"\n{a.Name} attacks {b.Name}; {b.Name} now has {b.Health}");
                ++turn;
            } while (a.Health > 0 && b.Health > 0);
            Console.WriteLine($" and is dead. {a.Name} wins!");

            return a.Name;
        }
        
    }
}