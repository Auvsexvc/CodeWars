using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
  public static class MorseCodeDecoder
  {
    public static string Decode(string morseCode)
    {
      Console.WriteLine(morseCode);
      return Regex.Replace(string.Concat(morseCode.Split(" ").Select(x => !string.IsNullOrWhiteSpace(x) ? x.GetCharForMorseSymbol() : " ")), @"\s+", " ").Trim();
    }

    private static string GetCharForMorseSymbol(this string str)
    {
      const char dot = '.';
      const char dash = '-';

      var d = new Dictionary<string, string>()
            {
                {"a", string.Concat(dot, dash)},
                {"b", string.Concat(dash, dot, dot, dot)},
                {"c", string.Concat(dash, dot, dash, dot)},
                {"d", string.Concat(dash, dot, dot)},
                {"e", dot.ToString()},
                {"f", string.Concat(dot, dot, dash, dot)},
                {"g", string.Concat(dash, dash, dot)},
                {"h", string.Concat(dot, dot, dot, dot)},
                {"i", string.Concat(dot, dot)},
                {"j", string.Concat(dot, dash, dash, dash)},
                {"k", string.Concat(dash, dot, dash)},
                {"l", string.Concat(dot, dash, dot, dot)},
                {"m", string.Concat(dash, dash)},
                {"n", string.Concat(dash, dot)},
                {"o", string.Concat(dash, dash, dash)},
                {"p", string.Concat(dot, dash, dash, dot)},
                {"q", string.Concat(dash, dash, dot, dash)},
                {"r", string.Concat(dot, dash, dot)},
                {"s", string.Concat(dot, dot, dot)},
                {"t", string.Concat(dash)},
                {"u", string.Concat(dot, dot, dash)},
                {"v", string.Concat(dot, dot, dot, dash)},
                {"w", string.Concat(dot, dash, dash)},
                {"x", string.Concat(dash, dot, dot, dash)},
                {"y", string.Concat(dash, dot, dash, dash)},
                {"z", string.Concat(dash, dash, dot, dot)},
                {"0", string.Concat(dash, dash, dash, dash, dash)},
                {"1", string.Concat(dot, dash, dash, dash, dash)},
                {"2", string.Concat(dot, dot, dash, dash, dash)},
                {"3", string.Concat(dot, dot, dot, dash, dash)},
                {"4", string.Concat(dot, dot, dot, dot, dash)},
                {"5", string.Concat(dot, dot, dot, dot, dot)},
                {"6", string.Concat(dash, dot, dot, dot, dot)},
                {"7", string.Concat(dash, dash, dot, dot, dot)},
                {"8", string.Concat(dash, dash, dash, dot, dot)},
                {"9", string.Concat(dash, dash, dash, dash, dot)},
                {",", string.Concat(dash, dash, dot, dot, dash, dash)},
                {"!", string.Concat(dash, dot, dash, dot, dash, dash)},
                {".", string.Concat(dot, dash, dot, dash, dot, dash)},
                {"SOS", string.Concat(dot, dot, dot, dash, dash, dash, dot, dot, dot)},
            };
      return d.FirstOrDefault(x => x.Value == str).Key.ToUpper();
    }

    [TestFixture]
    public class MorseCodeDecoderTests
    {
      [Test]
      public void MorseCodeDecoderBasicTest_1()
      {
        try
        {
          string input = ".... . -.--   .--- ..- -.. .";
          string expected = "HEY JUDE";

          string actual = MorseCodeDecoder.Decode(input);

          Assert.AreEqual(expected, actual);
        }
        catch (Exception ex)
        {
          Assert.Fail("There seems to be an error somewhere in your code. Exception message reads as follows: " + ex.Message);
        }
      }
    }
  }
}