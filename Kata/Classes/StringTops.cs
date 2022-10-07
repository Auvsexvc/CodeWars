using NUnit.Framework;
using System;
using System.Text;

namespace Kata.Classes
{
    internal class StringTops
    {
        public static class Kata
        {
            public static string Tops(string msg)
            {
                StringBuilder sb = new StringBuilder();

                if (msg.Length < 2)
                {
                    return msg;
                }

                int index = 1;
                var delta = index;
                while (index < msg.Length)
                {
                    sb.Insert(0, msg[index]);
                    delta += 4;
                    index += sb.Length * 4;
                }

                return sb.ToString();
            }
        }

        [TestFixture]
        public class TopsTest
        {
            [Test, Description("Should work for basic strings")]
            public void BasicTest()
            {
                Assert.AreEqual("3pgb", Kata.Tops("abcdefghijklmnopqrstuvwxyz12345"));
                Assert.AreEqual(String.Empty, Kata.Tops(String.Empty));
                Assert.AreEqual("2", Kata.Tops("12"));
                Assert.AreEqual("M3pgb", Kata.Tops("abcdefghijklmnopqrstuvwxyz1236789ABCDEFGHIJKLMN"));
            }
        }
    }
}