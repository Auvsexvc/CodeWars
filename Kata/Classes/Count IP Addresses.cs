using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Implement a function that receives two IPv4 addresses, and returns the number of addresses between them (including the first one, excluding the last one).
    /// All inputs will be valid IPv4 addresses in the form of strings.The last address will always be greater than the first one.
    /// </summary>
    internal class Count_IP_Addresses
    {
        public static long IpsBetween(string start, string end)
        {
            return start.Split('.')
            .Select(x => Byte.Parse(x))
                                    .Select((b, i) => (
                                         end.Split('.')
                                            .Select(x => Byte.Parse(x))
                                            .ElementAt(i) - start.Split('.')
                                                                 .Select(x => Byte.Parse(x))
                                                                 .ElementAt(i)) * (long)Math
                                                                                            .Pow(256, start
                                                                                                            .Split('.')
                                                                                                            .Select(x => Byte.Parse(x))
                                                                                                            .Count() - 1 - i))
                                    .Sum();
        }
    }
}