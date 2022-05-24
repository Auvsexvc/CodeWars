using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Implement the method map, which accepts a linked list (head) and a mapping function, and returns a new linked list (head) where every element is the result of applying the given mapping method to each element of the original list.
    /// For example: Given the list: 1 -> 2 -> 3, and the mapping function x => x * 2, map should return 2 -> 4 -> 6
    /// </summary>
    
    internal class Fun_with_lists___map
    {

        public class Node<T>
        {
            public T data;
            public Node<T> next;

            public Node(T data)
            {
                this.data = data;
            }

            public Node(T data, Node<T> next)
            {
                this.data = data;
                this.next = next;
            }
        }

        public static Node<T2> Map<T, T2>(Node<T> head, Func<T, T2> f) =>
            head != null ? new Node<T2>(f(head.data), Map(head.next, f)) : null;
    
        
    }
}
