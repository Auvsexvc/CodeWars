using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kata.Classes.Classy_Extensions;
using static Kata.Classes.Regular_Ball_Super_Ball;

namespace Kata.Classes
{
    /// <summary>
    /// Imagine you are creating a game where the user has to guess the correct number. But there is a limit of how many guesses the user can do.
    /// If the user tries to guess more than the limit, the function should throw an error.
    /// If the user guess is right it should return true.
    /// If the user guess is wrong it should return false and lose a life.
    /// Can you finish the game so all the rules are met?
    /// </summary>
    internal class Finish_Guess_the_Number_Game
    {
        public class Guesser
        {
            private int number;
            private int lives;

            public Guesser(int number, int lives)
            {
                this.number = number;
                this.lives = lives;
            }

            public bool Guess(int n)
            {
                if(lives == 0)
                {
                    throw new Exception("Error");
                }
                if (n == number)
                    return true;
                else
                {
                    lives--;
                    return false;
                }
            }
        }
    }
}
