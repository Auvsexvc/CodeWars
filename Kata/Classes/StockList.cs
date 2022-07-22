using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class StockListTests
    {
        [Test]
        public void Test1()
        {
            string[] art = new string[] { "ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600" };
            String[] cd = new String[] { "A", "B" };
            Assert.AreEqual("(A : 200) - (B : 1140)", StockList.StockSummary(art, cd));
        }
    }

    internal class StockList
    {
        public static string StockSummary(String[] lstOfArt, String[] lstOf1stLetter) =>
            lstOfArt.Any() && lstOf1stLetter.Any()
                ? string.Join(
                    " - ",
                    lstOf1stLetter.Select(c => $"({c} : {lstOfArt.Where(a => a.First().Equals(char.Parse(c))).Select(a => int.Parse(a.Split(' ').Last())).Sum()})"))
                : "";

        public static string StockSummaryGJ(String[] L, String[] M) =>
            L.Any() ? string.Join(" - ", M.GroupJoin(L, a => a[0], b => b[0], (x, y) => $"({x} : {y.Sum(z => Int32.Parse(z.Split().Last()))})")) : "";
    }
}