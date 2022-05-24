using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// The makeLooper() function (make_looper in Python) takes a string (of non-zero length) as an argument. It returns a function. The function it returns will return successive characters of the string on successive invocations. It will start back at the beginning of the string once it reaches the end.
    /// </summary>
    internal class Lazy_Repeater
    {
        private static int index = 0;
        public static Func<char> MakeLooper(string str) => () => str[index++ % str.Length];

    }
}
