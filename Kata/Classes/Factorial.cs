namespace Kata.Classes
{
    public static class Factorial
    {
        public static int FactorialFn(int n) => (n == 0) ? 1 : n * FactorialFn(n - 1);
    }
}