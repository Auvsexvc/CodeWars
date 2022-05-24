using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// The code provided is supposed return a person's Full Name given their first and last names.
    /// But it's not working properly.
    /// Notes: The first and/or last names are never null, but may be empty.
    /// Task: Fix the bug so we can all go home early.
    /// </summary>
    internal class FIXME_Get_Full_Name
    {
        private string firstName;
        private string lastName;
        public string FullName
        {
            get
            {
                if (!firstName.Any())
                    return lastName;
                else if (!lastName.Any())
                    return firstName;
                else if (!firstName.Any() && !lastName.Any())
                    return string.Empty;
                else
                    return firstName + " " + lastName;
            }
        }
        public FIXME_Get_Full_Name(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

    }
}
