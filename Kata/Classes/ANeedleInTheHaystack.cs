using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Can you find the needle in the haystack?
    /// Write a function findNeedle() that takes an array full of junk but containing one "needle"
    ///After your function finds the needle it should return a message(as a string) that says:
    ///"found the needle at position " plus the index it found the needle, so:
    ///find_needle(['hay', 'junk', 'hay', 'hay', 'moreJunk', 'needle', 'randomJunk'])
    ///should return "found the needle at position 5" (in COBOL "found the needle at position 6")
    /// </summary>
    public static class ANeedleInTheHaystack
    {
        public static string FindNeedle(object[] haystack) =>
            string.Concat("found the needle at position ", haystack.Select((_, i) => i).FirstOrDefault(i => haystack.ElementAtOrDefault(i) is not null && haystack.ElementAtOrDefault(i)?.ToString() == "needle"));
    }

    [TestFixture]
    public class FindNeedleTest
    {
        [Test]
        public void GenericTests()
        {
            var haystack_1 = new object[] { '3', "123124234", null, "needle", "world", "hay", 2, '3', true, false };
            var haystack_2 = new object[] { "283497238987234", "a dog", "a cat", "some random junk", "a piece of hay", "needle", "something somebody lost a while ago" };
            var haystack_3 = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 8, 7, 5, 4, 3, 4, 5, 6, 67, 5, 5, 3, 3, 4, 2, 34, 234, 23, 4, 234, 324, 324, "needle", 1, 2, 3, 4, 5, 5, 6, 5, 4, 32, 3, 45, 54 };

            Assert.AreEqual("found the needle at position 3", ANeedleInTheHaystack.FindNeedle(haystack_1));
            Assert.AreEqual("found the needle at position 5", ANeedleInTheHaystack.FindNeedle(haystack_2));
            Assert.AreEqual("found the needle at position 30", ANeedleInTheHaystack.FindNeedle(haystack_3));
        }

        [Test]
        public static void ZRandomTests()
        {
            Console.WriteLine("\n ********** 50 Random Tests **********");
            Random rnd = new();
            List<object> list = new();
            for (int i = 0; i < 50; i++)
            {
                list.Clear();
                int rando = rnd.Next(1, 100);
                int randomIndex = rnd.Next(0, rando);
                for (int j = 0; j < rando; j++)
                {
                    if (j == randomIndex)
                    {
                        list.Add("needle");
                    }
                    else
                    {
                        int n = rnd.Next(0, 500);
                        list.Add(n);
                    }
                }
                Assert.AreEqual("found the needle at position " + randomIndex, ANeedleInTheHaystack.FindNeedle(list.ToArray()));
            }
        }
    }
}