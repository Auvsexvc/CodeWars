using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class RangeExtractorTest
    {
        [Test(Description = "Simple tests")]
        public void SimpleTests()
        {
            Assert.AreEqual("1,2", RangeExtraction.Extract(new[] { 1, 2 }));
            Assert.AreEqual("1-3", RangeExtraction.Extract(new[] { 1, 2, 3 }));

            Assert.AreEqual(
                "-6,-3-1,3-5,7-11,14,15,17-20",
                RangeExtraction.Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 })
            );

            Assert.AreEqual(
                "-3--1,2,10,15,16,18-20",
                RangeExtraction.Extract(new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 })
            );
        }

        [Test(Description = "Random tests")]
        public void RandomTests()
        {
            for (int i = 0; i < 30; i++)
            {
                var data = GetRandomArray();
                Assert.AreEqual(Solver(data), RangeExtraction.Extract(data));
            }
        }

        private Random _random = new Random();

        private int[] GetRandomArray()
        {
            var y = _random.Next(-200, -100);
            var res = new List<int>();
            var count = _random.Next(50, 200);
            for (int i = 0; i < count; i++)
            {
                res.Add(y);
                y += _random.Next(1, 3);
            }
            return res.ToArray();
        }

        private static string Solver(int[] args)
        {
            const int MIN_RANGE = 3;
            var res = new List<string>(args.Length);
            var nums = new List<int>();
            Action flush = () => {
                if (nums.Count >= MIN_RANGE)
                    res.Add(String.Format("{0}-{1}", nums[0], nums[nums.Count - 1]));
                else
                    res.Add(String.Join(",", nums));
                nums.Clear();
            };

            foreach (var x in args)
            {
                if (nums.Count == 0 || x == nums[nums.Count - 1] + 1) nums.Add(x);
                else
                {
                    flush();
                    nums.Add(x);
                }
            }
            flush();

            return String.Join(",", res);
        }

    }

    public static class RangeExtraction
    {
        public static string Extract(int[] args)
        {
            string retString = string.Empty;

            int l = Math.Abs(args.Min()) + args.Max() + 1;

            if (args.Min() < 0 && args.Max() > 0)
            {
                l++;
            }

            string[] arr = Enumerable.Range(args.Min(), l).Select(i => args.Contains(i) ? i.ToString() : " ").ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != " ")
                {
                    var t = arr.Skip(i).TakeWhile(x => x != " ").ToArray();
                    if (t.Length >= 3)
                    {
                        retString += string.Join("-", t.First(), t.Last());
                    }
                    else
                    {
                        retString += string.Join(",", t);
                    }
                    i += (t.Length - 1);

                    retString += ",";
                }
            }

            return retString.TrimEnd(',');
        }
    }
}