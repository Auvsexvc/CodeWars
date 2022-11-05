using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
  public class ValidateCreditCardNumber
  {
    public class Solution
    {
      public static bool Validate(string n)
      {
        return n
          .Where(x => char.IsDigit(x))
          .Reverse()
          .Select(x => int.Parse(x.ToString()))
          .Select((v, i) => i % 2 == 0
            ? v
            : v * 2 > 9
              ? (v * 2) - 9
              : v * 2)
          .Sum() % 10 == 0;
      }
    }

    [TestFixture]
    public class SampleTests
    {
      [Test]
      public void TestCases()
      {
        var _ = new Solution();
        Assert.AreEqual(false, Solution.Validate("477 073 360"));
        Assert.AreEqual(true, Solution.Validate("5422 0148 5514"));
        Assert.AreEqual(true, Solution.Validate("8314 7046 0245"));
        Assert.AreEqual(false, Solution.Validate("6654 6310 43044"));
        Assert.AreEqual(true, Solution.Validate("0768 2757 5685 6340"));
        Assert.AreEqual(false, Solution.Validate("7164 6207 74042"));
        Assert.AreEqual(true, Solution.Validate("8383 7332 3570 8514"));
        Assert.AreEqual(true, Solution.Validate("481 135"));
        Assert.AreEqual(true, Solution.Validate("355 032 5363"));
      }
    }
  }
}