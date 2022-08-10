using NUnit.Framework;
using System.Linq;

namespace Kata.Classes
{
    public class StringRepeat
    {
        public static string RepeatStr(int n, string s) => string.Concat(Enumerable.Repeat(s, n));
    }

    [TestFixture]
    public class StringRepeatTest
    {
        [Test(Description = "Fixed Tests")]
        public void FixedTests()
        {
            Assert.AreEqual("***", StringRepeat.RepeatStr(3, "*"));
            Assert.AreEqual("#####", StringRepeat.RepeatStr(5, "#"));
            Assert.AreEqual("ha ha ", StringRepeat.RepeatStr(2, "ha "));
        }
    }
}