using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    internal class RGB_To_Hex_Conversion
    {
        /// <summary>
        /// The rgb function is incomplete. Complete it so that passing in RGB decimal values will result in a hexadecimal representation being returned. Valid decimal values for RGB are 0 - 255.
        /// Any values that fall out of that range must be rounded to the closest valid value.
        /// Note: Your answer should always be 6 characters long, the shorthand with 3 will not work here.
        /// The following are examples of expected output values:
        /// Rgb(255, 255, 255) # returns FFFFFF
        /// Rgb(255, 255, 300) # returns FFFFFF
        /// Rgb(0,0,0) # returns 000000
        /// Rgb(148, 0, 211) # returns 9400D3
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Rgb(int r, int g, int b) =>
            (new string(ToHexString(new List<int> { r, r, g, g, b, b }
            .Select(c => c > 255 ? c = 255 : (c < 0 ? c = 0 : c))
            .Select((c, i) => i % 2 == 0 ? (((c - (c % 16)) / 16)) : (((c % 16))))
            .ToArray())));            

        public static string ToHexString(int[] arr) =>
            String.Join("", arr
                .Select(e => e.ToString().Length > 1 ? new string((e % 9).ToString().Select(c => c = (char)((int)(c) + 16)).FirstOrDefault().ToString()) : new string(e.ToString()))
                .ToArray());
    }
}