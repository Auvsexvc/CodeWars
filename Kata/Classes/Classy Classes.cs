using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// Your task is to complete this Class, the Person class has been created. 
    /// You must fill in the Constructor method to accept a name as string and an age as number,
    /// complete the get Info property and getInfo method/Info getter which should return johns age is 34
    /// </summary>
    internal class Classy_Classes
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Info
            {
                get { return $"{Name}s age is {Age}"; }
            }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

        }
    }

}
