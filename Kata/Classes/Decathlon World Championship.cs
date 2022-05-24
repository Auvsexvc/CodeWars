using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// The Decathlon World Championship is back and you have determine who the winner is!
        /*
        In Decathlon there are 10 different disziplines and there are two different formulas to calculate the points of each discipline.

        Points = INT(A(B — P)^C) for track events(faster time produces a better score) - 100m, 400m, 1500m, 110m hurdles
        Points = INT(A(P — B) ^ C) for field events(greater distance or height produces a better score) - Long jump, Shot put, High jump, Discus throw, Pole Vault, Javelin throw

        Where P is the performance of the athlete.

        The units of P in the disciplines:

        Seconds - 100m, 400m, 1500m, 110m hurdles
        centimeter - Long Jump, High Jump, Pole Vault
        meter - Shot put, Discus Throw, Javelin Throw

        There is a preloaded Object with the name pTable with the parameters of A, B and C for each diszipline.
        You will get an object with at least two athletes and their performance in each discipline.
        In C# you will get an array with Athletes objects with the properties Name {string} and Disciplines {Dictionary(string, double)}
        You have to calculate the total amount of points for each athlete and return the name of the winner!
        You have to floor each amount of points for every discipline in the calculation.
        Some Atheletes doesn't perform in every discipline, so the performance for this specific discipline would be null (javascript) and 0 (C#) => 0 points for this discipline
        If a athlete is too bad to get any points, he will receive 0 points. This is the minimum. There aren't negative points.
        The unit of each discipline is correct in the input object.
        The names of the disciplines in pTable are the same as in the input object.
        No need to check for invalid input!
        */

    /// </summary>
    internal class Decathlon_World_Championship
    {
        public class Athlete
        {
            public string Name { get; set; }
            public Dictionary<string, double> Disciplines { get; set; }

            public Athlete(string name, Dictionary<string, double> disciplines)
            {
                Name = name;
                Disciplines = disciplines;
            }
        }

        public class DecathlonWorldChampionship
        {
            private static Dictionary<string, Dictionary<string, double>> pTable = new Dictionary<string, Dictionary<string, double>>();

            private static Dictionary<string, string> disciplineFormule = new Dictionary<string, string>()
            {
                {"100m", "f1" },
                {"400m", "f1" },
                {"1500m", "f1" },
                {"110m hurdles", "f1" },
                {"Long jump", "f2" },
                {"High jump", "f2" },
                {"Pole vault", "f2" },
                {"Shot put","f2m" },
                {"Discus throw", "f2m" },
                {"Javelin throw", "f2m" }
            };

            public static string Decathlon(Athlete[] athletes)
            {
                Dictionary<string, int> pT = new Dictionary<string, int>();

                foreach (var a in athletes)
                {
                    pT.Add(a.Name, 0);
                    foreach (var dG in disciplineFormule)
                    {
                        if (a.Disciplines.ContainsKey(dG.Key) && a.Disciplines[dG.Key] != 0)
                        {
                            if (dG.Value == "f1")
                                pT[a.Name] += Math.Max((int)(pTable[dG.Key]["A"] * Math.Pow(pTable[dG.Key]["B"] - a.Disciplines.Where(d => d.Key == dG.Key).Select(d => d.Value).FirstOrDefault(), pTable[dG.Key]["C"])), 0);
                            else
                                pT[a.Name] += Math.Max((int)(pTable[dG.Key]["A"] * Math.Pow(a.Disciplines.Where(d => d.Key == dG.Key).Select(d => d.Value).FirstOrDefault() - pTable[dG.Key]["B"], pTable[dG.Key]["C"])), 0);
                        }
                    }
                }

                return pT.Aggregate((p, n) => p.Value > n.Value ? p : n).Key;
            }
        }
    }
}