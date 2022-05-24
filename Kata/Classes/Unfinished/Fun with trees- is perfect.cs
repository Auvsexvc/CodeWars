using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes.Unfinished
{
    internal class Fun_with_trees__is_perfect
    {
        /// <summary>
        /// A perfect binary tree is a binary tree in which all interior nodes have two children and all leaves have the same depth or same level.
        /// You are given a class called TreeNode. Implement the method isPerfect which determines if a given tree denoted by its root node is perfect.
        /// Note: TreeNode class contains helper methods for tree creation, which might be handy for your solution. Feel free to update those methods, but make sure you keep their signatures intact (since they are used from within test cases).
        /// You can (and should) add more tests to validate your solution, since not all cases are covered in the example test cases.
        /// </summary>
        public class TreeNode
        {
            public TreeNode left;
            public TreeNode right;

            public static bool IsPerfect(TreeNode root)
            {
                if (root == null) return true;
                return false; // TODO: implementation
            }
            
            public static TreeNode Leaf()
            {
                return new TreeNode();
            }

            public static TreeNode Join(TreeNode left, TreeNode right)
            {
                return new TreeNode().WithChildren(left, right);
            }

            public TreeNode WithLeft(TreeNode left)
            {
                this.left = left;
                return this;
            }

            public TreeNode WithRight(TreeNode right)
            {
                this.right = right;
                return this;
            }

            public TreeNode WithChildren(TreeNode left, TreeNode right)
            {
                this.left = left;
                this.right = right;
                return this;
            }

            public TreeNode WithLeftLeaf()
            {
                return WithLeft(Leaf());
            }

            public TreeNode WithRightLeaf()
            {
                return WithRight(Leaf());
            }

            public TreeNode WithLeaves()
            {
                return WithChildren(Leaf(), Leaf());
            }
        }
    }
}
