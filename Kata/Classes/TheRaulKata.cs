using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
  public class TheRaulKata
  {
    public class Raul
    {
      public static Dictionary<string, string> KeywordDictionary = new Dictionary<string, string>()
      {
        {"finally", "C#" },
        {"if", "C#" },
        {"goal", "football" }
      };

      public static List<string>[] SeparateKeywords(string[] keywords)
      {
        var ret = KeywordDictionary
          .GroupBy(d => d.Value)
          .OrderBy(g => g.Key)
          .Select(g => g
            .Where(d => keywords.Contains(d.Key))
            .Select(d => d.Key)
            .OrderBy(x => x)
            .ToList())
          .ToArray();

        return ret;
      }
    }

    public class RaulSolutionTests
    {
      [Test]
      public void BasicTests()
      {
        var output = Raul.SeparateKeywords(new[] { "if", "finally", "goal" });
        Assert.AreEqual(2, output.Length, "Array must contain two lists!");
        Assert.AreEqual(2, output[0].Count, "Unexpected length for C#-keywords");
        Assert.AreEqual(1, output[1].Count, "Unexpected length for football-keywords");
        Assert.AreEqual(string.Join(", ", new[] { "finally", "if" }), string.Join(", ", output[0]));
        Assert.AreEqual(string.Join(", ", new[] { "goal" }), string.Join(", ", output[1]));

        output = Raul.SeparateKeywords(new[] { "class" });
        Assert.AreEqual(2, output.Length, "Array must contain two lists!");
        Assert.AreEqual(1, output[0].Count, "Unexpected length for C#-keywords");
        Assert.AreEqual(0, output[1].Count, "Unexpected length for football-keywords");
        Assert.AreEqual(string.Join(", ", new[] { "class" }), string.Join(", ", output[0]));

        output = Raul.SeparateKeywords(new[] { "namespace", "strawberry", "function", "team", "null", "privat", "public", "trainer" });
        Assert.AreEqual(2, output.Length, "Array must contain two lists!");
        Assert.AreEqual(3, output[0].Count, "Unexpected length for C#-keywords");
        Assert.AreEqual(2, output[1].Count, "Unexpected length for football-keywords");
        Assert.AreEqual(string.Join(", ", new[] { "namespace", "null", "public" }), string.Join(", ", output[0]));
        Assert.AreEqual(string.Join(", ", new[] { "team", "trainer" }), string.Join(", ", output[1]));
      }
    }
  }
}