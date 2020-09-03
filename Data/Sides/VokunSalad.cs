/*
 * Author: Chris Schultz
 * Class name: VokunSalad.cs
 * Purpose: Defines a class for Vokun Salad
 */
using BleakwindBuffet.Data.Enums;
using System;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// A fruit salad
    /// </summary>
    public class VokunSalad
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// <see cref="Size"/> is not a valid size
        /// </exception>
        public double Price
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 0.93;
                    case Size.Medium: return 1.28;
                    case Size.Large: return 1.82;
                    default: throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// <see cref="Size"/> is not a valid size
        /// </exception>
        public uint Calories
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 41;
                    case Size.Medium: return 52;
                    case Size.Large: return 73;
                    default: throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The size of this item.
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} Vokun Salad";
    }
}
