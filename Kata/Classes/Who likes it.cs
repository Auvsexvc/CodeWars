using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// You probably know the "like" system from Facebook and other pages. People can "like" blog posts, pictures or other items. We want to create the text that should be displayed next to such an item.
    /// Implement the function which takes an array containing the names of people that like an item. It must return the display text as shown in the examples:
    /// []                                -->  "no one likes this"
    /// ["Peter"]                         -->  "Peter likes this"
    /// ["Jacob", "Alex"]                 -->  "Jacob and Alex like this"
    /// ["Max", "John", "Mark"]           -->  "Max, John and Mark like this"
    /// ["Alex", "Jacob", "Mark", "Max"]  -->  "Alex, Jacob and 2 others like this"
    /// </summary>
    internal class Who_likes_it
    {
        public static string Likes(string[] name)
        {
            string retString = string.Empty;
            if (!name.Any()) retString += "no one";

            for (int i = 0; i < Math.Min(name.Length, 3); i++)
                if (i < 3)
                {
                    if (i == name.Length - 1 && i > 0 || i == 2 && name.Length > 3) retString += " and ";
                    else if (name.Length > 2 && i == 1) retString += ", ";
                    retString += i == 2 && name.Length > 3 ? $"{name.Length - 2} others" : $"{name.ElementAt(i)}";
                }
            retString += " like";
            retString += name.Length > 1 ? " " : "s ";
            retString += "this";

            return retString;
        }
    }
}