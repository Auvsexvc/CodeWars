﻿
namespace Kata.Classes
{
    /// <summary>
    /// Write a class Block that creates a block (Duh..)
    /// ##Requirements
    ///     The constructor should take an array as an argument, this will contain 3 integers of the form [width, length, height] from which the Block should be created.
    ///     Define these methods:
    /// `GetWidth()` return the width of the `Block`
    /// `GetLength()` return the length of the `Block`
    /// `GetHeight()` return the height of the `Block`
    /// `GetVolume()` return the volume of the `Block`
    /// `GetSurfaceArea()` return the surface area of the `Block`
    /// ##Examples
    ///     Block b = new Block(new int[] { 2, 4, 6 })->creates a `Block` object with a width of `2` a length of `4` and a height of `6`
    ///         b.GetWidth() ///  -> 2
    ///         b.GetLength() ///  -> 4
    ///         b.GetHeight() ///  -> 6
    ///         b.GetVolume() ///  -> 48
    ///         b.GetSurfaceArea() ///  -> 88
    ///     Note: no error checking is needed
    /// </summary>
    internal class Building_blocks
    {
        public class Block
        {
            private int width;
            private int height;
            private int length;

            public Block(int[] arr)
            {
                width = arr[0];
                length = arr[1];
                height = arr[2];
            }

            public int GetWidth() => this.width;
            public int GetLength() => length;
            public int GetHeight() => height;
            public int GetVolume() => width * length * height;
            public int GetSurfaceArea() => 2 * length * width + 2 * length * height + 2 * height * width;
        }
    }
}