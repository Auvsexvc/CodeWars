using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
  internal class GravityFlip
  {
    public class Kata
    {
      public static int[] Flip(char dir, int[] arr)
      {
        return dir == 'R'
          ? arr.OrderBy(x => x).ToArray()
          : arr.OrderByDescending(x => x).ToArray();
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      [Test]
      public void Sample()
      {
        Assert.AreEqual(new int[] { 1, 2, 2, 3 }, Kata.Flip('R', new int[] { 3, 2, 1, 2 }));
        Assert.AreEqual(new int[] { 5, 5, 4, 3, 1 }, Kata.Flip('L', new int[] { 1, 4, 5, 3, 5 }));
      }
    }
  }
}