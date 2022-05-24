using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Write a method that accepts a list of objects of type Animal, and returns a new list.
    /// The new list should be a copy of the original list, sorted first by the animal's number of legs, and then by its name.
    /// If null is passed, the method should return null. If an empty list is passed, it should return an empty list back.
    /// </summary>
    internal class Sort_My_Animals
    {
        public class Animal
        {
            public string Name { get; set; }
            public int NumberOfLegs { get; set; }
        }

        public class AnimalSorter
        {
            public List<Animal> Sort(List<Animal> input) =>
                input?.OrderBy(a => a.NumberOfLegs).ThenBy(a => a.Name).ToList();
            
        }
    }
}