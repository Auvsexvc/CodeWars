using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
  public class TwoSum
  {
    public class Kata
    {
      public static int[] TwoSum(int[] numbers, int target)
      {
        return numbers
          .Select((v, i) => numbers
            .Select((u, j) => i != j && v + u == target
              ? new int[] { i, j }
              : null)
            .FirstOrDefault(x => x != null))
          .FirstOrDefault(x => x != null);
      }
    }

    [TestFixture]
    public class KataTests
    {
      [Test]
      public void BasicTests()
      {
        Assert.AreEqual(new[] { 0, 2 }, Kata.TwoSum(new[] { 1, 2, 3 }, 4).OrderBy(a => a).ToArray());
        Assert.AreEqual(new[] { 1, 2 }, Kata.TwoSum(new[] { 1234, 5678, 9012 }, 14690).OrderBy(a => a).ToArray());
        Assert.AreEqual(new[] { 0, 1 }, Kata.TwoSum(new[] { 2, 2, 3 }, 4).OrderBy(a => a).ToArray());
      }
    }
  }
}