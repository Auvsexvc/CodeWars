using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    public class ArrhGrabscrab
    {
        public static List<string> Grabscrab(string anagram, List<string> dictionary)
        {
            return dictionary.Where(item => MakesTheSentence(anagram.ToCharArray().ToList(), item)).ToList();
        }

        private static bool MakesTheSentence(List<char> set, string toCreateFromSet)
        {
            if (set.Count < toCreateFromSet.Count(c => !char.IsWhiteSpace(c)))
                return false;

            foreach (char chr in toCreateFromSet.Where(c => !char.IsWhiteSpace(c)))
            {
                if (!set.Remove(chr))
                    return false;
            }

            return true;
        }
    }

    [TestFixture]
    public class GrabscrapTest
    {
        [Test, Description("should pass sample test cases")]
        public void SampleTest()
        {
            Assert.That(ArrhGrabscrab.Grabscrab("trisf", new List<string> { "first" }), Is.EqualTo(new List<string> { "first" }), "Should have found 'first'");
            Assert.That(ArrhGrabscrab.Grabscrab("oob", new List<string> { "bob", "baobab" }), Is.EqualTo(new List<string> { }), "Should not have found anything");
            Assert.That(ArrhGrabscrab.Grabscrab("ainstuomn", new List<string> { "mountains", "hills", "mesa" }), Is.EqualTo(new List<string> { "mountains" }), "Should have found 'mountains'");
            Assert.That(ArrhGrabscrab.Grabscrab("oolp", new List<string> { "donkey", "pool", "horse", "loop" }), Is.EqualTo(new List<string> { "pool", "loop" }), "Should have found 'pool' and 'loop'");
            Assert.That(ArrhGrabscrab.Grabscrab("ortsp", new List<string> { "sport", "parrot", "ports", "matey" }), Is.EqualTo(new List<string> { "sport", "ports" }), "Should have found 'sport' and 'ports'");
            Assert.That(ArrhGrabscrab.Grabscrab("ourf", new List<string> { "one", "two", "three" }), Is.EqualTo(new List<string> { }), "Should not have found anything");
        }
    }
}