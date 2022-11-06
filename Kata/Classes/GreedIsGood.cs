using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
  public class GreedIsGood
  {
    public static class Kata
    {
      public static int Score(int[] dice)
      {
        dice = dice
          .OrderByDescending(n => dice.Count(x => x == n))
          .Select((n, i) => dice.Count(x => x == n) >= 3 && i < 3
            ? 30 + n
            : n)
          .ToArray();

        return dice
                  .GroupBy(k => new
                  {
                    Triplets = dice.Count(x => x == k) >= 3,
                    Ones = dice.Count(x => x is 1 or 5 && x == k) == 1 || dice.Count(x => x is 1 or 5 && x == k) % 3 > 0
                  })
                  .Where(g => g.Key.Ones || g.Key.Triplets)
                  .SelectMany(g => g.Key.Triplets
                    ? g
                      .Distinct()
                      .Select(x => x == 31
                        ? 1000
                        : (x - 30) * 100)
                    : g
                      .Select(x => x == 1
                        ? 100
                        : 50)).Sum();
      }
    }

    public static class ScoreChecker
    {
      [Test]
      public static void ShouldBeWorthless()
      {
        Assert.AreEqual(0, Kata.Score(new int[] { 2, 3, 4, 6, 2 }), "Should be 0 :-(");
      }

      [Test]
      public static void ShouldValueTriplets()
      {
        Assert.AreEqual(400, Kata.Score(new int[] { 4, 4, 4, 3, 3 }), "Should be 400");
      }

      [Test]
      public static void ShouldValueMixedSets()
      {
        Assert.AreEqual(450, Kata.Score(new int[] { 2, 4, 4, 5, 4 }), "Should be 450");
      }

      [Test]
      public static void ShouldValueMixedSets1()
      {
        Assert.AreEqual(1100, Kata.Score(new int[] { 1, 1, 1, 1, 3 }), "Should be 1100");
      }

      [Test]
      public static void ShouldValueMixedSets2()
      {
        Assert.AreEqual(1150, Kata.Score(new int[] { 1, 1, 1, 1, 5 }), "Should be 1150");
      }

      [Test]
      public static void ShouldValueMixedSets3()
      {
        Assert.AreEqual(250, Kata.Score(new int[] { 1, 5, 1, 3, 4 }), "Should be 250");
      }

      [Test]
      public static void ShouldValueMixedSets4()
      {
        Assert.AreEqual(300, Kata.Score(new int[] { 3, 3, 3, 3, 3 }), "Should be 300");
      }
    }
  }
}