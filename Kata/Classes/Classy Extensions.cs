using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Your task is to complete the Cat class which Extends Animal and replace the speak method to return the cats name + meows. e.g. 'Mr Whiskers meows.'
    /// </summary>
    
    internal class Classy_Extensions
    {
        public class Animal
        {
            public string Name { get; set; }
            public Animal(string name)
            {
                Name = name;
            }
            public virtual string Speak()
            {
                return $"{Name} doesn't speak!";
            }
        }
        
        public class Cat : Animal
        {
            public Cat(string name) : base(name)
            {
                Name = name;
            }
            public override string Speak()
            {
                return $"{Name} meows.";
            }
            // TODO: Override Animal's Speak method
        }
    }
}
