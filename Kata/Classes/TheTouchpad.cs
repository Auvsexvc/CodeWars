using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class TheTouchpadTest
    {
        [TestCase(6, "6")]
        [TestCase(33, "33")]
        [TestCase(60, "60")]
        [TestCase(50, "50")]
        [TestCase(90, "90")]
        [TestCase(99, "99")]
        [TestCase(71, "111")]
        [TestCase(72, "72")]
        [TestCase(115, "155")]
        [TestCase(121, "201")]
        [TestCase(180, "300")]
        [TestCase(273, "433")]
        [TestCase(279, "399")]
        [TestCase(3179, "5259")]
        [TestCase(1018, "1658")]
        [TestCase(1256, "2056")]
        [TestCase(3236, "5356")]
        [TestCase(3690, "6130")]
        [TestCase(4697, "7777")]
        [TestCase(5255, "8735")]
        public void FixedTests(int time, string expected)
        {
            Act(time, expected);
        }

        private static void Act(int time, string expected)
        {
            var msg = $"Invalid answer for time: {time}";
            var actual = TheTouchpad.GetBestCombination(time);
            Assert.AreEqual(expected, actual, msg);
        }
    }

    internal static class TheTouchpad
    {
        public static string GetBestCombination(int time)
        {
            TimeSpan ts = TimeSpan.FromSeconds(time);

            double tsm = Math.Ceiling(ts.Seconds % 100 / 60.0);
            double m2;

            if (ts.Seconds < 40)
            {
                m2 = ((ts.Seconds) + 60);
            }
            else
            {
                m2 = ts.Seconds;
                tsm--;
            }

            if (ts.Minutes == 1 && ts.Seconds == 0)
                tsm = 1;

            string[] times =
            {
                $"{Math.Floor(ts.TotalMinutes):00}{ts.Seconds:00}",
                $"{Math.Floor(ts.TotalMinutes) - tsm:00}{m2:00}"
            };

            List<(string time, int count)> timesWithCount = new();

            foreach (var item in times)
            {
                int cMax = 0;
                for (int i = 0; i < item.Length; i++)
                {
                    int c = item.Skip(i).TakeWhile(x => x == item[i]).Count();
                    if (c > cMax) cMax = c;
                }
                timesWithCount.Add((item.TrimStart('0'), cMax));
            }

            return timesWithCount.OrderByDescending(x => x.count).ThenBy(x => x.time.Length).FirstOrDefault().time;
        }
    }
}