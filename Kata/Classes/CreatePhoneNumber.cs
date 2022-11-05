using NUnit.Framework;
using System.Linq;
using System.Text;

namespace Kata.Classes
{
  public class CreatePhoneNumber
  {
    public class Kata
    {
      public static string CreatePhoneNumber(int[] numbers)
      {
        return new StringBuilder("(")
          .AppendJoin("", numbers.Select((v, i) => i == 2
            ? $"{v}) "
            : i == 5
              ? $"{v}-"
              : v.ToString()))
          .ToString();
      }
    }

    [TestFixture]
    public class Tests
    {
      [Test]
      [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, ExpectedResult = "(123) 456-7890")]
      [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = "(111) 111-1111")]
      public static string FixedTest(int[] numbers)
      {
        return Kata.CreatePhoneNumber(numbers);
      }
    }
  }
}