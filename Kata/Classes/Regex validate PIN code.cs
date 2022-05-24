using System.Text.RegularExpressions;

namespace Kata.Classes.Unfinished
{
    /// <summary>
    /// ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits.
    /// If the function is passed a valid PIN string, return true, else return false.
    /// </summary>
    internal class Regex_validate_PIN_code
    {
        public static bool ValidatePin(string pin) => Regex.Match(pin, @"^(\d{4}|\d{6})\z$").Success;
    }
}