﻿using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Your start-up's BA has told marketing that your website has a large audience in Scandinavia and surrounding countries.
    /// Marketing thinks it would be great to welcome visitors to the site in their own language. Luckily you already use an API that detects the user's location, so this is an easy win.
    /// Think of a way to store the languages as a database (eg an object). The languages are listed below so you can copy and paste!
    /// Write a 'welcome' function that takes a parameter 'language' (always a string), and returns a greeting - if you have it in your database.
    /// It should default to English if the language is not in the database, or in the event of an invalid input.
    /// </summary>
    internal class Welcome
    {
        
        public static string Greet(string language = "english") =>
            _welcomeDB.Where(g => _welcomeDB.ContainsKey(language) ? g.Key == language : g.Key == "english").SingleOrDefault().Value;

        private static readonly Dictionary<string, string> _welcomeDB = new Dictionary<string, string>()
            {
                {"english", "Welcome"},
                {"czech", "Vitejte"},
                {"danish", "Velkomst"},
                {"dutch", "Welkom"},
                {"estonian", "Tere tulemast"},
                {"finnish", "Tervetuloa"},
                {"flemish", "Welgekomen"},
                {"french", "Bienvenue"},
                {"german", "Willkommen"},
                {"irish", "Failte"},
                {"italian", "Benvenuto"},
                {"latvian", "Gaidits"},
                {"lithuanian", "Laukiamas"},
                {"polish", "Witamy"},
                {"spanish", "Bienvenido"},
                {"swedish", "Valkommen"},
                {"welsh", "Croeso"}
            };
    }
}