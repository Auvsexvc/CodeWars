using NUnit.Framework;
using System;
using System.Linq;

namespace Kata.Classes
{
    public class SnailTest
    {
        [Test]
        public void SnailTest1()
        {
            int[][] array =
            {
           new []{1, 2, 3},
           new []{4, 5, 6},
           new []{7, 8, 9}
       };
            var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            Test(array, r);
        }

        public string Int2dToString(int[][] a)
        {
            return $"[{string.Join("\n", a.Select(row => $"[{string.Join(",", row)}]"))}]";
        }

        public void Test(int[][] array, int[] result)
        {
            var text = $"{Int2dToString(array)}\nshould be sorted to\n[{string.Join(",", result)}]\n";
            Console.WriteLine(text);
            Assert.AreEqual(result, SnailSolution.Snail(array));
        }
    }

    internal static class SnailSolution
    {
        public static int[] Snail(int[][] array)
        {
            if (array[0].Length == 0)
            {
                return Array.Empty<int>();
            }

            int n = array.Length;
            int[] ret = new int[n * n];
            int[,] helper = new int[n, n];
            int val = 0;
            int c1 = 0, c2 = n - 1;
            while (val < n * n)
            {
                for (int i = c1; i <= c2; i++)
                    helper[c1, i] = val++;
                for (int j = c1 + 1; j <= c2; j++)
                    helper[j, c2] = val++;
                for (int i = c2 - 1; i >= c1; i--)
                    helper[c2, i] = val++;
                for (int j = c2 - 1; j >= c1 + 1; j--)
                    helper[j, c1] = val++;
                c1++;
                c2--;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ret[helper[i, j]] = array[i][j];
                }
            }

            return ret;
        }
    }
}