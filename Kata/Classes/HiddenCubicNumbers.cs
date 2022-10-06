using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata.Classes
{
    internal class HiddenCubicNumbers
    {
        public class Cubes
        {
            public static String isSumOfCubes(String s)
            {
                const string regex = @"(?<!\w\-)\d{1,3}";
                var x = Regex
                    .Matches(s, regex)
                    .Where(s => s
                        .Value
                        .Sum(d => Math.Pow(int.Parse(d.ToString()), 3)) == int.Parse(s.Value))
                    .Select(s => int.Parse(s.Value));

                return !x.Any() ? "Unlucky" : String.Join(" ", x) + $" {x.Sum()} Lucky";
            }
        }

        [TestFixture]
        public class CubesTests
        {

            [Test]
            public void Test1()
            {
                string s = "0 9026315 -827&()"; // "0 0 Lucky"
                String r = "0 0 Lucky";
                Assert.AreEqual(r, Cubes.isSumOfCubes(s));
            }
            [Test]
            public void Test2()
            {
                string s = "Once upon a midnight dreary, while100 I pondered, 9026315weak and weary -827&()"; // "Unlucky"
                String r = "Unlucky";
                Assert.AreEqual(r, Cubes.isSumOfCubes(s));
            }
            [Test]
            public void Test3()
            {
                string s = "Once 1000upon a midnight 110dreary, while100 I pondered, 9026315weak and weary -827&()"; // "0 0 Lucky"
                String r = "0 0 Lucky";
                Assert.AreEqual(r, Cubes.isSumOfCubes(s));
            }
            [Test]
            public void Test4()
            {
                string s = "&z _upon 407298a --- ???ry, ww/100 I thought, 631str*ng and w===y -721&()"; // "407 407 Lucky"
                String r = "407 407 Lucky";
                Assert.AreEqual(r, Cubes.isSumOfCubes(s));
            }
            [Test]
            public void Test5()
            {
                string s = "&z371 upon 407298a --- dreary, ###100.153 I thought, 9926315strong and weary -127&() 1"; // "371 407 153 1 932 Lucky"
                String r = "371 407 153 1 932 Lucky";
                Assert.AreEqual(r, Cubes.isSumOfCubes(s));
            }
            [Test]
            public void Test6()
            {
                string s = "&&[[[ 298.298a --- ;;;, ###100.163 mouse, querty and tired 567"; // "Unlucky"
                String r = "Unlucky";
                Assert.AreEqual(r, Cubes.isSumOfCubes(s));
            }
            [Test]
            public void Test7()
            {
                string s = "&&[[[ 153.153a --- ;;;, ###153153 mouse, querty and tired 153"; // "153 153 153 153 153 765 Lucky"
                String r = "153 153 153 153 153 765 Lucky";
                Assert.AreEqual(r, Cubes.isSumOfCubes(s));
            }
            [Test]
            public void Test8()
            {
                string s = "153000153407000407"; // "153 0 153 407 0 407 1120 Lucky"
                String r = "153 0 153 407 0 407 1120 Lucky";
                Assert.AreEqual(r, Cubes.isSumOfCubes(s));
            }
            [Test]
            public void Test9()
            {
                string s = "Twice upon a midnight dreary, while100 I pondered, 9026315weak and weary -827&()"; // "Unlucky"
                String r = "Unlucky";
                Assert.AreEqual(r, Cubes.isSumOfCubes(s));
            }
        }
    }
}