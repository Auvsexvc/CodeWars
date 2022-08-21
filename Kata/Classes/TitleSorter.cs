using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    public class TitleSorter
    {
        public List<string> Sort(List<string> unsortedTitles)
        {
            var x= unsortedTitles != null
                ? unsortedTitles
                    .OrderBy(x => Regex.IsMatch(x, @"^((A|An|The)\b)") && x.Split(" ").Length > 1 && x.Split(" ").All(x=>x!="")
                        ? String.Join(" ", x.Split(" ").Skip(1)) + (string.Concat(", ", x.Split(" ")[0]))
                        : x.TrimEnd())
                    .ToList()
                : null;
            return x;
        }

        public List<string> Sort2(List<string> unsortedTitles)
        {
            return unsortedTitles?.OrderBy(SortKey).ToList();
        }

        static readonly Regex SortKeyRe = new Regex(@"\A(The|An?)\s+(.+)\z");
        static string SortKey(string s) => SortKeyRe.Replace(s, "$2, $1");
    }

    [TestFixture]
    public class TitleSorterTests
    {
        [Test]
        public void SampleBooksSortTest()
        {
            List<string> titlesToSort = new List<string>()
              {
                "A Petition to Magic",
                "Heritage of Deceit",
                "Stingers",
                "Billy's Zombie",
                "Heaven and Earth: Paranormal Flash Fiction",
                "Tales From Virdura",
              };
            List<string> sortedList = new TitleSorter().Sort(titlesToSort);
            Assert.AreEqual(titlesToSort.Count, sortedList.Count);
            Assert.AreEqual("Billy's Zombie", sortedList[0]);
            Assert.AreEqual("A Petition to Magic", sortedList[3]);
        }
        [Test]
        public void SampleBooksSortTest2()
        {
            List<string> titlesToSort = new List<string>()
              {
                "A", "An", "The", "A " , "The " , "An " ,
              };
            List<string> sortedList = new TitleSorter().Sort(titlesToSort);
            Assert.AreEqual(titlesToSort.Count, sortedList.Count);
            Assert.AreEqual("A", sortedList[0]);
            //Assert.AreEqual("A Petition to Magic", sortedList[3]);
        }
    }
}