using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
  internal class DoesMyNumberLookBigInThis
  {
    public class Kata
    {
      public static bool Narcissistic(int value)
      {
        return value
          .ToString()
          .Select(d => Math.Pow(int.Parse(d.ToString()), value.ToString().Length))
          .Sum() == value;
      }
    }

    [TestFixture]
    public class Sample_Test
    {
      private static IEnumerable<TestCaseData> testCases
      {
        get
        {
          yield return new TestCaseData(1)
                          .Returns(true)
                          .SetDescription("1 is narcissitic");
          yield return new TestCaseData(371)
                          .Returns(true)
                          .SetDescription("371 is narcissitic");
        }
      }

      [Test, TestCaseSource("testCases")]
      public bool Test(int n) => Kata.Narcissistic(n);
    }
  }
}