using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class SimpleFunSumGroupsmyjinxin
    {
        [Test]
        public void BasicTests()
        {
            var kata = new SimpleFunSumGroups();

            Assert.AreEqual(6, kata.SumGroups(new int[] { 2, 1, 2, 2, 6, 5, 0, 2, 0, 5, 5, 7, 7, 4, 3, 3, 9 }));

            Assert.AreEqual(5, kata.SumGroups(new int[] { 2, 1, 2, 2, 6, 5, 0, 2, 0, 3, 3, 3, 9, 2 }));

            Assert.AreEqual(1, kata.SumGroups(new int[] { 1 }));

            Assert.AreEqual(1, kata.SumGroups(new int[] { 2 }));

            Assert.AreEqual(2, kata.SumGroups(new int[] { 1, 2 }));

            Assert.AreEqual(1, kata.SumGroups(new int[] { 1, 1, 2, 2 }));
        }
    }

    internal class SimpleFunSumGroups
    {
        public int SumGroups(int[] arr)
        {
            Stack<IEnumerable<int>> stack = new();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    stack.Push(arr.Skip(i).TakeWhile(x => x % 2 == 0));
                }
                else
                {
                    stack.Push(arr.Skip(i).TakeWhile(x => x % 2 != 0));
                }
                i += stack.Peek().Count() - 1;
            }

            if (stack.All(x => x.Count() < 2))
            {
                return stack.Count;
            }

            return SumGroups(stack.Select(x => x.Sum()).ToArray());
        }
    }
}