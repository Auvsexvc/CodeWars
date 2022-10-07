using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Kata.Classes
{
    internal class CanYouCountLoopsExecution
    {
        public static class Kata
        {
            public static BigInteger[] CountLoopIterations((int, bool)[] arr)
            {
                var list = new List<List<BigInteger>>();
                for (int i = 0; i < arr.Length; i++)
                {
                    var tempList = new List<BigInteger>();
                    for (int j = i; j >= 0; j--)
                    {
                        var item = arr[j].Item1;
                        if (tempList.Count == 0)
                        {
                            item++;
                        }

                        if (arr[j].Item2)
                        {
                            tempList.Add(item + 1);
                        }
                        else
                        {
                            tempList.Add(item);
                        }
                    }
                    list.Add(tempList);
                }

                return list.Select(x => x.Aggregate((a, b) => a * b)).ToArray();
            }
        }

        [TestFixture]
        public class SolutionTest
        {
            [Test(Description = "Sample Tests")]
            public void SampleTests()
            {
                Act(new[] { (4, true), (5, false), (3, true) }, new BigInteger[] { 6, 30, 125 });
                Act(new[] { (16, false), (11, false), (1, true), (3, false), (8, true), (10, true), (9, false), (11, true), (20, true), (3, false), (7, false) }, new BigInteger[] { 17, 192, 528, 1408, 10560, 114048, 1045440, 12231648, 248396544, 948423168, 5690539008 });
                Act(new (int, bool)[0], new BigInteger[0]);
                Act(new[] { (20, false) }, new BigInteger[] { 21 });
            }

            private static string Print((int, bool)[] arr) => arr == null ? "null" : $"[{string.Join(", ", arr)}]";

            private static string Print(BigInteger[] arr) => arr == null ? "null" : $"[{string.Join(", ", arr)}]";

            private static void Act((int, bool)[] arr, BigInteger[] expected)
            {
                var actual = Kata.CountLoopIterations(arr);
                CollectionAssert.AreEqual(expected, actual, $"\n  arr = {Print(arr)}\n  Expected: {Print(expected)}\n  Actual: {Print(actual)}\n");
            }
        }
    }
}