using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Alright, detective, one of our colleagues successfully observed our target person, Robby the robber. We followed him to a secret warehouse, where we assume to find all the stolen stuff. The door to this warehouse is secured by an electronic combination lock. Unfortunately our spy isn't sure about the PIN he saw, when Robby entered it.
    /// He noted the PIN 1357, but he also said, it is possible that each of the digits he saw could actually be another adjacent digit (horizontally or vertically, but not diagonally). E.g. instead of the 1 it could also be the 2 or 4. And instead of the 5 it could also be the 2, 4, 6 or 8.
    /// He also mentioned, he knows this kind of locks. You can enter an unlimited amount of wrong PINs, they never finally lock the system or sound the alarm. That's why we can try out all possible (*) variations.
    /// * possible in sense of: the observed PIN itself and all variations considering the adjacent digits
    /// Can you help us to find all those variations? It would be nice to have a function, that returns an array (or a list in Java/Kotlin and C#) of all variations for an observed PIN with a length of 1 to 8 digits. We could name the function getPINs (get_pins in python, GetPINs in C#). But please note that all PINs, the observed one and also the results, must be strings, because of potentially leading '0's. We already prepared some test cases for you.
    /// </summary>
    internal class The_observed_PIN
    {
        private static List<string> list = new List<string>();

        public static List<string> GetPINs(string observed)
        {
            List<string> holder = new List<string>();

            list.Clear();
            char[,] pinpad =
            {
                {'1','2','3' },
                {'4','5','6' },
                {'7','8','9' },
                {'_','0','_'}
            };

            foreach (char item in observed)
            {
                string temp = item.ToString();

                for (int row = 0; row < pinpad.GetLength(0); row++)
                    for (int col = 0; col < pinpad.GetLength(1); col++)
                        if (pinpad[row, col] != '_')
                        {
                            if (row - 1 >= 0 && pinpad[row - 1, col] == item)
                                temp += pinpad[row, col];
                            if (row + 1 < pinpad.GetLength(0) && pinpad[row + 1, col] == item)
                                temp += pinpad[row, col];
                            if (col - 1 >= 0 && pinpad[row, col - 1] == item)
                                temp += pinpad[row, col];
                            if (col + 1 < pinpad.GetLength(1) && pinpad[row, col + 1] == item)
                                temp += pinpad[row, col];
                        }
                holder.Add(temp);
            }
            return pinBulder(holder).Where(r => r.Count() == observed.Length).ToList();
        }

        private static List<string> pinBulder(List<string> holder)
        {
            if (!list.Any())
            {
                holder.FirstOrDefault().ToList().ForEach(x => list.Add(x.ToString()));

                if (holder.Count() > 1)
                    holder.RemoveAt(0);
                else
                    return list;
            }

            int lc = list.Count;
            

            foreach (var item in holder.FirstOrDefault())
                for (int i =  0 ; i < lc; i++)
                    list.Add(list.ElementAtOrDefault(i) + item.ToString());

            //list.RemoveRange(0, list.TakeWhile(x => x.Length < holder.Count - 1).Count());
            
            if (holder.Count == 1)
                return list;
            else
            {
                holder.RemoveAt(0);
                return pinBulder(holder);
            }
        }
    }
}