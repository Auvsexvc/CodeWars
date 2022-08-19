using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    public class Prefix
    {
        public static IEnumerable<string> AllPrefixes(int prefixLength, IEnumerable<string> words)
        {
            return words.Where(w => w.Length >= prefixLength).Select(w => w.Substring(0, prefixLength)).Distinct();
        }

        public static void Main(string[] args)
        {
            // Should print "flo", "fle", and "fla" since those are the distinct, length 3 prefixes.
            foreach (var p in AllPrefixes(3, new string[] { "flow", "flowers", "flew", "flag", "fm" }))
                Console.WriteLine(p);
        }
    }

    public class Product
    {
        private int quantity;
        public string Name { get; }
        public int Quantity { get => quantity; set => quantity = value < 1 ? 1 : value; }

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}