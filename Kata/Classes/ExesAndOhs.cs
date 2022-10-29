using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
  internal class ExesAndOhs
  {
    public static class Kata
    {
      public static bool XO(string input)
      {
        return input.Count(c => char.ToLower(c) == 'x') == input.Count(c => char.ToLower(c) == 'o');
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      [Test]
      public void ExampleTests()
      {
        Assert.AreEqual(true, Kata.XO("xo"));
        Assert.AreEqual(true, Kata.XO("xxOo"));
        Assert.AreEqual(false, Kata.XO("xxxm"));
        Assert.AreEqual(false, Kata.XO("Oo"));
        Assert.AreEqual(false, Kata.XO("ooom"));
      }
    }
  }
}