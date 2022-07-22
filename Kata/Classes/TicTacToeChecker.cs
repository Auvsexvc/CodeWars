using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class TicTacToeTest
    {
        private readonly TicTacToeChecker tictactoe = new TicTacToeChecker();

        [Test]
        public void TestingReturnOfIsSolvedMethod()
        {
            var boards = new Dictionary<int[,], int>();
            boards.Add(new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } }, 1);
            boards.Add(new int[,] { { 1, 2, 0 }, { 0, 1, 2 }, { 0, 0, 1 } }, 1);
            boards.Add(new int[,] { { 2, 1, 1 }, { 0, 1, 1 }, { 2, 2, 2 } }, 2);
            boards.Add(new int[,] { { 2, 2, 2 }, { 0, 1, 1 }, { 1, 0, 0 } }, 2);
            boards.Add(new int[,] { { 2, 1, 2 }, { 2, 1, 1 }, { 1, 2, 1 } }, 0);
            boards.Add(new int[,] { { 1, 2, 1 }, { 1, 1, 2 }, { 2, 1, 2 } }, 0);
            boards.Add(new int[,] { { 2, 0, 2 }, { 2, 1, 1 }, { 1, 2, 1 } }, -1);
            boards.Add(new int[,] { { 0, 0, 2 }, { 0, 0, 0 }, { 1, 0, 1 } }, -1);
            boards.Add(new int[,] { { 1, 2, 1 }, { 1, 1, 2 }, { 2, 2, 0 } }, -1);
            boards.Add(new int[,] { { 0, 2, 2 }, { 2, 1, 1 }, { 0, 0, 1 } }, -1);
            boards.Add(new int[,] { { 0, 1, 1 }, { 2, 0, 2 }, { 2, 1, 0 } }, -1);

            Random r = new Random();
            boards = boards.OrderBy(o => r.Next()).ToDictionary(b => b.Key, b => b.Value);

            foreach (KeyValuePair<int[,], int> boardMap in boards)
            {
                var actual = tictactoe.IsSolved(boardMap.Key);
                var expected = boardMap.Value;
                var err = String.Join(" ", boardMap.Key.OfType<int>().Select((n, i) => (i % 3) == 0 ? "\n" + n : "" + n));
                Assert.AreEqual(expected, actual, "For the following board: " + err);
            }
        }
    }

    internal class TicTacToeChecker
    {
        public int IsSolved(int[,] board)
        {
            bool unfinished = false;
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    for (int p = 1; p <= 2; p++)
                    {
                        if (new[] { board[r, 0], board[r, 1], board[r, 2] }.All(x => x == p)
                            || new[] { board[0, c], board[1, c], board[2, c] }.All(x => x == p)
                            || new[] { board[0, 0], board[1, 1], board[2, 2] }.All(x => x == p)
                            || new[] { board[0, 2], board[1, 1], board[2, 0] }.All(x => x == p))
                        {
                            return p;
                        }
                    }
                    if(board[r, c] == 0)
                    {
                        unfinished = true;
                    }
                }
            }
            return !unfinished ? 0 : -1;
        }
    }
}