using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Snakes and Ladders is an ancient Indian board game regarded today as a worldwide classic. It is played between two or more players on a gameboard having numbered, gridded squares. A number of "ladders" and "snakes" are pictured on the board, each connecting two specific board squares. (Source Wikipedia)
    /// Your task is to make a simple class called SnakesLadders. The test cases will call the method play(die1, die2) independantly of the state of the game or the player turn. The variables die1 and die2 are the die thrown in a turn and are both integers between 1 and 6. The player will move the sum of die1 and die2.
    /// Rules:
    /// 1.  There are two players and both start off the board on square 0.
    /// 2.  Player 1 starts and alternates with player 2.
    /// 3.  You follow the numbers up the board in order 1=>100
    /// 4.  If the value of both die are the same then that player will have another go.
    /// 5.  Climb up ladders. The ladders on the game board allow you to move upwards and get ahead faster. If you land exactly on a square that shows an image of the bottom of a ladder, then you may move the player all the way up to the square at the top of the ladder. (even if you roll a double).
    /// 6.  Slide down snakes. Snakes move you back on the board because you have to slide down them. If you land exactly at the top of a snake, slide move the player all the way to the square at the bottom of the snake or chute. (even if you roll a double).
    /// 7.  Land exactly on the last square to win. The first person to reach the highest square on the board wins. But there's a twist! If you roll too high, your player "bounces" off the last square and moves back. You can only win by rolling the exact number needed to land on the last square. For example, if you are on square 98 and roll a five, move your game piece to 100 (two moves), then "bounce" back to 99, 98, 97 (three, four then five moves.)
    /// 8.  If the Player rolled a double and lands on the finish square “100” without any remaining moves then the Player wins the game and does not have to roll again.
    /// Returns:
    /// Return Player n Wins!. Where n is winning player that has landed on square 100 without any remainding moves left.
    /// Return Game over! if a player has won and another player tries to play.
    /// Otherwise return Player n is on square x. Where n is the current player and x is the sqaure they are currently on.
    /// </summary>
    internal class Snakes_and_Ladders
    {
        public class SnakesLadders
        {
            public Player player1, player2;
            public Player[] players;
            public Snake[] snakes;
            public Ladder[] ladders;
            public Board board;
            public GameState gameState;
            public Player player;

            public SnakesLadders()
            {
                board = new Board(100, 0, 100);
                player1 = new Player("Player 1", board);
                player2 = new Player("Player 2", board);
                players = new Player[2] { player1, player2 };
                snakes = new Snake[]
                {
                    new Snake(16, 6),
                    new Snake(49, 11),
                    new Snake(46, 25),
                    new Snake(62, 19),
                    new Snake(64, 60),
                    new Snake(74, 53),
                    new Snake(89, 68),
                    new Snake(92, 88),
                    new Snake(95, 75),
                    new Snake(99, 80)
                };
                ladders = new Ladder[]
                {
                    new Ladder(2, 38),
                    new Ladder(7, 14),
                    new Ladder(8, 31),
                    new Ladder(15, 26),
                    new Ladder(28, 84),
                    new Ladder(21, 42),
                    new Ladder(36, 44),
                    new Ladder(51, 67),
                    new Ladder(71, 91),
                    new Ladder(78, 98),
                    new Ladder(87, 94)
                };
                gameState = new GameState(player1);
            }

            public string play(int die1, int die2)
            {
                if (gameState.IsGameOver)
                    return gameState.GameOver();

                player = gameState.IsPlayerTurn;

                player.Move(die1, die2, board);
                player.ClimbUp(ladders);
                player.SlideDown(snakes);

                if (player.Position == board.Finish)
                    return player.WinsAGame(gameState);

                if (die1 == die2)
                    player.GainsTurn();

                return player.EndTurn(gameState, players);
            }
        }

        public class GameState
        {
            public bool IsGameOver { get; set; }
            public Player IsPlayerTurn { get; set; }
            public Player IsAWinner { get; set; }

            public GameState(Player isPlayerTurn)
            {
                IsGameOver = false;
                IsPlayerTurn = isPlayerTurn;
                IsAWinner = null;
            }

            public string GameOver() =>
                "Game over!";
        }

        public class Board
        {
            public int Size { get; private set; }
            public int Start { get; private set; }
            public int Finish { get; private set; }

            public Board(int size, int start, int finish)
            {
                Size = size;
                Start = start;
                Finish = finish;
            }
        }

        public class Player
        {
            private bool gainsTurn = false;
            public string Name { get; }
            public int Position { get; set; }

            public Player(string name, Board board)
            {
                Name = name;
                Position = board.Start;
            }

            public void Move(int die1, int die2, Board board)
            {
                if (Position + die1 + die2 > board.Size)
                    Position = board.Size - (Position + die1 + die2 - board.Size);
                else
                    Position += die1 + die2;
                gainsTurn = false;
            }

            public void ClimbUp(Ladder[] ladders)
            {
                if (ladders.Select(l => l.Bottom).Contains(this.Position))
                    Position = ladders.Where(l => l.Bottom == this.Position).FirstOrDefault().Top;
            }

            public void SlideDown(Snake[] snakes)
            {
                if (snakes.Select(s => s.Head).Contains(this.Position))
                    Position = snakes.Where(s => s.Head == this.Position).FirstOrDefault().Tail;
            }

            public void GainsTurn()
            {
                gainsTurn = true;
            }

            public string EndTurn(GameState state, Player[] players)
            {
                if (!this.gainsTurn)
                    state.IsPlayerTurn = players.SkipWhile(p => p.Name != this.Name).Skip(1).FirstOrDefault() ?? players.Take(1).FirstOrDefault();

                return $"{this.Name} is on square {this.Position}";
            }

            public string WinsAGame(GameState state)
            {
                state.IsAWinner = this;
                state.IsGameOver = true;
                return $"{this.Name} Wins!";
            }
        }

        public class Ladder
        {
            public int Bottom { get; }
            public int Top { get; }

            public Ladder(int bottom, int top)
            {
                Top = top;
                Bottom = bottom;
            }
        }

        public class Snake
        {
            public int Head { get; }
            public int Tail { get; }

            public Snake(int head, int tail)
            {
                Head = head;
                Tail = tail;
            }
        }
    }
}