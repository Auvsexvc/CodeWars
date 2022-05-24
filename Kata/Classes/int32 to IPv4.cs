using System.Net;

namespace Kata.Classes
{
    /// <summary>
    /// Complete the function that takes an unsigned 32 bit number and returns a string representation of its IPv4 address.
    /// </summary>
    internal class int32_to_IPv4
    {
        public static string UInt32ToIP(uint ip) =>
            IPAddress.Parse(ip.ToString()).ToString();
    }
}