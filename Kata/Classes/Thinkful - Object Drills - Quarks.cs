﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes
{
    /// <summary>
    /// You're modelling the interaction between a large number of quarks and have decided to create a Quark class so you can generate your own quark objects.
    /// Quarks are fundamental particles and the only fundamental particle to experience all four fundamental forces.
    /// Your Quark class should allow you to create quarks of any valid color ("red", "blue", and "green") 
    /// and any valid flavor ('up', 'down', 'strange', 'charm', 'top', and 'bottom').
    /// Every quark has the same baryon_number (BaryonNumber in C#): 1/3.
    /// Every quark should have an .interact() (.Interact() in C#) method that allows any quark to interact with another quark via the strong force. 
    /// When two quarks interact they exchange colors.
    /// </summary>
    internal class Thinkful___Object_Drills___Quarks
    {
        public class Quark
        {
            public string Color { get; set; }
            public string Flavor { get; set; }
            public double BaryonNumber { get; set; }

            public Quark(string color, string flavor)
            {
                Color = color;
                Flavor = flavor;
                BaryonNumber = 1 / 3d;
            }
            public void Interact(Quark quark) =>
                (Color, quark.Color) = (quark.Color, Color);
        }
    }
}
