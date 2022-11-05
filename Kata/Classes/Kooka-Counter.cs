using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
  internal class Kooka_Counter
  {
    public class Dinglemouse
    {
      public static int KookaCounter(string laughing)
      {
        return Regex.Matches(laughing, "([ha]+)|([Ha]+)").Count;
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      private static object[] Basic_Test_Cases = new object[]
      {
      new object[] {"hahahahahaHaHaHa", 2},
      new object[] {"hahahahaha", 1},
      new object[] {"HaHaHahahaHaHa", 3},
      new object[] {String.Empty, 0},
      };

      [Test, TestCaseSource(typeof(SolutionTest), "Basic_Test_Cases")]
      public void Basic_Test(string laughing, int expected)
      {
        Assert.AreEqual(expected, Dinglemouse.KookaCounter(laughing));
      }

      // Note: Random tests output total user solution execution time
    }
  }
}