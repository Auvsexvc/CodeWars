using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    [TestFixture]
    public class BraceTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(true, Brace.ValidBraces("()"));
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(false, Brace.ValidBraces("[(])"));
        }

        [Test]
        public void Test3()
        {
            Assert.AreEqual(true, Brace.ValidBraces("(({{[[]]}}))"));
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual(true, Brace.ValidBraces("{}({})[]"));
        }

        [Test]
        public void Test5()
        {
            Assert.AreEqual(false, Brace.ValidBraces("(((({{"));
        }

        [Test]
        public void Test6()
        {
            Assert.AreEqual(false, Brace.ValidBraces(")(}{]["));
        }
    }

    internal class Brace
    {
        public static bool ValidBraces(String braces)
        {
            Stack<char> hayStack = new Stack<char>();
            Dictionary<char, char> bracesDict = new() { { '(', ')' }, { '[', ']' }, { '{', '}' } };

            if (bracesDict.ContainsValue(braces.FirstOrDefault()) || bracesDict.ContainsKey(braces.LastOrDefault()))
            {
                return false;
            }

            foreach (char chr in braces)
            {
                if (bracesDict.ContainsKey(chr))
                {
                    hayStack.Push(chr);
                }
                else if (bracesDict.ContainsValue(chr))
                {
                    if (hayStack.Peek() != bracesDict.FirstOrDefault(d => chr == d.Value).Key)
                    {
                        return false;
                    }
                    else
                    {
                        hayStack.Pop();
                    }
                }
            }

            return true;
        }
    }
}