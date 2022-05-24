using System;

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
    internal class Age_from_DOB
    {
        public class Kata
        {
            private IClock _date;

            public Kata(IClock date)
            { _date = date; }

            public int GetAgeFromDOB(DateTime birthday) =>
                (int)(_date.Now - birthday.AddDays(LeapYearsDays(birthday.Year, _date.Now.Year))).TotalDays / 365;

            private int LeapYearsDays(int fromYear, int toYear)
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
            private DateTime _idate;

            public StaticClock(DateTime date)
            { _idate = date; }

            public DateTime Now => _idate;
        }
    }
}