using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// In test case two instances of this object is instantiated. Each one is added to a different list and then these lists are compared to check if they are equal or not. If the FirsName and LastName of the instances are equal then the test should pass. The PhoneNumber could be different or the same
    /// </summary>
    internal class CollectionAssert_Test
    {
        public class Kata : IEquatable<Kata>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int PhoneNumber { get; set; }

            public override bool Equals(object obj) => Equals(obj as Kata);

            public bool Equals(Kata p)
            {
                if (p is null)
                    return false;

                if (ReferenceEquals(this, p))
                    return true;

                if (GetType() != p.GetType())
                    return false;

                return FirstName == p.FirstName && LastName == p.LastName;
            }

            public override int GetHashCode() => (FirstName, LastName).GetHashCode();

            public static bool operator ==(Kata lhs, Kata rhs)
            {
                if (lhs is null)
                {
                    if (rhs is null)
                        return true;

                    return false;
                }
                return lhs.Equals(rhs);
            }

            public static bool operator !=(Kata lhs, Kata rhs) => !(lhs == rhs);
        }

    }
}
