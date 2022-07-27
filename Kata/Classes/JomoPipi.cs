using NUnit.Framework;
using System.Collections.Generic;

namespace Kata.Classes
{
    [TestFixture]
    public class JomoPipiTest
    {
        [Test]
        public void Basic_Test_Of_The_Number_1()
        {
            string s = "c#", a = "c#";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 0));
        }

        [Test]
        public void Basic_Test_Of_The_Number_2()
        {
            string s = "Such Wow!", a = "Sc o!uhWw";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 1));
        }

        [Test]
        public void Basic_Test_Of_The_Number_3()
        {
            string s = "better example", a = "bexltept merae";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 2));
        }

        [Test]
        public void Basic_Test_Of_The_Number_4()
        {
            string s = "qwertyuio", a = "qtorieuwy";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 2));
        }

        [Test]
        public void Basic_Test_Of_The_Number_5()
        {
            string s = "Greetings", a = "Gtsegenri";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 8));
        }

        [Test]
        public void large_strings_large_n()
        {
            string s = "System.Char[]", a = "SmrsC]eay.[th";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 200001));
        }

        [Test]
        public void large_strings_large_n2()
        {
            string s = "System.Char[]", a = "SCyhsatre[m].";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 200003));
        }

        [Test]
        public void BROWSER_CHOKER()
        {
            string s = "System.Char[]", a = "System.Char[]";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 100010001000));
        }

        [Test]
        public void Fixed_Large_Tests1()
        {
            string s = "I like it!", a = "Iiei t kl!";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 1234));
        }

        [Test]
        public void Fixed_Large_Tests2()
        {
            string s = "codingisfornerdsyounerd", a = "criyinodedsgufrnodnoser";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 10101010));
        }

        [Test]
        public void Seven_Thousand_Random_Tests()
        {
            string s = "otKy5yFk2IlY7MuPBBrrou432UC7P9AExbTFfFYF1lno97zJi5MSC8Mn02ADL7B0W9e03H5V7K3v{2YtaN8GE703{61l3QEfEBZ31Dd37kKI3YGdMvz8Rw1N6vZ1V91xFxCpcK1E341k3YKO4m9tbls5uYm03VCRh27om2D", a = "o72fiL7EE36c43tMUF57K7BYvKmVKuCYMB30ZGZ19CyP7FS0v33d1EtR5BP1CW{{1MV3bhyB9l8926Dv94l2FrAnMeY1dz11s7krEon0tl38xk5o2ox903a37RF3umIub72HNQkwxYY2l4TzA58EK1CKmDY3FJDVGfINpO0";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 1965255292));
        }

        [Test]
        public void Seven_Thousand_Random_Tests2()
        {
            string s = "5rPAQBDINQ4h0NQ666l7gn9Rj6C39H8c0BQQiWt7XgIW2q9nEV6m9SH0qi0iN4HFzw373n216Io7c1sj0f0XEqI0CIwnmo5UJ{R1Y24iMFW360mNgfgfaJL931azj1J3ZWE5YAn7SAJD2q96d847ITKsRGFkY7Eh4PQ{1", a = "5RcWH4oCjikCn99KX6gn8sh0I2IDMW73r10EFP5310YI93SsE6fE4j0mWqoIFtSnPYB5zQU9Ji7wR1HRqlaV70NN297NW7A2A2QYw{JH3NEnja0GI7J6IfQgq6cQ3XJ1Q4QA31{8Z4hm6zqF0gLmT06f9d146gD6Biin7";
            Assert.AreEqual(a, JomoPipi.jumbledString(s, 1468023715));
        }
    }

    internal class JomoPipi
    {
        public static string jumbledString(string s, long n)
        {
            long x = n;
            string orig = s;
            int counter = 1;
            List<string> strings = new();
            strings.Add(s);

            while (true)
            {
                string str1 = string.Empty;
                string str2 = string.Empty;

                for (int i = 0; i < s.Length; i++)
                {
                    if (i % 2 == 0)
                        str1 += s[i];
                    else
                        str2 += s[i];
                }
                s = str1 + str2;

                if (s == orig)
                {
                    n = (x % counter);
                    break;
                }
                strings.Add(s);
                counter++;
                n--;
                System.Console.WriteLine($"{n}: {counter} : {s}");
            }

            return strings[(int)n];

            //n = n % (s.Length - 1);

            //return n > 0
            //    ? jumbledString(string.Concat(Enumerable.Range(0, s.ToCharArray().Length).GroupBy(i => i % 2 == 0).SelectMany(g => g.Select(e => s[e]))), n: n - 1)
            //    : s;
        }
    }
}