using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    internal class BasicDeNico
    {
        public static string DeNico(string key, string message)
        {
            if (key.Length <= 1)
            {
                return message;
            }

            var nKey = GetNumericKey(key).Select(x=>x.OldIdx);

            var g = Enumerable
                .Range(0, message.Length % key.Length != 0 ? message.Length + (key.Length - (message.Length % key.Length)) : message.Length)
                .GroupBy(r => (I: r, Chr: r < message.Length ? message[r] : ' ', Pos: nKey.Skip(r % nKey.Count()).First() + ((r / nKey.Count()) * (nKey.Count() - 1))))
                .OrderBy(x=>x.Key.Pos);


            return string.Concat(g.Select(g => g.Key.Chr)).TrimEnd();
        }

        private static IEnumerable<(int NewIdx, int OldIdx)> GetNumericKey(string key)
        {
            return key
                .Select((x, idx) => (chr: x, idx))
                .OrderBy(x => x.chr)
                .Select((x, i) => (NewIdx: i + 1, OldIdx: x.idx))
                .OrderBy(x => x.NewIdx);
        }
    }

    [TestFixture]
    public class BasicDeNicoTest
    {
        [Test]
        public void SampleDeNico()
        {
            Assert.AreEqual("secretinformation", BasicDeNico.DeNico("crazy", "cseerntiofarmit on  "));
            Assert.AreEqual("secretinformation", BasicDeNico.DeNico("crazy", "cseerntiofarmit on"));
            Assert.AreEqual("abcd", BasicDeNico.DeNico("abc", "abcd"));
            Assert.AreEqual("1234567890", BasicDeNico.DeNico("ba", "2143658709"));
            Assert.AreEqual("message", BasicDeNico.DeNico("a", "message"));
            Assert.AreEqual("key", BasicDeNico.DeNico("key", "eky"));
        }
    }
}
