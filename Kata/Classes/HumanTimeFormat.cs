using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class HumanTimeFormatTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("now", HumanTimeFormat.FormatDuration(0));
            Assert.AreEqual("1 second", HumanTimeFormat.FormatDuration(1));
            Assert.AreEqual("1 minute and 2 seconds", HumanTimeFormat.FormatDuration(62));
            Assert.AreEqual("2 minutes", HumanTimeFormat.FormatDuration(120));
            Assert.AreEqual("1 hour, 1 minute and 2 seconds", HumanTimeFormat.FormatDuration(3662));
            Assert.AreEqual("182 days, 1 hour, 44 minutes and 40 seconds", HumanTimeFormat.FormatDuration(15731080));
            Assert.AreEqual("4 years, 68 days, 3 hours and 4 minutes", HumanTimeFormat.FormatDuration(132030240));
            Assert.AreEqual("6 years, 192 days, 13 hours, 3 minutes and 54 seconds", HumanTimeFormat.FormatDuration(205851834));
            Assert.AreEqual("8 years, 12 days, 13 hours, 41 minutes and 1 second", HumanTimeFormat.FormatDuration(253374061));
            Assert.AreEqual("7 years, 246 days, 15 hours, 32 minutes and 54 seconds", HumanTimeFormat.FormatDuration(242062374));
            Assert.AreEqual("3 years, 85 days, 1 hour, 9 minutes and 26 seconds", HumanTimeFormat.FormatDuration(101956166));
            Assert.AreEqual("1 year, 19 days, 18 hours, 19 minutes and 46 seconds", HumanTimeFormat.FormatDuration(33243586));
        }
    }

    internal class HumanTimeFormat
    {
        public static string FormatDuration(int seconds)
        {
            var listOfHTFParts = new Dictionary<string, double>()
            {
                { "year" , TimeSpan.FromSeconds(seconds).Days / 365 },
                { "day", TimeSpan.FromSeconds(seconds).Days % 365 },
                { "hour", TimeSpan.FromSeconds(seconds).Hours % 24 },
                { "minute", TimeSpan.FromSeconds(seconds).Minutes % 60 },
                { "second", TimeSpan.FromSeconds(seconds).Seconds % 60 }
            }.Where(d => d.Value > 0)
            .Select(d => d.Value > 1 ? $"{d.Value} {d.Key}s" : $"{d.Value} {d.Key}");

            return seconds > 0
                ? string.Concat(listOfHTFParts.Select((d, i) => i > 0 && i == listOfHTFParts.Count() - 1
                    ? $" and {d}"
                    : i == 0
                        ? $"{d}"
                        : $", {d}"))
                : "now";
        }
    }
}