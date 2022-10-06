using NUnit.Framework;

namespace Kata.Classes
{
    [TestFixture]
    public class CatsAndShelvesTests
    {
        [Test]
        public static void Mew()
        {
            testing(CatsAndShelves.Cats(1, 5), 2);
        }

        [Test]
        public static void OneMoreMew()
        {
            testing(CatsAndShelves.Cats(2, 5), 1);
        }

        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }

    internal class CatsAndShelves
    {
        public static int Cats(int start, int finish)
        {
            const int maxJump = 3;

            int jumps = 0;
            var position = start;

            while (position < finish)
            {
                jumps++;
                if (finish - position < maxJump)
                {
                    position++;
                    continue;
                }
                position += maxJump;
            }

            return jumps;
        }
    }
}