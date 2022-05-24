using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// You have to detect if the person is a Police or a Spy :D There is an abstract class named "Human" with just one property which is "Name". "Name" is an string. There are two other classes named "Police" and "Spy" that inherit from Human class.
    /// Complete the FindHisIdentity method, so it returns a string that tell the identity of the person: the output string should be like this: "'Name of the person' is a 'real identity of the person'"
    /// </summary>
    internal class Reveal_Spy_Identity
    {
        public class Human
        {
            public string Name { get; set; }
        }
        public class Police : Human
        {

        }

        public class Spy : Human
        {

        }

        public static string FindHisIdentity(Human person) =>
            $"{person.Name} is a {person.GetType().Name}";
    }
}
