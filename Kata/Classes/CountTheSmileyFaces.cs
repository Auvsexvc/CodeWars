using NUnit.Framework;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    [TestFixture]
    public class CountTheSmileyFacesTest
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(4, CountTheSmileyFaces.CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }));
            Assert.AreEqual(2, CountTheSmileyFaces.CountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }));
            Assert.AreEqual(1, CountTheSmileyFaces.CountSmileys(new string[] { ";]", ":[", ";*", ":$", ";-D" }));
            Assert.AreEqual(0, CountTheSmileyFaces.CountSmileys(new string[] { ";", ")", ";*", ":$", "8-D" }));
        }
    }

    internal class CountTheSmileyFaces
    {
        public static int CountSmileys(string[] smileys)
        {
            return smileys.Count(s => Regex.IsMatch(s, @"^[:;]{1}[~-]{0,1}[\)D]{1}$"));
        }

        public static int CountSmileysA(string[] smileys)
        {
            int count = 0;
            char[] eyes = new char[] { ':', ';' };
            char[] noses = new char[] { '-', '~' };
            char[] mouths = new char[] { ')', 'D' };

            foreach (var item in smileys)
            {
                if (item.Length < 2 || !eyes.Contains(item[0]))
                    continue;

                switch (item.Length)
                {
                    case < 3:
                        if (!mouths.Contains(item[1]))
                            continue;
                        break;

                    default:
                        if (!noses.Contains(item[1]) || !mouths.Contains(item[2]))
                            continue;
                        break;
                }
                count++;
            }

            return count;
        }
    }
}