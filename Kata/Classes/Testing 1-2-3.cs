using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Your team is writing a fancy new text editor and you've been tasked with implementing the line numbering.
    /// Write a function which takes a list of strings and returns each line prepended by the correct number.
    ///    The numbering starts at 1. The format is n: string. Notice the colon and space in between.
    /// </summary>
    internal class Testing_1_2_3
    {
        public class LineNumbering
        {
            public static List<string> Number(List<string> lines) =>
                lines.Select((line, n) => (n + 1).ToString() + ": " + line).ToList();
        }
    }
}