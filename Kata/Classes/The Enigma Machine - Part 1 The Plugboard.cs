using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    internal class The_Enigma_Machine___Part_1_The_Plugboard
    {
        public class Plugboard
        {
            private Dictionary<char, char> plugboard = new Dictionary<char, char>();

            public Plugboard(String wires = "")
            {
                if (wires.Length % 2 != 0)
                    throw new Exception("NotEnoughWireEnds");
                for (int i = 0; i < wires.Length; i++)
                {
                    if (i % 2 == 0)
                        plugboard.Add(wires[i], wires[i + 1]);
                    else
                        plugboard.Add(wires[i], wires[i - 1]);
                }

                if (plugboard.Count/2 > 10)
                    throw new Exception("TooManyWires");
            }

            public char process(char c) =>
                plugboard.ContainsKey(c) ? plugboard.Where(d => d.Key == c).Select(d => d.Value).FirstOrDefault() : c;
        }
    }
}