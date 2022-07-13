using NUnit.Framework;
using System;
using static Kata.Classes.AgeFromDob;

namespace Kata.Classes
{
    /// / <summary>
    /// / Create a function which passes in a birthday and returns how old a person is in years.
    ///     The Test Cases have already been developed for you.When the test case was created the programmer assumed there would be a shared interface between a SystemClock class and StaticClock class.
    /// public class SystemClock : IClock
    /// public class StaticClock : IClock
    /// The SystemClock class needs to implement a DateTime method that returns DateTime.Now
    /// The StaticClock method needs to implement a DateTime method that returns a DateTime value that was passed to its constructor.
    /// The StaticClock implementation of IClock is used in our UnitTest to provide a constant time value for our unittest. Considering that time is always in motion...if we were to simply create unit test based on DateTime.Now then our unit test will fail over time.
    /// With the StaticClock we can inject what value our IClock.Now method should return so our unit test will continue to pass even as time moves on.
    /// / </summary>
    internal class AgeFromDob
    {
        public class KataSol
        {
            private readonly IClock _date;

            public KataSol(IClock date)
            { _date = date; }

            public int GetAgeFromDOB(DateTime birthday) =>
                (int)(_date.Now - birthday.AddDays(LeapYearsDays(birthday.Year, _date.Now.Year))).TotalDays / 365;

            private static int LeapYearsDays(int fromYear, int toYear)
            {
                int days = 0;
                for (int year = fromYear; year <= toYear; year++)
                    days += DateTime.IsLeapYear(year) ? 1 : 0;
                return days;
            }
        }

        public interface IClock
        {
            DateTime Now { get; }
        }

        public class SystemClock : IClock
        {
            public DateTime Now => DateTime.Now;
        }

        public class StaticClock : IClock
        {
            public StaticClock(DateTime date) => Now = date;

            public DateTime Now { get; }
        }
    }

    [TestFixture]
    public class AgeFromDobTests
    {
        private KataSol _kata;

        [Test]
        public void SystemClock_IsEqualWithDateTimeNow()
        {
            Assert.AreEqual(DateTime.Now.Year, new SystemClock().Now.Year);
            Assert.AreEqual(DateTime.Now.Month, new SystemClock().Now.Month);
            Assert.AreEqual(DateTime.Now.Day, new SystemClock().Now.Day);
        }

        [Test]
        public void GetAgeFromDOB()
        {
            _kata = new KataSol(new StaticClock(new DateTime(2008, 09, 3)));
            Assert.AreEqual(24, _kata.GetAgeFromDOB(new DateTime(1984, 04, 23)));

            _kata = new KataSol(new StaticClock(new DateTime(2015, 09, 3)));
            Assert.AreEqual(31, _kata.GetAgeFromDOB(new DateTime(1984, 04, 23)));

            _kata = new KataSol(new StaticClock(new DateTime(2020, 11, 9)));
            Assert.AreEqual(36, _kata.GetAgeFromDOB(new DateTime(1984, 04, 23)));

            _kata = new KataSol(new StaticClock(new DateTime(2025, 08, 1)));
            Assert.AreEqual(38, _kata.GetAgeFromDOB(new DateTime(1987, 01, 15)));

            _kata = new KataSol(new StaticClock(new DateTime(2003, 01, 1)));
            Assert.AreEqual(1, _kata.GetAgeFromDOB(new DateTime(2002, 01, 01)));
        }

        [Test]
        public void GetAgeFromDOB_LeapYear()
        {
            _kata = new KataSol(new StaticClock(new DateTime(2005, 03, 31)));
            Assert.AreEqual(1, _kata.GetAgeFromDOB(new DateTime(2003, 04, 01)));

            _kata = new KataSol(new StaticClock(new DateTime(2008, 03, 31)));
            Assert.AreEqual(1, _kata.GetAgeFromDOB(new DateTime(2006, 04, 01)));
        }
    }
}