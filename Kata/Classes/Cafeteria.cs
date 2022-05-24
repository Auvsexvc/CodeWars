using System.Collections.Generic;

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
        class CoffeeBuilder
        {
            private string sort;
            private List<Milk> milks = new List<Milk>();
            private List<Sugar> sugars = new List<Sugar>();

            public CoffeeBuilder() { }

            public CoffeeBuilder SetBlackCoffee()
            {
                sort = "Black";
                milks.Clear();
                sugars.Clear();
                return this;
            }
            public CoffeeBuilder SetCubanoCoffee()
            {
                sort = "Cubano";
                milks.Clear();
                sugars.Clear();
                sugars.Add(new Sugar("Brown"));
                return this;
            }
            public CoffeeBuilder SetAntoccinoCoffee()
            {
                sort = "Americano";
                milks.Clear();
                sugars.Clear();
                milks.Add(new Milk(0.5));
                return this;
            }

            public CoffeeBuilder WithMilk(double fat)
            {
                milks.Add(new Milk(fat));
                return this;
            }
            public CoffeeBuilder WithSugar(string sort)
            {
                sugars.Add(new Sugar(sort));
                return this;
            }

            public Coffee Build()
            {
                return new Coffee(sort, milks, sugars);
            }

        }
        struct Milk
        {
            public double Fat;
            public Milk(double fat)
            {
                Fat= fat;
            }
        }

        struct Sugar
        {
            public string Sort;
            public Sugar(string sort)
            {
                Sort = sort;
            }
        }

        struct Coffee
        {
            public string Sort;
            public List<Milk> Milk;
            public List<Sugar> Sugar;

            public Coffee(string sort, List<Milk> milk, List<Sugar> sugar)
            {
                Sort= sort;
                Milk= milk;
                Sugar= sugar;
            }
        }
    }
}