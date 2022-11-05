using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
  public class DuplicateEncoder
  {
    public class Kata
    {
      public static string DuplicateEncode(string word)
      {
        return string.Concat(word.SelectMany(c => word
          .GroupBy(k => new { Symbol = k, IsDuplicated = word.Count(x => char.ToLower(x) == char.ToLower(k)) > 1 })
          .Where(g => g.Key.Symbol == c)
          .Select(g => g.Key.IsDuplicated
            ? ')'
            : '(')));
      }
    }

    [TestFixture]
    public class KataTests
    {
      [Test]
      public void BasicTests()
      {
        Assert.AreEqual("(((", Kata.DuplicateEncode("din"));
        Assert.AreEqual("()()()", Kata.DuplicateEncode("recede"));
        Assert.AreEqual(")())())", Kata.DuplicateEncode("Success"), "should ignore case");
        Assert.AreEqual("))((", Kata.DuplicateEncode("(( @"));
      }
    }
  }
}