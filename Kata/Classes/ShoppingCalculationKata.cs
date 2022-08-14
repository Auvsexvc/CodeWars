using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class ShoppingCalculationTest
    {
        [Test]
        public void test1()
        {
            //Arrange
            var input = new List<string>() {
            "Apple is $5.",
            "Banana is $7.",
            "Orange is $2.",
            "Alice has $26.",
            "John has $41.",
            "Alice buys 2 apples.",
            "John buys 1 banana.",
            "Alice buys 5 oranges."
            };

            var expectedResult = new List<(string, string, string)>() {
            ("Alice", "$6", "2 apples, 5 oranges"),
            ("John", "$34", "1 banana")
            };

            //Act
            var actualResult = ShoppingCalculationKata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void test2()
        {
            //Arrange
            var input = new List<string>() {
            "Chocolate is $15.",
            "George has $100.",
            "Ross has $80.",
            "George buys 5 chocolates.",
            "Ross buys 1 chocolate.",
            };

            var expectedResult = new List<(string, string, string)>() {
            ("George", "$25", "5 chocolates"),
            ("Ross", "$65", "1 chocolate")
            };

            //Act
            var actualResult = ShoppingCalculationKata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void test3()
        {
            //Arrange
            var input = new List<string>() {
            "Carrot is $1.",
            "Watermelon is $5.",
            "Lemon is $2.",
            "Steve has $10.",
            "Jim has $800.",
            "Steve buys 7 carrots.",
            "Jim buys 2 watermelons.",
            "Jim buys 1 carrot.",
            };

            var expectedResult = new List<(string, string, string)>() {
            ("Steve", "$3", "7 carrots"),
            ("Jim", "$789", "2 watermelons, 1 carrot")
            };

            //Act
            var actualResult = ShoppingCalculationKata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void test4()
        {
            //Arrange
            var input = new List<string>() {
            "Carrot is $1.",
            "Jim has $10.",
            "Lemon is $2.",
            "Steve has $80.",
            "Steve buys 7 carrots.",
            "Jim buys 2 lemons.",
            };

            var expectedResult = new List<(string, string, string)>() {
            ("Jim", "$6", "2 lemons"),
            ("Steve", "$73", "7 carrots"),
            };

            //Act
            var actualResult = ShoppingCalculationKata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void test5()
        {
            //Arrange
            var input = new List<string>() {
            "Apple is $5.",
            "Banana is $7.",
            "Orange is $2.",
            "Lisa has $26.",
            "Arthas has $41.",
            "Lisa buys 2 apples.",
            "Arthas buys 1 banana.",
            "Lisa buys 5 oranges.",
            };

            var expectedResult = new List<(string, string, string)>() {
            ("Lisa", "$6", "2 apples, 5 oranges"),
            ("Arthas", "$34", "1 banana"),
            };

            //Act
            var actualResult = ShoppingCalculationKata.ShoppingCalculation(input);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    internal class ShoppingCalculationKata
    {
        public static List<(string, string, string)> ShoppingCalculation(List<string> input)
        {
            //List<(string, string, string)> retlist = new();

            var products = input
                .Where(x => x.Contains(" is "))
                .ToDictionary(k => k.Split(' ').First().ToLower(), p => int.Parse(p.Split(' ').Last().TrimEnd('.').TrimStart('$')));
            var customers = input
                .Where(x => x.Contains(" has "))
                .ToDictionary(k => k.Split(' ').First(), p => int.Parse(p.Split(' ').Last().TrimEnd('.').TrimStart('$')));

            List<(string Customer, string Product, int Amount)> orders = input
                .Where(x => x.Contains(" buys "))
                .Select(k => (k.Split(' ').First(), k.Split(' ').Last().TrimEnd('.').TrimEnd('s'), int.Parse(k.Split(' ').Skip(2).First())))
                .ToList();

            //foreach (var customer in customers)
            //{
            //    var shoppingTotal = orders
            //        .Where(x => x.Customer == customer.Key)
            //        .GroupJoin(products, x => x.Product, x => x.Key, (cCart, price) => new { ProductName = cCart.Product, Price = price.FirstOrDefault().Value * cCart.Amount })
            //        .Sum(x => x.Price);

            // var shoppingItems = orders .Where(x => x.Customer == customer.Key) .Select(x =>
            // x.Amount > 1 ? string.Join(" ", x.Amount, x.Product) + "s" : string.Join(" ",
            // x.Amount, x.Product)) .ToList();

            //    retlist.Add((customer.Key, "$"+(customer.Value - shoppingTotal).ToString(), string.Join(", ", shoppingItems)));
            //}

            return customers
                .Select(customer =>
                    (
                    customer.Key,
                    "$" + (customer.Value - orders
                        .Where(x => x.Customer == customer.Key)
                        .GroupJoin(
                            products,
                            x => x.Product,
                            x => x.Key,
                            (o, p) => new { ProductName = o.Product, Price = p.First().Value * o.Amount })
                        .Sum(x => x.Price))
                    .ToString(),
                    string.Join(", ", orders
                        .Where(x => x.Customer == customer.Key)
                        .Select(x => x.Amount > 1
                            ? string.Join(" ", x.Amount, x.Product) + "s"
                            : string.Join(" ", x.Amount, x.Product))
                        .ToList())
                    ))
                .ToList();

            //return retlist;
        }
    }
}