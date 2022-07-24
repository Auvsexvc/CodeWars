using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Kata.Classes
{
    [TestFixture]
    public class WhatCenturyTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("20th", WhatCenturyKata.WhatCentury("2000"), "With input '2000' solution produced wrong output.");
            Assert.AreEqual("20th", WhatCenturyKata.WhatCentury("1999"), "With input '1999' solution produced wrong output.");
            Assert.AreEqual("21st", WhatCenturyKata.WhatCentury("2011"), "With input '2011' solution produced wrong output.");
            Assert.AreEqual("22nd", WhatCenturyKata.WhatCentury("2154"), "With input '2154' solution produced wrong output.");
            Assert.AreEqual("23rd", WhatCenturyKata.WhatCentury("2259"), "With input '2259' solution produced wrong output.");
        }
    }

    internal class WhatCenturyKata
    {
        public static string WhatCentury(string year)
        {
            int d = (int)Math.Ceiling(int.Parse(year) / 100.00);

            //return (s % 10) switch
            //{
            //    1 => s + "st",
            //    2 => s + "nd",
            //    3 => s + "rd",
            //    _ => s + "th",
            //};

            return string.Concat(d, new Dictionary<int, string>()
            {
                {1, "st" },
                {2, "nd" },
                {3, "rd" }
            }.TryGetValue(d < 10 || d > 20 ? d % 10 : -1, out var c) ? c : "th");
        }
    }
}