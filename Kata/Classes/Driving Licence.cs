﻿using System;
using System.Globalization;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// The UK driving number is made up from the personal details of the driver. The individual letters and digits can be code using the below information
    /// 1–5: The first five characters of the surname (padded with 9s if less than 5 characters)
    /// 6: The decade digit from the year of birth (e.g. for 1987 it would be 8)
    /// 7–8: The month of birth (7th character incremented by 5 if driver is female i.e. 51–62 instead of 01–12)
    /// 9–10: The date within the month of birth
    /// 11: The year digit from the year of birth (e.g. for 1987 it would be 7)
    /// 12–13: The first two initials of the first name and middle name, padded with a 9 if no middle name
    /// 14: Arbitrary digit – usually 9, but decremented to differentiate drivers with the first 13 characters in common. We will always use 9
    /// 15–16: Two computer check digits. We will always use "AA"
    ///
    /// Your task is to code a UK driving license number using an Array of data. The Array will look like
    /// data = ["John","James","Smith","01-Jan-2000","M"];
    /// 0 = Forename
    /// 1 = Middle Name(if any)
    /// 2 = Surname
    /// 3 = Date of Birth(In the format Day Month Year, this could include the full Month name or just shorthand ie September or Sep)
    /// 4 = M-Male or F-Female
    /// You will need to output the full 16 digit driving license number.
    /// </summary>
    internal class Driving_Licence
    {
        public string driver(params string[] data) =>
            new CultureInfo("en-US", false)
            .TextInfo
            .ToUpper
            (
                string.Join
                (
                    "",
                    data[2].Length >= 5 ? string.Join("", data[2].Take(5)) : data[2] + string.Join("", Enumerable.Range(0, 5 - data[2].Length).Select(_ => "9")),
                    DateTime.Parse(data[3]).ToString("yy").FirstOrDefault(),
                    data[4] == "M" ? DateTime.Parse(data[3]).ToString("MM") : (Int32.Parse(DateTime.Parse(data[3]).ToString("MM")) + 50).ToString(),
                    DateTime.Parse(data[3]).ToString("dd"),
                    data[3].LastOrDefault(),
                    data[1].Length != 0 ? string.Join("", data[0].FirstOrDefault(), data[1].FirstOrDefault()) : data[0].FirstOrDefault() + "9",
                    "9",
                    "AA"
                )
            );
    }
}