using NUnit.Framework;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    [TestFixture]
    public class LoneliestCharacterSolutionTest
    {
        [Test]
        public void MyTest()
        {
            Assert.AreEqual(new char[] { 'b', 'c' }, LoneliestCharacter.Loneliest("a  b  c  de  ").OrderBy(x => x).ToArray());
            Assert.AreEqual(new char[] { 'g' }, LoneliestCharacter.Loneliest("abc d   ef  g   h i j      "));
            Assert.AreEqual(new char[] { 'a' }, LoneliestCharacter.Loneliest("a"));
            Assert.AreEqual(new char[] { 'b' }, LoneliestCharacter.Loneliest("a   b   c"));
            Assert.AreEqual(new char[] { 'z' }, LoneliestCharacter.Loneliest("  abc  d  z    f gk s "));
            Assert.AreEqual(new char[] { 'a', 'b', 'c' }, LoneliestCharacter.Loneliest("abc").OrderBy(x => x).ToArray());
        }
    }

    internal class LoneliestCharacter
    {
        public static char[] Loneliest(string result)
        {
            return result
                .Trim()
                .Where(c => !char.IsWhiteSpace(c))
                .GroupBy(c => Regex
                    .Match(result.Trim(), string.Format(@"([\s]*{0}[\s]*)", c))
                    .Value
                    .Count(char.IsWhiteSpace), c => c)
                .OrderByDescending(g=>g.Key)
                .Select(g => g.ToArray())
                .FirstOrDefault();
        }
    }
}