using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class YourOrderPleaseTest
    {
        [Test, Description("Sample Tests")]
        public void SampleTest()
        {
            Assert.AreEqual("Thi1s is2 3a T4est", YourOrderPlease.Order("is2 Thi1s T4est 3a"));
            Assert.AreEqual("Fo1r the2 g3ood 4of th5e pe6ople", YourOrderPlease.Order("4of Fo1r pe6ople g3ood th5e the2"));
            Assert.AreEqual("", YourOrderPlease.Order(""));
        }
    }

    internal class YourOrderPlease
    {
        public static string Order(string words)
        {
            return words.Length > 0
                ? string.Join(" ", words
                    .Split(' ')
                    .ToDictionary(
                        k => k.First(c => char.IsDigit(c)),
                        v => v)
                    .OrderBy(d => d.Key)
                    .Select(d => d.Value))
                : string.Empty;
        }
    }
}