using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    internal class GreedySellersQuotes
    {
        public class Item
        {
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal UnitMargin { get; set; }
        }

        public class Quoter
        {
            private List<Item> Items { get; set; }

            public Quoter(List<Item> items)
            {
                Items = items;
            }

            public string GetQuote(int quantity)
            {
                if (Items.Count == 0 || quantity > Items.Sum(x => x.Quantity))
                {
                    return "Your order cannot be fulfilled, try lower quantity";
                }

                int temp = quantity;
                decimal res = 0;

                foreach (var item in Items.OrderByDescending(x => x.UnitMargin))
                {
                    if (item.Quantity >= temp)
                    {
                        res += item.UnitPrice * temp;
                        break;
                    }

                    res += item.UnitPrice * item.Quantity;
                    temp -= item.Quantity;
                }

                return $"Your best quote for {quantity} items is {res.ToString("f2")}";
            }
        }

        [TestFixture]
        public class QuoterTests
        {
            [Test]
            public void WhenQuotingFromEmptyStockReturnsInfoMessage()
            {
                var items = new List<Item>();
                var quoter = GetQuoter(items);

                Assert.AreEqual("Your order cannot be fulfilled, try lower quantity", quoter.GetQuote(11));
            }

            [Test]
            public void WhenQuotingHighQuantityReturnsInfoMessage()
            {
                var items = new List<Item> { new Item { Quantity = 10, UnitPrice = 100m, UnitMargin = 1m } };
                var quoter = GetQuoter(items);

                Assert.AreEqual("Your order cannot be fulfilled, try lower quantity", quoter.GetQuote(11));
            }

            [Test]
            public void WhenQuotingFromSingleItemReturnsCorrectPrice()
            {
                var items = new List<Item> { new Item { Quantity = 10, UnitPrice = 100m, UnitMargin = 1m } };
                var quoter = GetQuoter(items);

                Assert.AreEqual("Your best quote for 10 items is 1000.00", quoter.GetQuote(10));
            }

            [Test]
            public void WhenQuotingFromTwoItemsReturnsHighestMargin()
            {
                var items = new List<Item>
                  {
                      new Item { Quantity = 10, UnitPrice = 100m, UnitMargin = 1m },
                      new Item { Quantity = 10, UnitPrice = 110m, UnitMargin = 1.1m }
                  };
                var quoter = GetQuoter(items);

                Assert.AreEqual("Your best quote for 10 items is 1100.00", quoter.GetQuote(10));
            }

            [Test]
            public void WhenQuotingFromTwoItemsReturnsCombinationWithHighestMargin()
            {
                var items = new List<Item>
                  {
                      new Item { Quantity = 10, UnitPrice = 100m, UnitMargin = 1m },
                      new Item { Quantity = 10, UnitPrice = 110m, UnitMargin = 1.1m }
                  };
                var quoter = GetQuoter(items);

                Assert.AreEqual("Your best quote for 15 items is 1600.00", quoter.GetQuote(15));
            }

            private Quoter GetQuoter(List<Item> items)
            {
                return new Quoter(items);
            }
        }
    }
}