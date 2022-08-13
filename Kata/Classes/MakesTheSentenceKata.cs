using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class MakesTheSentenceKataTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.That(MakesTheSentenceKata.MakesTheSentence(new List<char> { 'D', 'u', 'c', 'k', 's', 'q', 'u', 'a', 'c', 'k', '.' }, "Ducks quack."), Is.EqualTo(true));
            Assert.That(MakesTheSentenceKata.MakesTheSentence(new List<char> { 'S', 'h', 'e', 'a', 'd', 's', '.' }, "She adds."), Is.EqualTo(false));
            //Assert.That(MakesTheSentenceKata.MakesTheSentence(new List<char> { 'j', 'm', 'j', 'f', 'd', 'c', 'n', '!', 't', 'I', 'u', 'b', 'k', 'y', 'n', 'e', 'm', 'l', 'k', 'e', 'x', 'j', 'p', 't', 'b', 'q', 'z', 't', 'd', 't', 'q', 'y', 'g', 'u', 'f', 'p', 'e', 'y', 'l', 'x', 'p', 'h', 'v', 'v', 'k', 'z', 'f', 'x' }, "Iftpyucn mpvxf ebfhdnj mgujqlkz eydtxez qpbkyv jttxlk!"), Is.EqualTo(false));
        }
    }

    internal class MakesTheSentenceKata
    {
        public static bool MakesTheSentence(List<char> characters, string sentence)
        {
            if (characters.Count < sentence.Count(c => !char.IsWhiteSpace(c)))
                return false;

            foreach (char item in sentence.Where(c => !char.IsWhiteSpace(c)))
            {
                if (!characters.Remove(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}