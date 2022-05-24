using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Write a function that takes a string of parentheses, and determines if the order of the parentheses is valid.
    /// The function should return true if the string is valid, and false if it's invalid.
    /// 0 <= input.length <= 100
    /// Along with opening (() and closing ()) parenthesis, input may contain any valid ASCII characters.
    /// Furthermore, the input string may be empty and/or not contain any parentheses at all.
    /// Do not treat other forms of brackets as parentheses (e.g. [], {}, <>).
    /// </summary>

    internal class Valid_Parentheses
    {
        public static bool ValidParentheses(string input)
        {
            int counter = new int();
            return ToParenthesesOnly(input).
                Select(s => (s == '(') ? ++counter : --counter).TakeWhile(c => c >= 0).Count().Equals(ToParenthesesOnly(input).Count()) && counter.Equals(0);
        }

        public static string ToParenthesesOnly(string input) =>
            String.Join("", input.Where(s => (s >= '(' && s <= ')')));
    }
}