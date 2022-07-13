using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Classes
{
    // / <summary>
    // / You have a simple Cafeteria.
    // / You can create 3 coffee recipes:
    // / Black = Black coffee
    // Cubano = Cubano coffee + Brown sugar
    // Americano = Americano coffee + Milk with 0.5% fat
    // And you can add a lot of extra sugar and extra milk in any coffee, e.g.:

    // Black + Milk with 3.2% fat + Brown sugar
    // Cubano + Brown sugar + Brown sugar + Regular sugar
    // Americano + Milk with 3.2% fat + Milk with 0% fat + Regular sugar
    // You need to create a Coffee by implementing a CoffeeBuilder struct/class like in the Builder design pattern.
    // / </summary>
    internal class Cafeteria
    {
        private struct Milk
        {
            public double Fat;

            public Milk(double fat)
            {
                Fat = fat;
            }
        }

        private struct Sugar
        {
            public string Sort;

            public Sugar(string sort)
            {
                Sort = sort;
            }
        }

        private struct Coffee
        {
            public string Sort;
            public List<Milk> Milk;
            public List<Sugar> Sugar;

            public Coffee(string sort, List<Milk> milk, List<Sugar> sugar)
            {
                Sort = sort;
                Milk = milk;
                Sugar = sugar;
            }
        }

        [TestFixture]
        public class FixedTests
        {
            [Test]
            public void Test1()
            {
                var actual = new CoffeeBuilder().SetBlackCoffee().WithSugar("Regular").WithMilk(3.2).Build();
                var expected = new Coffee("Black", new List<Milk> { new Milk(3.2) }, new List<Sugar> { new Sugar("Regular") });
                Assert.AreEqual(expected.ToString(), actual.ToString());
            }

            [Test]
            public void Test2()
            {
                var actual = new CoffeeBuilder().SetAntoccinoCoffee().Build();
                var expected = new Coffee("Americano", new List<Milk> { new Milk(0.5) }, new List<Sugar>());
                Assert.AreEqual(expected.ToString(), actual.ToString());
            }

            [Test]
            public void Test3()
            {
                var actual = new CoffeeBuilder().SetCubanoCoffee().Build();
                var expected = new Coffee("Cubano", new List<Milk>(), new List<Sugar> { new Sugar("Brown") });
                Assert.AreEqual(expected.ToString(), actual.ToString());
            }
        }

        [TestFixture]
        public class RandomTests
        {
            private readonly Random _random = new();
            private readonly string _base = "abcdefghijklmnopqrstuvwxyz";

            [Test]
            public void Tests()
            {
                for (var i = 0; i < 100; i++)
                {
                    var c = new Coffee("", new List<Milk>(), new List<Sugar>());
                    var cb = new CoffeeBuilder();

                    var type = _random.Next(3);
                    if (type == 0)
                    {
                        c.Sort = "Black";
                        cb = cb.SetBlackCoffee();
                    }
                    else if (type == 1)
                    {
                        c.Sort = "Americano";
                        c.Milk.Add(new Milk(0.5));
                        cb = cb.SetAntoccinoCoffee();
                    }
                    else
                    {
                        c.Sort = "Cubano";
                        c.Sugar.Add(new Sugar("Brown"));
                        cb = cb.SetCubanoCoffee();
                    }

                    for (var j = _random.Next(3); j > 0; j--)
                    {
                        var n = _random.Next(1, 31) / 10.0;
                        c.Milk.Add(new Milk(n));
                        cb = cb.WithMilk(n);
                    }

                    for (var j = _random.Next(3); j > 0; j--)
                    {
                        var s = RandString(_random.Next(3, 6));
                        c.Sugar.Add(new Sugar(s));
                        cb = cb.WithSugar(s);
                    }

                    Assert.AreEqual(c.ToString(), cb.Build().ToString());
                }
            }

            private string RandString(int n)
            {
                var sb = new StringBuilder();
                for (var i = 0; i < n; i++) sb.Append(_base[_random.Next(_base.Length)]);
                return sb.ToString();
            }
        }

        private class CoffeeBuilder
        {
            private readonly List<Milk> _milks = new();
            private readonly List<Sugar> _sugars = new();
            private string _sort;

            public CoffeeBuilder()
            { }

            public CoffeeBuilder SetBlackCoffee()
            {
                _sort = "Black";
                _milks.Clear();
                _sugars.Clear();
                return this;
            }

            public CoffeeBuilder SetCubanoCoffee()
            {
                _sort = "Cubano";
                _milks.Clear();
                _sugars.Clear();
                _sugars.Add(new Sugar("Brown"));
                return this;
            }

            public CoffeeBuilder SetAntoccinoCoffee()
            {
                _sort = "Americano";
                _milks.Clear();
                _sugars.Clear();
                _milks.Add(new Milk(0.5));
                return this;
            }

            public CoffeeBuilder WithMilk(double fat)
            {
                _milks.Add(new Milk(fat));
                return this;
            }

            public CoffeeBuilder WithSugar(string sort)
            {
                _sugars.Add(new Sugar(sort));
                return this;
            }

            public Coffee Build()
            {
                return new Coffee(_sort, _milks, _sugars);
            }
        }
    }


}