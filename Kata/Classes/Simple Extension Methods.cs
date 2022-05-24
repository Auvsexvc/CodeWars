namespace Kata.Classes
{
    /// <summary>
    /// An extension method allows you to add a fuction to an exsisting type. (See: https://msdn.microsoft.com/en-us//library/bb383977.aspx for examples.)
    /// Your challenge for this Kata is to write two basic extention methods: SayHello and SayGoodbye.
    /// </summary>
    static class Simple_Extension_Methods
    {
        public static string SayHello(this string name) => $"Hello, {name}!";

        public static string SayGoodbye(this string name) => $"Goodbye, {name}. See you again soon!";
    }
}