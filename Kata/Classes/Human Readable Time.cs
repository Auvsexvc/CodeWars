using System;

namespace Kata.Classes
{
    /// <summary>
    /// Write a function, which takes a non-negative integer (seconds) as input and returns the time in a human-readable format (HH:MM:SS)
    /// HH = hours, padded to 2 digits, range: 00 - 99
    /// MM = minutes, padded to 2 digits, range: 00 - 59
    /// SS = seconds, padded to 2 digits, range: 00 - 59
    /// The maximum time never exceeds 359999 (99:59:59)
    /// </summary>
    internal class Human_Readable_Time
    {
        public static string GetReadableTime(int seconds) =>
            String.Join(":", (new DateTime().AddSeconds(seconds).Hour + ((new DateTime().AddSeconds(seconds).Day - 1) * 24)).ToString("D2"), new DateTime().AddSeconds(seconds).ToString("mm:ss"));
    }
}