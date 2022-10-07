using System;
using System.Collections.Generic;

namespace Kata.Classes
{
    /// <summary>
    /// For this exercise you will be strengthening your page-fu mastery. You will complete the PaginationHelper class, which is a utility class helpful for querying paging information related to an array.
    /// The class is designed to take in an array of values and an integer indicating how many items will be allowed per each page. The types of values contained within the collection/array are not relevant.
    /// </summary>
    internal class PaginationHelper
    {
        public class PagnationHelper<T>
        {
            private int _itemCount;
            private int _pageCount;
            private int _itemsPerPage;

            // TODO: Complete this class

            /// <summary>
            /// Constructor, takes in a list of items and the number of items that fit within a single page
            /// </summary>
            /// <param name="collection">A list of items</param>
            /// <param name="itemsPerPage">The number of items that fit within a single page</param>
            public PagnationHelper(IList<T> collection, int itemsPerPage)
            {
                _itemCount = collection.Count;
                _itemsPerPage = itemsPerPage;
                _pageCount = (int)Math.Ceiling((double)collection.Count / _itemsPerPage);
            }

            /// <summary>
            /// The number of items within the collection
            /// </summary>
            public int ItemCount => _itemCount;

            /// <summary>
            /// The number of pages
            /// </summary>
            public int PageCount => _pageCount;

            /// <summary>
            /// Returns the number of items in the page at the given page index
            /// </summary>
            /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
            /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
            public int PageItemCount(int pageIndex) => pageIndex < 0 || pageIndex > PageCount - 1 ? -1 : pageIndex == PageCount - 1 ? ItemCount - pageIndex * _itemsPerPage : _itemsPerPage;


            /// <summary>
            /// Returns the page index of the page containing the item at the given item index.
            /// </summary>
            /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
            /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
            public int PageIndex(int itemIndex) => itemIndex < 0 || itemIndex > ItemCount - 1 ? -1 : (int)Math.Floor(itemIndex / (double)_itemsPerPage);

        }
    }
}