using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// In this Kata you will need to fill out the missing components of a class as described below. 
    /// The behaviour of the various components is not being assessed, instead the validy of declaration (for example, are things private/public).
    /// The class you are creating (DemoClass) needs:
    /// A private int field, called _privateField.
    /// A public string field, called PublicField, with a default value of "None".
    /// An integer property (called LimitedProperty), that has a public get, and private set.
    /// A constructor that take exactly 1 integer argument and uses it as the default value for _privateField.
    /// </summary>
    internal class Simple_Class_Terminology
    {
        public class DemoClass
        {
            private int _privateField;
            public string PublicField = "None";
            public int LimitedProperty { get; private set; }
            public DemoClass(int arg)
            {
                _privateField = arg;
            }
        }
    }
}
