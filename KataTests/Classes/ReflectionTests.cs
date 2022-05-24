using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Classes.Reflection_3___Add_the_member_results.Tests
{
    [TestClass()]
    public class testClass
    {
        public string Output1()
        {
            return "Output";
        }

        public string Output2()
        {
            return "It";
        }
    }

    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void NullTest()
        {
            Assert.AreEqual("", Reflection.ConcatStringMembers(null));
        }

        [Test]
        public void ObjectTest()
        {
            var testObject = new testClass();
            var concattedString = Reflection.ConcatStringMembers(testObject);
            Assert.AreEqual("OutputIt", concattedString);
        }
    }
}