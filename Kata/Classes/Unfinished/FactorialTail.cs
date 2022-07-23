using NUnit.Framework;

namespace Kata.Classes.Unfinished
{
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void Can_Be_Solved_With_Basic_Computations()
        {
            Assert.AreEqual(2, FactorialTail.zeroes(10, 10));
            Assert.AreEqual(3, FactorialTail.zeroes(16, 16));
        }
    }

    /// <summary>
    /// How many zeroes are at the end of the factorial of 10? 10! = 3628800, i.e. there are 2
    /// zeroes. 16! (or 0x10!) in hexadecimal would be 0x130777758000, which has 3 zeroes.
    /// Unfortunately, machine integer numbers has not enough precision for larger values. Floating
    /// point numbers drop the tail we need. We can fall back to arbitrary-precision ones -
    /// built-ins or from a library, but calculating the full product isn't an efficient way to find
    /// just the tail of a factorial. Calculating 100'000! in compiled language takes around 10
    /// seconds. 1'000'000! would be around 10 minutes, even using efficient Karatsuba algorithm
    /// Your task is to write a function, which will find the number of zeroes at the end of
    /// (number) factorial in arbitrary radix = base for larger numbers.
    /// - base is an integer from 2 to 256
    /// - number is an integer from 1 to 1'000'000 Note Second argument: number is always declared,
    /// passed and displayed as a regular decimal number. If you see a test described as 42! in base
    /// 20 it's 4210 not 4220 = 8210.
    /// </summary>
    internal class FactorialTail
    {
        public static int zeroes(int radix, int number)
        {
            int gcfg = radix/2;
            if (radix != 10)
                gcfg = Gcf(10, radix);

            if (number < 0)
                return -1;

            int count = 0;

            for (int i = gcfg; number / i >= 1; i *= gcfg)
                count += number / i;

            return count;
        }

        private static int Gcf(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}