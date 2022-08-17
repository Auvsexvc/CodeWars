using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    public class MultiplesOf3Or5
    {
        public static int Solution(int value)
        {
            return ListMultiplesOf3Or5(value).Sum();
        }

        public static IEnumerable<int> ListMultiplesOf3Or5(int value)
        {
            for (int i = 0; i < value; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    yield return i;
                }
            }
        }
    }

    [TestFixture]
    public class MultiplesOf3Or5Tests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(23, MultiplesOf3Or5.Solution(10));
        }
    }
}