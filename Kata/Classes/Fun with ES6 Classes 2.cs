using System;

namespace Kata.Classes
{
    /// <summary>
    /// Define the following classes that inherit from Animal.
    /// I. Shark:
    /// The constructor function for Shark should accept 3 arguments in total in the following order: name, age, status.
    /// All sharks should have a leg count of 0 (since they obviously do not have any legs) and should have a species of "shark".
    /// II. Cat:
    /// The constructor function for Cat should accept the same 3 arguments as with Shark: name, age, status. Cats should always have a leg count of 4 and a species of "cat".
    /// Furthermore, the introduce/Introduce method for Cat should be identical to the original except there should be exactly 2 spaces and the words "Meow meow!" after the phrase.
    /// III. Dog:
    /// The Dog constructor should accept 4 arguments in the specified order: name, age, status, master. master is the name of the dog's master which will be a string.
    /// Furthermore, dogs should have 4 legs and a species of "dog".
    /// Dogs have an identical introduce/Introduce method as any other animal, but they have their own method called greetMaster/GreetMaster which accepts no arguments and returns "Hello (insert_master_name_here)" (of course not the literal string but replace the (insert_master_name_here) with the name of the dog's master).
    /// </summary>
    internal class Fun_with_ES6_Classes_2
    {
        public class Animal
        {
            public int Age;
            public int Legs;
            public string Name;
            public string Species;
            public string Status;

            public Animal(string name, int age, int legs, string species, string status)
            {
                this.Name = name;
                this.Age = age;
                this.Legs = legs;
                this.Species = species;
                this.Status = status;
            }

            public virtual string Introduce() =>
                $"Hello, my name is {this.Name} and I am {this.Age} years old.";
        }

        public class Shark : Animal
        {
            public Shark(string name, int age, string status, int legs = 0) : base(name, age, 0, "shark", status)
            {
            }
        }

        public class Cat : Animal
        {
            public Cat(string name, int age, string status) : base(name, age, 4, "cat", status)
            {
            }

            public override string Introduce() =>
                String.Join("  ", base.Introduce(), "Meow meow!");
        }

        public class Dog : Animal
        {
            public Dog(string name, int age, string status, string master, int legs = 4, string species = "dog") : base(name, age, legs, species, status)
            {
                Master = master;
            }

            public string Master { get; }

            public string GreetMaster() =>
                $"Hello {Master}";
        }
        
        
    }
}