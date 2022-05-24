using System;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Pyramids are amazing! Both in architectural and mathematical sense. If you have a computer, you can mess with pyramids even if you are not in Egypt at the time. For example, let's consider the following problem. Imagine that you have a pyramid built of numbers, like this one here:
    ///   /3/
    ///  \7\ 4
    /// 2 \4\ 6
    ///8 5 \9\ 3
    ///Here comes the task...
    ///Let's say that the 'slide down' is the maximum sum of consecutive numbers from the top to the bottom of the pyramid. As you can see, the longest 'slide down' is 3 + 7 + 4 + 9 = 23
    ///Your task is to write a function that takes a pyramid representation as argument and returns its' largest 'slide down'. For example:
    ///* With the input `[[3], [7, 4], [2, 4, 6], [8, 5, 9, 3]]`
    ///* Your function should return `23`.
    ///By the way...
    ///My tests include some extraordinarily high pyramids so as you can guess, brute-force method is a bad idea unless you have a few centuries to waste.You must come up with something more clever than that.
    /// </summary>
    internal class Pyramid_Slide_Down
    {
        public static int LongestSlideDown(int[][] pyramid)
        {
            for (int i = pyramid.Length - 2; i >= 0; i--)
                for (int j = 0; j < pyramid[i].Length; j++)
                    pyramid[i][j] += Math.Max(pyramid[i + 1][j], pyramid[i + 1][j + 1]);

            return pyramid[0][0];
        }

        public static int LongestSlideDownLinq(int[][] pyramid)
        {
            return pyramid.Reverse().Aggregate((prev, next) =>
            {
                return next.Select((x, i) => x + Math.Max(prev[i], prev[i + 1])).ToArray();
            }).First();
        }
    }
}