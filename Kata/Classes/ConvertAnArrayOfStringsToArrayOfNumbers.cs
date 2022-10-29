using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
  internal class ConvertAnArrayOfStringsToArrayOfNumbers
  {
    public class stringArrayMethods
    {
      public static double[] ToDoubleArray(string[] stringArray)
      {
        return stringArray.Select(x => double.Parse(x)).ToArray();
      }
    }

    [TestFixture]
    public class stringArrayMethodsTest
    {
      [Test]
      public void ExampleTest()
      {
        Console.WriteLine("Running ToDoubleArray(\"1.1\",\"2.2\",\"3.3\")...");
        Assert.AreEqual(new double[] { 1.1, 2.2, 3.3 }, stringArrayMethods.ToDoubleArray(new string[] { "1.1", "2.2", "3.3" }));
      }
    }
  }
}