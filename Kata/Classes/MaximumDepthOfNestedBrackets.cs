using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
  internal class MaximumDepthOfNestedBrackets
  {
    public class SolutionMaxDepth
    {
      public static List<string> StringsInMaxDepth(string s)
      {
        if (string.IsNullOrEmpty(s) || !s.Contains('('))
        {
          return new List<string>() { s };
        }

        List<(int start, int depth)> list = new List<(int start, int depth)>();
        int d = 0;

        for (int i = 0; i < s.Length; i++)
        {
          if (s[i] == '(')
          {
            d++;
            list.Add((i, d));
          }
          else if (s[i] == ')')
          {
            d--;
          }
        }

        return list.GroupBy(x => x.depth)
                   .OrderByDescending(g => g.Key)
                   .FirstOrDefault()
                   .Select(x => string.Concat(s.Skip(++x.start).TakeWhile(c => c != ')')))
                   .ToList();
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      [Test]
      public static void Example_Tests()
      {
        string s = "AA(XX((YY))(U))";
        List<string> expected = new List<string>(new string[] { "YY" });
        Assert.AreEqual(expected, SolutionMaxDepth.StringsInMaxDepth(s));

        s = "((AAX(AB)(UP)F(Z))(HH))";
        expected = new List<string>(new string[] { "AB", "UP", "Z" });
        Assert.AreEqual(expected, SolutionMaxDepth.StringsInMaxDepth(s));

        s = "FB(TAIHJK(NZZCGDZXKF(SYMBLACQ)SBJMRFM)PRTRX(JCLYCOXIMOKGGIE)MWIOIJDCLXDSQFHK)WLVYSMNNHIGKR(MOIZLOT(RWMAVXSJQROHJ(GZURPPOQJVMYCE(VCPXSHXQ)LETIEWE(CBC)AAHEEO)NZHIGXBSJATXV)BSBYCMKFFAFZIK(KECNRQ)PIIQZGIDMLNQRQS)VGXXBYD";
        expected = new List<string>(new string[] { "VCPXSHXQ", "CBC" });
        Assert.AreEqual(expected, SolutionMaxDepth.StringsInMaxDepth(s));

        s = "AAA";
        expected = new List<string>(new string[] { "AAA" });
        Assert.AreEqual(expected, SolutionMaxDepth.StringsInMaxDepth(s));

        s = "";
        expected = new List<string>(new string[] { "" });
        Assert.AreEqual(expected, SolutionMaxDepth.StringsInMaxDepth(s));
      }
    }
  }
}