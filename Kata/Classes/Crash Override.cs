using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Every budding hacker needs an alias! The Phantom Phreak, Acid Burn, Zero Cool and Crash Override are some notable examples from the film Hackers.
    /// Your task is to create a function that, given a proper first and last name, will return the correct alias.
    /// Two objects that return a one word name in response to the first letter of the first name and one for the first letter of the surname are already given.
    /// If the first character of either of the names given to the function is not a letter from A - Z, you should return "Your name must start with a letter from A - Z."
    /// Sometimes people might forget to capitalize the first letter of their name so your function should accommodate for these grammatical errors.
    /// </summary>
    internal class Crash_Override
    {
        public static Dictionary<string, string> FirstName = new Dictionary<string, string>() { { "A", "Alpha" }, { "B", "Beta" }, { "C", "Cache" } };
        public static Dictionary<string, string> Surname = new Dictionary<string, string>() { { "A", "Analogue" }, { "B", "Bomb" }, { "C", "Catalyst" } };

        public static string AliasGen(string fName, string lName) =>
            char.IsLetter(fName.ToCharArray().FirstOrDefault()) && char.IsLetter(lName.ToCharArray().FirstOrDefault())
                ? string.Join(" ", FirstName.Where(d => d.Key == char.ToUpper(fName.ToCharArray().FirstOrDefault()).ToString()).Select(d => d.Value).FirstOrDefault(), Surname.Where(d => d.Key == char.ToUpper(lName.ToCharArray().FirstOrDefault()).ToString()).Select(d => d.Value).FirstOrDefault())
                : "Your name must start with a letter from A - Z.";
    }
}