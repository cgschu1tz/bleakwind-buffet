/*
 * Author: Chris Schultz
 * Class name: FriedMiraak.cs
 * Purpose: Defines a class for Fried Miraak
 */
using BleakwindBuffet.Data.Enums;
using System;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Hash brown pancakes
    /// </summary>
    public class FriedMiraak
    {
        /// <value>
        /// The price of this item in USD.
        /// </value>
        /// <exception cref="NotImplementedException">
        /// <see cref="Size"/> is not a valid size
        /// </exception>
        public double Price
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 1.78;
                    case Size.Medium: return 2.01;
                    case Size.Large: return 2.88;
                    default: throw new NotImplementedException();
                }
            }
        }

        /// <value>
        /// How many calories this item contains.
        /// </value>
        /// <exception cref="NotImplementedException">
        /// <see cref="Size"/> is not a valid size
        /// </exception>
        public uint Calories
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 151;
                    case Size.Medium: return 236;
                    case Size.Large: return 306;
                    default: throw new NotImplementedException();
                }
            }
        }

        /// <value>
        /// The size of this item.
        /// </value>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} Fried Miraak";
    }
}
