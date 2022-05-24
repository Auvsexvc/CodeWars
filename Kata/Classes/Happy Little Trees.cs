using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Create a Tree class so I can grow a happy little tree.
    /// The tree has a trunk and branches which grow in unit sizes.
    /// Branches can start at the current trunk height. All branches grow simultaneously,
    /// Methods to include:
    /// Tree() - Constructor (trunk starts with height of 1 and no branches)
    /// GrowTrunk() - Increase trunk height by 1 (add a new level on top of the tree similar to adding layers to a cake)
    /// NewBranch() - Add a new branch at the current height (multiple separate branches can be added at each level)
    /// GrowBranches() - All existing branches increase in length by 1
    /// Ouch(int n) - The nth oldest branch is removed (the input is 1-indexed, and must be validated: if a branch does not exist or the input is not positive, do nothing)
    /// Description() - Returns a string describing all the properties of the tree as seen below (replace the _ with appropiate values, )
    /// "The tree trunk is {HEIGHT} unit(s) tall! There are {BRANCHES_COUNT} branch(es) that have position(s): {POSITIONS...} and length(s): {LENGTHS...}!"
    /// Where HEIGHT and BRANCHES_COUNT are integers, POSITIONS... and LENGTHS... are comma-separated lists.
    /// If there are no branches, the following string should be returned instead:
    /// "The tree trunk is {HEIGHT} unit(s) tall! There are 0 branch(es)!"
    /// </summary>
    internal class Happy_Little_Trees
    {
        public interface ITree
        {
            void GrowTrunk();

            void GrowBranches();

            void NewBranch();

            void Ouch(int n);

            string Description();
        }

        public class Tree : ITree
        {
            private int Height { get; set; }
            private List<int> Length { get; }
            private int Count { get; set; }
            private List<int> Position { get; }

            public Tree()
            {
                Height = 1;
                Length = new List<int>();
                Position = new List<int>();
                Count = 0;
            }

            public string Description()
            {
                if (Count == 0)
                    return $"The tree trunk is {Height} unit(s) tall! There are 0 branch(es)!";
                else
                    return $"The tree trunk is {Height} unit(s) tall! There are {Count} branch(es) that have position(s): {String.Join(",", Position.Select(x => x))} and length(s): {String.Join(",", Length.Select(x => x))}!";
            }

            public void GrowBranches()
            {
                for (int i = 0; i < Length.Count; i++)
                    Length[i]++;
            }

            public void GrowTrunk()
            {
                Height++;
            }

            public void NewBranch()
            {
                Position.Add(Height);
                Length.Add(1);
                Count ++;
            }

            public void Ouch(int n)
            {
                Console.WriteLine(n);
                if (Length.Count > n && n > 0)
                {
                    Position.RemoveAt(n - 1);
                    Length.RemoveAt(n - 1);
                    Count--;
                }

            }
        }
    }
}