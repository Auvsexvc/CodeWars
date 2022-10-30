using NUnit.Framework;
using System.Collections.Generic;

namespace Kata.Classes
{
  public class MakeTheDeadfishSwim
  {
    public class Deadfish
    {
      public static int[] Parse(string data)
      {
        List<int> output = new();
        int value = 0;
        using (var en = data.GetEnumerator())
        {
          while (en.MoveNext())
          {
            switch (en.Current)
            {
              case 'i':
                value++;
                break;

              case 'd':
                value--;
                break;

              case 's':
                value *= value;
                break;

              case 'o':
                output.Add(value);
                break;
            }
          }
        }

        return output.ToArray();
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      private static object[] sampleTestCases = new object[]
      {
      new object[] {"iiisdoso", new int[] {8, 64}},
      new object[] {"iiisdosodddddiso", new int[] {8, 64, 3600}},
      };

      [Test, TestCaseSource("sampleTestCases")]
      public void SampleTest(string data, int[] expected)
      {
        Assert.AreEqual(expected, Deadfish.Parse(data));
      }
    }
  }
}