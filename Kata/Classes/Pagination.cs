using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class PaginationTest
    {
        [Test]
        public void Page1Test()
        {
            var p = new Pagination<int>(
              new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 }
            );

            Assert.AreEqual(1, p.CurrentPage, "What page are you on? (CurrentPage)");
            Assert.AreEqual(23, p.Total, "Did you lose something? (Total)");
            Assert.AreEqual(3, p.TotalPages, "Hmmm? (TotalPages)");

            Assert.IsTrue(
              p.Items.SequenceEqual(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }),
              "Yeah, I dont think we are on the same page (Items)"
            );
        }
    }

    internal class Pagination<T>
    {
        private int _itemsPerPage;
        private int _currentPage;
        private IEnumerable<T> _source;

        public IEnumerable<T> Items => _source.Skip((CurrentPage-1)*ItemsPerPage).Take(ItemsPerPage) ?? new List<T>();
        public int CurrentPage { get => _currentPage; set => _currentPage = value <= 0 ? 1 : value; }

        public int ItemsPerPage { get => _itemsPerPage; set => _itemsPerPage = value <= 0 ? 10 : value; }

        public int Total => _source.Count();
        public int TotalPages => (int)Math.Ceiling(Total / (ItemsPerPage * 1.000));

        public Pagination(IEnumerable<T> source)
        {
            _source = source;
            CurrentPage = 1;
            ItemsPerPage = 10;
        }
    }
}