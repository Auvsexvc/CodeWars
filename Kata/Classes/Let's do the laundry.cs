using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Classes
{
    /// <summary>
    /// Let's do the laundry!
    ///     Your room is a mess full of dirty clothes.You finally decided to take them to the laundry basket (after you mom told you a thousand times).Your mom is so delightful that she washes them for you.
    ///    She noticed some of the clothes are forged...and decides to dispose the washed off clothes.
    /// Forged clothes (IForged) are washed off after 25 times and normal clothes 40 times.
    /// Complete the Laundry class so it can fill a list of IClothing by calling FillLaundryBasket and has a function LetMotherWashTheClothes to process and "wash" the clothes.
    ///    After that, you have to write a function GetSpecificClothes wich is a generic function that returns the total of clothes that is asked for. The available type of clothes are ISock, ITrowser, IShirt.
    ///    Note: you do not need to increase the WashedCount property on a piece of clothing. Available clothing: SportSocks, SilkSocks, ShortTrowsers, ShortSleevedShirt, LongSleevedShirt
    /// </summary>
    internal class Let_s_do_the_laundry
    {
        public class Laundry
        {
            private List<IClothing> _clothes;
            public List<IClothing> Disposed { get; set; }

            //Create the washing things here!
            public List<IClothing> FillLaundryBasket(List<IClothing> clothes)
            {
                _clothes = clothes.Select(c => c).Where(c => (c is IForged && c.WashedCount < 25) || (!(c is IForged) && c.WashedCount < 40)).ToList();
                Disposed = clothes.Select(c => c).Where(c => !_clothes.Contains(c)).ToList();

                return _clothes ?? throw new Exception();
            }

            public void LetMotherWashTheClothes()
            {
                //do the wash
            }

            public virtual int GetSpecificClothes<T>() => _clothes.Where(c => c is T).ToList().Count;

        }
    }

    internal interface IClothing
    {
        public int WashedCount { get; set; }
    }

    internal interface ISportSocks : IClothing
    {

    }
    internal interface ITrowser : IClothing
    {

    }
    internal interface IShirt : IClothing
    {

    }
    internal interface ISocks : IClothing
    {

    }
    internal interface IForged : IClothing
    {
    }
}