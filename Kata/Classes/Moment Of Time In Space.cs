using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// You are given a moment in time and space. What you must do is break it down into time and space, to determine if that moment is from the past, present or future.
    /// Time is the sum of characters that increase time (i.e. numbers in range ['1'..'9'].
    /// Space in the number of characters which do not increase time (i.e. all characters but those that increase time).
    /// The moment of time is determined as follows:
    /// If time is greater than space, then the moment is from the future. If time is less than space, then the moment is from the past. Otherwise, it is the present moment.
    /// You should return an array of three elements, two of which are false, and one is true.
    /// The true value should be at the 1st, 2nd or 3rd place for past, present and future respectively.
    /// </summary>
    internal class Moment_Of_Time_In_Space
    {
        public bool[] MomentOfTimeInSpace(string moment)
        {
            int time = moment.ToCharArray().Select(c => c >= '1' && c <= '9' ? int.Parse(c.ToString()) : 0).Sum();
            int space = moment.ToCharArray().Where(c => !(c >= '1' && c <= '9')).Count();

            return new[] { time < space, time == space, time > space };
        }
    }
}