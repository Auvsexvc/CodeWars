using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Every now and then people in the office moves teams or departments. Depending what people are doing with their time they can become more or less boring. Time to assess the current team.
    /// You will be provided with an object(staff) containing the staff names as keys, and the department they work in as values.
    /// Each department has a different boredom assessment score, as follows:
    /// accounts = 1
    ///finance = 2
    ///canteen = 10
    ///regulation = 3
    ///trading = 6
    ///change = 6
    ///IS = 8
    ///retail = 5
    ///cleaning = 4
    ///pissing about = 25

    ///Depending on the cumulative score of the team, return the appropriate sentiment:

    ///<=80: 'kill me now'
    ///< 100 & > 80: 'i can handle this'
    ///100 or over: 'party time!!'
    /// </summary>
    internal class The_Office_II___Boredom_Score
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>() { { "Tim", "accounts" }, { "Jim", "trading" }, { "Sandy", "regulation" }, { "Andy", "accounts" }, { "Katie", "finance" }, { "Laura", "IS" } };

        public static string Boredom(Dictionary<string, string> staff)
        {
            Dictionary<string, int> score = new Dictionary<string, int>()
            {
                {"accounts",1 },
                {"finance" , 2},
                {"canteen" , 10},
                {"regulation" , 3},
                {"trading" , 6},
                {"change" , 6},
                {"IS" , 8},
                {"retail" , 5},
                {"cleaning" , 4},
                {"pissing about" , 25}
            };

            return staff.Select(x => score.Where(s => s.Key == x.Value).Select(s => s.Value).FirstOrDefault()).Sum() >= 100 ? "party time!!" : (staff.Select(x => score.Where(s => s.Key == x.Value).Select(s => s.Value).FirstOrDefault()).Sum() > 80 ? "i can handle this" : "kill me now");

        }
    }
}