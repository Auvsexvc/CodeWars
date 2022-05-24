using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// We all love to play games especially as children. I have fond memories playing Connect 4 with my brother so decided to create this Kata based on the classic game. Connect 4 is known as several names such as “Four in a Row” and “Captain’s Mistress" but was made popular by Hasbro MB Games
    /// The game consists of a grid (7 columns and 6 rows) and two players that take turns to drop their discs. The pieces fall straight down, occupying the next available space within the column. The objective of the game is to be the first to form a horizontal, vertical, or diagonal line of four of one's own discs.
    /// Your task is to create a Class called Connect4 that has a method called play which takes one argument for the column where the player is going to place their disc.
    /// If a player successfully has 4 discs horizontally, vertically or diagonally then you should return "Player n wins!” where n is the current player either 1 or 2.
    /// If a player attempts to place a disc in a column that is full then you should return ”Column full!” and the next move must be taken by the same player.
    /// If the game has been won by a player, any following moves should return ”Game has finished!”.
    /// Any other move should return ”Player n has a turn” where n is the current player either 1 or 2.
    /// Player 1 starts the game every time and alternates with player 2.
    /// The columns are numbered 0-6 left to right.
    /// </summary>

    internal class Connect_4
    {
        public class Connect4
        {
            public Player player1, player2;
            public Player[] players;
            public Grid grid;
            public GameState gameState;
            public Player player;
            public List<Disc> discs;

            public Connect4()
            {
                grid = new Grid();
                player1 = new Player("Player 1");
                player2 = new Player("Player 2");
                players = new Player[2] { player1, player2 };
                gameState = new GameState(player1);
                discs = new List<Disc>();
            }

            public string play(int col)
            {
                if (gameState.IsGameOver)
                    return gameState.GameOver();

                player = gameState.IsPlayerTurn;

                player.Drop(col, grid, discs);

                if (player.GainsDrop)
                    return player.GainDrop();

                if (player.CheckIfPlayerWins(discs))
                    return player.WinsAGame(gameState);

                return player.EndTurn(gameState, players);
            }

            
        }

        public class Player
        {
            private bool gainsDrop = false;
            public string Name { get; }

            public bool GainsDrop
            { get { return gainsDrop; } set { gainsDrop = value; } }

            public Player(string name)
            {
                Name = name;
            }

            public void Drop(int col, Grid grid, List<Disc> discs)
            {
                gainsDrop = false;
                if (grid.Columns[col].Count < grid.RowsNum)
                {
                    Disc disc = new Disc(this);
                    grid.Columns[col].Add(disc);
                    disc.X = col;
                    disc.Y = grid.Columns[col].Count - 1;
                    discs.Add(disc);
                }
                else
                    gainsDrop = true;
            }

            public string GainDrop()
            {
                gainsDrop = true;
                return "Column full!";
            }

            public string EndTurn(GameState state, Player[] players)
            {
                if (!this.gainsDrop)
                    state.IsPlayerTurn = players.SkipWhile(p => p.Name != this.Name).Skip(1).FirstOrDefault() ?? players.Take(1).FirstOrDefault();

                return $"{this.Name} has a turn";
            }

            public bool CheckIfPlayerWins(List<Disc> discs)
            {
                if (
                    discs
                        .Where(d => d.X == discs.LastOrDefault().X)
                        .OrderBy(d => d.X)
                        .SkipWhile(d => !d.Owner.Name.Contains(this.Name))
                        .TakeWhile(d => d.Owner.Name.Contains(this.Name))
                        .Count() >= 4
                    ||
                    discs
                        .Where(d => d.Y == discs.LastOrDefault().Y)
                        .OrderBy(d => d.X)
                        .SkipWhile(d => !d.Owner.Name.Contains(this.Name))
                        .TakeWhile(d => d.Owner.Name.Contains(this.Name))
                        .Count() >= 4
                    ||
                    discs
                        .Where(d => (discs.LastOrDefault().X - d.X) == (discs.LastOrDefault().Y - d.Y))
                        .SkipWhile(d => !d.Owner.Name.Contains(this.Name))
                        .TakeWhile(d => d.Owner.Name.Contains(this.Name))
                        .Count() >= 4
                    ||
                    discs
                        .Where(d => (discs.LastOrDefault().X - d.X) == -(discs.LastOrDefault().Y - d.Y))
                        .SkipWhile(d => !d.Owner.Name.Contains(this.Name))
                        .TakeWhile(d => d.Owner.Name.Contains(this.Name))
                        .Count() >= 4
                ) return true;

                return false;
            }

            public string WinsAGame(GameState state)
            {
                state.AWinnerIs = this;
                state.IsGameOver = true;
                return $"{this.Name} wins!";
            }
        }

        public class Disc
        {
            public Player Owner { get; set; }
            public int X { get; set; }
            public int Y { get; set; }

            public Disc(Player player)
            {
                Owner = player;
            }
        }

        public class GameState
        {
            public bool IsGameOver { get; set; }
            public Player IsPlayerTurn { get; set; }
            public Player AWinnerIs { get; set; }

            public GameState(Player isPlayerTurn)
            {
                IsGameOver = false;
                IsPlayerTurn = isPlayerTurn;
                AWinnerIs = null;
            }

            public string GameOver() =>
                "Game has finished!";
        }

        public class Grid
        {
            public List<Disc>[] Columns { get; set; }
            public int ColsNum { get; }
            public int RowsNum { get; }

            public Grid(int cols = 7, int rows = 6)
            {
                ColsNum = cols;
                RowsNum = rows;
                Columns = new List<Disc>[7]
                {
                    new List<Disc>(), new List<Disc>(), new List<Disc>(), new List<Disc>(), new List<Disc>(), new List<Disc>(), new List<Disc>()
                };
            }
        }
    }
}