using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class BasicNicoVariationTest
    {
        [Test]
        public void SampleNico()
        {
            Assert.AreEqual("cseerntiofarmit on  ", BasicNicoVariation.Nico("crazy", "secretinformation"));
            Assert.AreEqual("message", BasicNicoVariation.Nico("a", "message"));
            Assert.AreEqual("eky", BasicNicoVariation.Nico("key", "key"));
            Assert.AreEqual("abcd  ", BasicNicoVariation.Nico("abc", "abcd"));
            Assert.AreEqual("2143658709", BasicNicoVariation.Nico("ba", "1234567890"));
        }
    }

    internal static class BasicNicoVariation
    {
        public static string Nico(string key, string message)
        {
            if (key.Length <= 1)
            {
                return message;
            }

            var nKey = GetNumericKey(key);

            var g = Enumerable
                .Range(0, message.Length % key.Length != 0 ? message.Length + (key.Length - (message.Length % key.Length)) : message.Length)
                .GroupBy(r => (Chr: r < message.Length ? message[r] : ' ', Pos: nKey.Skip(r % nKey.Count()).First().NewIdx + ((r / nKey.Count()) * (nKey.Count() - 1))))
                .OrderBy(r => r.Key.Pos);

            return string.Concat(g.Select(g => g.Key.Chr));
        }

        private static IEnumerable<(int NewIdx, int OldIdx)> GetNumericKey(string key)
        {
            return key
                .Select((x, idx) => (chr: x, idx))
                .OrderBy(x => x.chr)
                .Select((x, i) => (NewIdx: i + 1, OldIdx: x.idx))
                .OrderBy(x => x.OldIdx);
        }
    }
}