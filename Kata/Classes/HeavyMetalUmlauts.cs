using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    internal static class HeavyMetalUmlauts
    {
        public static string HeavyMetalUmlautsReplacer(string boringText)
        {
            Dictionary<char, char> dictionary = new()
            {
                { 'A' , 'Ä' },
                { 'E' , 'Ë' },
                { 'I' , 'Ï' },
                { 'O' , 'Ö' },
                { 'U' , 'Ü' },
                { 'Y' , 'Ÿ' },
                { 'a' , 'ä' },
                { 'e' , 'ë' },
                { 'i' , 'ï' },
                { 'o' , 'ö' },
                { 'u' , 'ü' },
                { 'y' , 'ÿ' },
            };

            return string.Concat(boringText.Select(c => dictionary.ContainsKey(c) ? dictionary.FirstOrDefault(d => d.Key == c).Value : c));
        }
    }

    [TestFixture]
    public class HeavyMetalUmlautsTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("Ännöüncïng thë Mäcböök Äïr Güïtär", HeavyMetalUmlauts.HeavyMetalUmlautsReplacer("Announcing the Macbook Air Guitar"));
            Assert.AreEqual("Fäcëböök ïntrödücës nëw hëävÿ mëtäl rëäctïön büttöns", HeavyMetalUmlauts.HeavyMetalUmlautsReplacer("Facebook introduces new heavy metal reaction buttons"));
            Assert.AreEqual("Ströng sälës öf Gööglë's VR Mëtälhëädsëts sënd tëch stöck prïcës söärïng", HeavyMetalUmlauts.HeavyMetalUmlautsReplacer("Strong sales of Google's VR Metalheadsets send tech stock prices soaring"));
            Assert.AreEqual("Vëgän Bläck Mëtäl Chëf hïts thë bïg tïmë ön Ämäzön TV", HeavyMetalUmlauts.HeavyMetalUmlautsReplacer("Vegan Black Metal Chef hits the big time on Amazon TV"));
        }
    }
}