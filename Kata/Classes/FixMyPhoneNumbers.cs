using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
  internal class FixMyPhoneNumbers
  {
    public static class Kata
    {
      public static String IsItANum(string str)
      {
        var strDigitsOnly = string.Concat(str.Where(c => char.IsDigit(c)));

        return strDigitsOnly.StartsWith('0') && strDigitsOnly.Length == 11
          ? strDigitsOnly
          : "Not a phone number";
      }

      public static string IsItANumRegex(string str)
      {
        var phone = Regex.Replace(str, @"\D", "");
        return Regex.IsMatch(phone, @"^0\d{10}$") ? phone : "Not a phone number";
      }
    }

    [TestFixture]
    public class SolutionTest
    {
      [Test]
      public void SampleTest()
      {
        Assert.AreEqual("02078834982", Kata.IsItANum("S:)0207ERGQREG88349F82!efRF)"));
        Assert.AreEqual("Not a phone number", Kata.IsItANum("sjfniebienvr12312312312ehfWh"));
        Assert.AreEqual("Not a phone number", Kata.IsItANum("0192387415456"));
        Assert.AreEqual("02084564165", Kata.IsItANum("v   uf  f 0tt2eg qe0b 8rtyq4eyq564()(((((165"));
        Assert.AreEqual("Not a phone number", Kata.IsItANum("stop calling me no I have never been in an accident"));
      }
    }
  }
}