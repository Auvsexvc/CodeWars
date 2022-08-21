using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    [TestFixture]
    public static class MatchSubstTests
    {
        [Test]
        public static void test1()
        {
            String s1 = "Program title: Primes\nAuthor: Kern\nCorporation: Gold\nPhone: +1-503-555-0091\nDate: Tues April 9, 2005\nVersion: 6.7\nLevel: Alpha";
            dotest(s1, "Ladder", "1.1", "Program: Ladder Author: g964 Phone: +1-503-555-0090 Date: 2019-01-01 Version: 1.1");
            String s12 = "Program title: Primes\nAuthor: Kern\nCorporation: Gold\nPhone: +1-503-555-009\nDate: Tues April 9, 2005\nVersion: 6.7\nLevel: Alpha";
            dotest(s12, "Ladder", "1.1", "ERROR: VERSION or PHONE");
            String s13 = "Program title: Primes\nAuthor: Kern\nCorporation: Gold\nPhone: +1-503-555-0090\nDate: Tues April 9, 2005\nVersion: 67\nLevel: Alpha";
            dotest(s13, "Ladder", "1.1", "ERROR: VERSION or PHONE");
        }

        private static void dotest(string s, string prog, string version, string exp)
        {
            Console.Write("s:\n" + s + "\n");
            Console.Write("prog: " + prog + "\n");
            Console.Write("version: " + version + "\n");
            string ans = MatchSubst.Change(s, prog, version);
            Console.Write("ACTUAL:\n" + ans + "\n");
            Console.Write("EXPECT:\n" + exp + "\n");
            Console.Write("{0:D}\n", exp == ans);
            Assert.AreEqual(exp, ans);
            Console.WriteLine("-");
        }
    }

    public class MatchSubst
    {
        public static string Change(string s, string prog, string version)
        {
            var ss = s.Split("\n");

            if (!Regex.IsMatch(ss[3].Split(": ")[1], @"([\+]1-\d{3}-\d{3}-\d{4})") || !Regex.IsMatch(ss[5].Split(": ")[1], @"^(\d+[\.]\d+)$"))
            {
                return "ERROR: VERSION or PHONE";
            }

            File file = new File(

                String.Join(": ", ss[0].Split(" ")[0], prog),
                String.Join(": ", ss[1].Split(": ")[0], "g964"),
                String.Join(": ", ss[3].Split(": ")[0], "+1-503-555-0090"),
                String.Join(": ", ss[4].Split(": ")[0], "2019-01-01"),
                String.Join(": ", ss[5].Split(": ")[0], ss[5].Split(": ")[1] != "2.0" ? version : "2.0")

            );

            return String.Join(" ", file.Program, file.Author, file.Phone, file.Date, file.Version);
        }
    }

    public class File
    {
        public string Program { get; }
        public string Author { get; }
        public string Phone { get; }
        public string Date { get; }
        public string Version { get; }

        public File(string program, string author, string phone, string date, string version)
        {
            Program = program;
            Author = author;
            Phone = phone;
            Date = date;
            Version = version;
        }
    }
}