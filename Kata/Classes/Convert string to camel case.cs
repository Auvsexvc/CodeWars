using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Complete the method/function so that it converts dash/underscore delimited words into camel casing. The first word within the output should be capitalized only if the original word was capitalized (known as Upper Camel Case, also often referred to as Pascal case).
    /// </summary>
    internal class Convert_string_to_camel_case
    {
        public static string ToCamelCase(string str) =>
            string.Concat(str.Split('-', '_').Select((s, i) => i > 0 ? char.ToUpper(s[0]) + s.Substring(1) : s));
    }
}