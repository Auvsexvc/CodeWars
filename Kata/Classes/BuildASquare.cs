using NUnit.Framework;
using System.Text;

namespace Kata.Classes
{
  internal class BuildASquare
  {
    public static class Kata
    {
      public static string GenerateShape(int n)
      {
        StringBuilder sb = new();
        for (int i = 1; i <= n; i++)
        {
          for (int j = 1; j <= n; j++)
          {
            sb.Append('+');
          }
          if (i != n)
            sb.Append('\n');
        }
        return sb.ToString();
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      [Test]
      public void SampleTest()
      {
        Assert.AreEqual("", Kata.GenerateShape(0));
        Assert.AreEqual("+", Kata.GenerateShape(1));
        Assert.AreEqual("++\n++", Kata.GenerateShape(2));
        Assert.AreEqual("+++\n+++\n+++", Kata.GenerateShape(3));
      }
    }
  }
}