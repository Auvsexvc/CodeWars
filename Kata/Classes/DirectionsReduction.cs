using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;

namespace Kata.Classes
{
    public class DirectionsReduction
    {
        public static string[] DirReduc(string[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var ls = arr.Skip(i).Take(2);
                if (!new string[] { "NORTH", "SOUTH" }.Except(ls).Any()
                    || !new string[] { "EAST", "WEST" }.Except(ls).Any())
                {
                    return DirReduc(arr.Take(i).Concat(arr.Skip(i + 2)).ToArray());
                }
            }

            return arr;
        }
    }

    [TestFixture]
    public class DirectionsReductionTests
    {
        public static string[] randDir(int n)
        {
            Random rnd = new Random();
            string[] dirs = new string[] { "NORTH", "SOUTH", "EAST", "WEST" };
            string[] result = new string[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = dirs[(int)(rnd.Next(0, 3))];
            }
            return result;
        }

        public static string[] DirReducTest(String[] arr)
        {
            System.Collections.ArrayList pairs = new ArrayList();
            pairs.Add("NORTHSOUTH");
            pairs.Add("SOUTHNORTH");
            pairs.Add("EASTWEST");
            pairs.Add("WESTEAST");
            System.Collections.ArrayList result = new ArrayList();
            for (int i = arr.Length - 1; i >= 0; --i)
            {
                if ((result != null) && (result.Count > 0) && (pairs.Contains(arr[i] + result[0])))
                {
                    result.RemoveAt(0);
                }
                else
                {
                    result.Insert(0, arr[i]);
                }
            }
            return result.ToArray(typeof(string)) as string[];
        }

        [Test]
        public void Test1()
        {
            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            string[] b = new string[] { "WEST" };
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }

        [Test]
        public void Test2()
        {
            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "NORTH" };
            string[] b = new string[] { "NORTH" };
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }

        [Test]
        public void Test3()
        {
            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "NORTH" };
            string[] b = new string[] { "NORTH" };
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }

        [Test]
        public void Test4()
        {
            string[] a = new string[] { "EAST", "EAST", "WEST", "NORTH", "WEST", "EAST", "EAST", "SOUTH", "NORTH", "WEST" };
            string[] b = new string[] { "EAST", "NORTH" };
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }

        [Test]
        public void Test5()
        {
            string[] a = new string[] { "NORTH", "EAST", "NORTH", "EAST", "WEST", "WEST", "EAST", "EAST", "WEST", "SOUTH" };
            string[] b = new string[] { "NORTH", "EAST" };
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }

        [Test]
        public void Test6()
        {
            string[] a = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            string[] b = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }

        [Test]
        public void Test7()
        {
            string[] a = DirectionsReductionTests.randDir(8);
            string[] b = DirectionsReductionTests.DirReducTest(a);
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }

        [Test]
        public void Test8()
        {
            string[] a = DirectionsReductionTests.randDir(10);
            string[] b = DirectionsReductionTests.DirReducTest(a);
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }

        [Test]
        public void Test9()
        {
            string[] a = DirectionsReductionTests.randDir(10);
            string[] b = DirectionsReductionTests.DirReducTest(a);
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }

        [Test]
        public void Test10()
        {
            string[] a = DirectionsReductionTests.randDir(15);
            string[] b = DirectionsReductionTests.DirReducTest(a);
            Assert.AreEqual(b, DirectionsReduction.DirReduc(a));
        }
    }
}