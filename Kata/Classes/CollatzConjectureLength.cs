using NUnit.Framework;

namespace Kata.Classes
{
    [TestFixture]
    public class CollatzConjectureLengthTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(8, CollatzConjectureLength.Collatz(20));
            Assert.AreEqual(18, CollatzConjectureLength.Collatz(15));
        }
    }

    internal class CollatzConjectureLength
    {
        public static int Collatz(int n)
        {
            int ret = 1;
            while (n > 1)
            {
                n = (n % 2) switch
                {
                    0 => n / 2,
                    _ => (n * 3) + 1,
                };
                ret++;
            }

            return ret;
        }
    }
}