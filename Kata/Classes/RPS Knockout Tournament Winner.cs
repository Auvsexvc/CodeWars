using System;
using System.Collections.Generic;

namespace Kata.Classes
{
    internal class RPS_Knockout_Tournament_Winner
    {
        /// <summary>
        /// A rock-paper-scissors robo player paticipates regularly in the same knockout tournament but almost always without succes.
        /// Can you improve this robo player and make it a tournament winner?
        /// - A match is between 2 players. The first that wins 20 games of Rock-Paper-Scissors is the winner of the match and continues to the next round. The other player is eliminated from the tournament.
        /// - If your bot wins 5 rounds, the final included, it has won the tournament.
        /// - The number of opponents is limited. Each opponent has its own strategy that does not change.
        /// - The tournament is played on the preloaded RockPaperScissorsPlayground:
        ///     RockPaperScissorsPlayground playground = new RockPaperScissorsPlayground();
        ///     bool result = playground.PlayTournament(myPayer);
        ///
        /// This kata starts with a working bot, altough it plays with a poor random strategy. It can compete on the RockPaperScissorsPlayground because it implements IRockPaperScissorsPlayer interface.
        ///
        /// Extend methods get shape and set opponent shape to make the patterns of your opponents visible to you and analyse their strategies and weaknesses.
        /// If the strategy of an opponent is clear to you, adapt your bot to the opponent.
        /// Continue until your bot can beat all opponents by skill instead of sheer luck.
        /// </summary>
        public class Player : Interfaces.IRockPaperScissorsPlayer
        {
            private Random random;
            private string _opponent;
            private string _opponentShape;
            private List<string> _counterTactic;
            private int _round;

            public Player()
            {
                random = new Random((int)DateTime.UtcNow.Ticks);
            }

            public string Name
            {
                get
                {
                    return "MyPlayer";
                }
            }

            public void SetNewMatch(string nameOpponent)
            {
                _round = 0;
                _opponent = nameOpponent;

                if (_opponent == "Vitraj Bachchan") _counterTactic = new List<string>() { "R" };
                if (_opponent == "Bin Jinhao") _counterTactic = new List<string> { "R", "P", "R", "S", "P", "S" };
                if (_opponent == "Sven Johanson") _counterTactic = new List<string> { "R", "R", "S", "P", "P", "R" };
                if (_opponent == "Max Janssen") _counterTactic = new List<string> { "S", "S", "P", "P", "S", "S", "P", "P", "P", "P", "S", "S", "S", "P", "P", "P", "P", "S", "P", "P" };
                if (_opponent == "Jonathan Hughes") _counterTactic = new List<string> { "S", "S", "R", "R", "R", "R", "S", "P", "R", "S", "R", "S", "R", "S", "P", "R" };
            }

            public string GetShape()
            {
                if (_opponent == "Vitraj Bachchan")
                {
                    string myHand = _counterTactic[0];
                    _round++;
                    return myHand;
                }

                if (_opponent == "Bin Jinhao")
                {
                    string myHand = _counterTactic[_round % (_counterTactic.Count)];
                    _round++;
                    return myHand;
                }

                if (_opponent == "Sven Johanson")
                {
                    string myHand = _counterTactic[_round % (_counterTactic.Count)];
                    _round++;
                    return myHand;
                }

                if (_opponent == "Max Janssen")
                {
                    string myHand = _counterTactic[_round % (_counterTactic.Count)];
                    _round++;
                    if (_round > 1 && _counterTactic[_round % (_counterTactic.Count)] != _opponentShape)
                    {
                        _round += 12;
                        myHand = _counterTactic[_round % (_counterTactic.Count)];
                    }
                    return myHand;
                }

                if (_opponent == "Jonathan Hughes")
                {
                    string myHand = _counterTactic[_round % (_counterTactic.Count)];
                    _round++;
                    if (_round > 1 && _counterTactic[_round % (_counterTactic.Count)] != _opponentShape)
                    {
                        _round += 2;
                        myHand = _counterTactic[_round % (_counterTactic.Count)];
                    }
                    return myHand;
                }

                switch (random.Next(1, 4))
                {
                    case 1: return "P";
                    case 2: return "R";
                    default: return "S";
                }
            }

            public void SetOpponentShape(string shape)
            {
                _opponentShape = shape;
            }
        }
    }
}