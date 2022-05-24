using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class The_once_rollable_dice
    {
        /// <summary>
        /// In my simple RPG, every character will be created with the object-constructor: Character.
        /// // Balthazaar will be his name
        /// // 20 will be his opness (as Over-Poweredness)
        /// balthazaar.Attack() // should RETURN 20 (his opness) + a random number from 1 to 20
        /// // (the function should emulate a d20 roll)
        ///  // sadly that doesn't seem like the case for me,
        ///  // even if I call the function 100 times the d20 seems to roll only once or twice
        ///  // (d20 is a 20 sided dice)
        ///  After defeating that rat, I want to be able to raise his "overpoweredness-factor", thus modifying his min/max attack capabilities.
        ///  balthazaar.Opness++
        ///  balthazaar.Attack() // should RETURN 21 + a random number from 1 to 20
        ///  // tried cheating with it to beat that rat, but it doesn't work
        ///  Please help my Hero kill that rat, and become more Op!
        /// </summary>
        public class Character
        {
            public string Name;
            public int Opness;

            public Character(string name, int opness)
            {
                this.Name = name;
                this.Opness = opness;
            }

            public int Attack()
            {
                return new Random().Next(1, 21) + this.Opness;  // Chosen by fair d20 roll
                                                                // Guaranteed to be random
            }
        }
    }
}
