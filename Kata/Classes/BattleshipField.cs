using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class BattleshipFieldTest
    {
        [Test]
        public void TestCase()
        {
            int[,] field = new int[10, 10]
                     {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                      {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                      {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Assert.IsTrue(BattleshipField.ValidateBattlefield(field));
        }

        [Test]
        public void TestCaseF()
        {
            int[,] field = new int[10, 10]
                     {{1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {1, 0, 1, 0, 0, 1, 1, 0, 1, 0},
                      {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
            Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
        }

        [Test]
        public void TestCaseF1()
        {
            int[,] field = new int[10, 10]

                      {
                          {1,0,0,0,0,1,1,0,0,0},
                          {1,0,1,0,0,0,0,0,1,0},
                          {1,0,1,0,1,1,1,0,1,0},
                          {1,0,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,1,0},
                          {0,0,0,0,1,1,1,0,0,0},
                          {0,0,0,1,0,0,0,0,1,0},
                          {0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,1,0,0},
                          {0,0,0,0,0,0,0,0,0,0}
                      };
            Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
        }
    }

    internal class BattleshipField
    {
        public static bool ValidateBattlefield(int[,] field)
        {
            List<int> ships = new();

            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    if (field[r, c] == 1)
                    {
                        if (((r + 1 < 10 && c + 1 < 10 && field[r + 1, c + 1] == 1)
                            || (r - 1 > 0 && c - 1 > 0 && field[r - 1, c - 1] == 1)
                            || (r + 1 < 10 && c - 1 > 0 && field[r + 1, c - 1] == 1)
                            || (r - 1 > 0 && c + 1 < 10 && field[r - 1, c + 1] == 1))) return false;

                        int shpLength = 1;

                        int i = r;
                        while (i + shpLength < 10 && field[i + shpLength, c] == 1)
                        {
                            field[i + shpLength++, c] = 0;
                        }

                        i = c;
                        while (i + shpLength < 10 && field[r, i + shpLength] == 1)
                        {
                            field[r, i + shpLength++] = 0;
                        }

                        ships.Add(shpLength);
                    }
                }
            }

            return string.Concat(ships.OrderBy(v => v)) == "1111222334";
        }
    }
}