using System;

namespace Kata.Classes
{
    /// <summary>
    /// Count the number of days between two dates:
    /// There are 5021 days between 1987.1.16 and 2000.10.15
    /// </summary>
    internal class Count_the_number_of_days_between_two_dates
    {
        public static long GetDaysAlive(int year, int month, int day, int year2, int month2, int day2) =>
            (new DateTime(year2, month2, day2) - new DateTime(year, month, day)).Days;
    }
}