using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    [TestFixture]
    public class SplitStringTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new string[] { "ab", "c_" }, SplitStrings.Solution("abc"));
            Assert.AreEqual(new string[] { "ab", "cd", "ef" }, SplitStrings.Solution("abcdef"));
        }
    }

    internal class SplitStrings
    {
        public static string[] Solution(string str)
        {
            return Regex.Matches(str + "_", @"\w{2}").Select(x => x.Value).ToArray();
        }

        public static string[] Solution2(string str)
        {
            List<string> list = new List<string>();
            while (str.Length > 0)
            {
                if (str.Length == 1)
                {
                    str += '_';
                }
                list.Add(str.Substring(0, 2));
                str = str.Remove(0, 2);
            }

            return list.ToArray();
        }
    }
}