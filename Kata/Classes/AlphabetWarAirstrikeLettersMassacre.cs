using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    public static class AlphabetWarAirstrikeLettersMassacre
    {
        public static string AlphabetWar(string fight)
        {
            var combatPowers = new Dictionary<int, char[]> { { 4, new char[] { 'w', 'm' } }, { 3, new char[] { 'p', 'q' } }, { 2, new char[] { 'b', 'd' } }, { 1, new char[] { 's', 'z' } } };

            var resolution = Regex.Replace(fight, @"([a-z\*][\*][a-z]|[a-z\*][\*]|[\*][a-z\*])", "")
                .Where(survivor => combatPowers.Values.Any(x => x.Contains(survivor)))
                .GroupBy(combatant => new List<char> { 'w', 'p', 'b', 's' }.Contains(combatant))
                .Select(army => (IsLeftSide: army.Key, TotalPower: army.Select(combatant => combatPowers.First(power => power.Value.Contains(combatant)).Key).Sum()))
                .Sum(army => army.IsLeftSide
                    ? army.TotalPower
                    : -army.TotalPower);

            return resolution switch
            {
                0 => "Let's fight again!",
                > 0 => "Left side wins!",
                _ => "Right side wins!"
            };
        }
    }

    [TestFixture]
    public class AlphabetWarTest
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual("Let's fight again!", AlphabetWarAirstrikeLettersMassacre.AlphabetWar("*bs**d**qxn"));
            Assert.AreEqual("Left side wins!", AlphabetWarAirstrikeLettersMassacre.AlphabetWar("ybc**ms*"));
            Assert.AreEqual("Left side wins!", AlphabetWarAirstrikeLettersMassacre.AlphabetWar("xbhz"));
            Assert.AreEqual("Right side wins!", AlphabetWarAirstrikeLettersMassacre.AlphabetWar("zz*zzs"));
            Assert.AreEqual("Let's fight again!", AlphabetWarAirstrikeLettersMassacre.AlphabetWar("z*dq*mw*pb*s"));
            Assert.AreEqual("Right side wins!", AlphabetWarAirstrikeLettersMassacre.AlphabetWar("z"));
            Assert.AreEqual("Let's fight again!", AlphabetWarAirstrikeLettersMassacre.AlphabetWar("****"));
            Assert.AreEqual("Let's fight again!", AlphabetWarAirstrikeLettersMassacre.AlphabetWar("zdqmwpbs"));
            Assert.AreEqual("Left side wins!", AlphabetWarAirstrikeLettersMassacre.AlphabetWar("*wwwwww*z*"));
        }
    }
}