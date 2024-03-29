﻿using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public static class JohnMeetingTests
    {
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests");
            testing("Alexis:Wahl;John:Bell;Victoria:Schwarz;Abba:Dorny;Grace:Meta;Ann:Arno;Madison:STAN;Alex:Cornwell;Lewis:Kern;Megan:Stan;Alex:Korn",
                    "(ARNO, ANN)(BELL, JOHN)(CORNWELL, ALEX)(DORNY, ABBA)(KERN, LEWIS)(KORN, ALEX)(META, GRACE)(SCHWARZ, VICTORIA)(STAN, MADISON)(STAN, MEGAN)(WAHL, ALEXIS)");
            testing("John:Gates;Michael:Wahl;Megan:Bell;Paul:Dorries;James:Dorny;Lewis:Steve;Alex:Meta;Elizabeth:Russel;Anna:Korn;Ann:Kern;Amber:Cornwell",
                "(BELL, MEGAN)(CORNWELL, AMBER)(DORNY, JAMES)(DORRIES, PAUL)(GATES, JOHN)(KERN, ANN)(KORN, ANNA)(META, ALEX)(RUSSEL, ELIZABETH)(STEVE, LEWIS)(WAHL, MICHAEL)");
            testing("Alex:Arno;Alissa:Cornwell;Sarah:Bell;Andrew:Dorries;Ann:Kern;Haley:Arno;Paul:Dorny;Madison:Kern",
                "(ARNO, ALEX)(ARNO, HALEY)(BELL, SARAH)(CORNWELL, ALISSA)(DORNY, PAUL)(DORRIES, ANDREW)(KERN, ANN)(KERN, MADISON)");
        }

        private static void testing(string s, string expect)
        {
            Console.WriteLine("Testing\n" + s);
            string actual = JohnMeeting.Meeting(s);
            Console.WriteLine("Actual\n" + actual);
            Console.WriteLine("Expect\n" + expect);
            Console.WriteLine("-");
            Assert.AreEqual(expect, actual);
        }
    }

    internal class JohnMeeting
    {
        public static string Meeting(string s) =>
            string.Concat(s
                .ToUpper()
                .Split(';')
                .Select(s => $"({string.Join(", ", s.Split(':').Reverse())})")
                .OrderBy(s => s)
                .ToList());
    }
}