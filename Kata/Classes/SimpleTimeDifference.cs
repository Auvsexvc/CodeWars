using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    internal class SimpleTimeDifference
    {
        public class Solution
        {
            public static string solve(string[] arr)
            {
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }

                var ringDuration = new TimeSpan(0, 1, 0);

                if (arr.Length > 1)
                {
                    var timeSpans = ToOrderedTimeSpans(arr);
                    var arrangedPairs = ArrangeAlarmsInPairs(timeSpans);
                    var maxInterval = GetMaxInterval(ringDuration, arrangedPairs);

                    return maxInterval.ToString(@"hh\:mm");
                }

                return new TimeSpan(24, 0, 0).Subtract(ringDuration).ToString(@"hh\:mm");
            }

            private static TimeSpan GetMaxInterval(TimeSpan ringDuration, IEnumerable<(TimeSpan First, TimeSpan Second)> arrangedPairs) =>
                arrangedPairs.Max(t => t.First >= t.Second
                    ? t.First.Subtract(t.Second.Add(ringDuration))
                    : t.First.Add(new TimeSpan(24, 0, 0)).Subtract(t.Second.Add(ringDuration)));

            private static IEnumerable<(TimeSpan First, TimeSpan Second)> ArrangeAlarmsInPairs(IEnumerable<TimeSpan> timeSpans) =>
                timeSpans
                    .Zip(timeSpans
                        .TakeLast(1)
                        .Concat(timeSpans.SkipLast(1)));

            private static IEnumerable<TimeSpan> ToOrderedTimeSpans(string[] arr) =>
                arr
                    .Select(x => new TimeSpan(int.Parse(x.Split(':')[0]), int.Parse(x.Split(':')[1]), 0))
                    .OrderBy(t => t.TotalMinutes);
        }

        [TestFixture]
        public class SolutionTest
        {
            [Test]
            public void ExampleTests()
            {
                Assert.AreEqual("23:59", Solution.solve(new String[] { "14:51" }));
                Assert.AreEqual("09:10", Solution.solve(new String[] { "21:14", "15:34", "14:51", "06:25", "15:30" }));
                Assert.AreEqual("11:40", Solution.solve(new String[] { "23:00", "04:22", "18:05", "06:24" }));
            }
        }
    }
}