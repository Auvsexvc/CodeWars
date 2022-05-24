using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// mplement the function unique_in_order which takes as argument a sequence and returns a list of items without any elements with the same value next to each other and preserving the original order of elements.
    /// </summary>
    internal class Unique_In_Order
    {
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            List<T> resultList = new List<T>();
            
            foreach (T element in iterable)
                if (!element.Equals(resultList.LastOrDefault()))
                    resultList.Add(element);

            return resultList;
        }
    }
}