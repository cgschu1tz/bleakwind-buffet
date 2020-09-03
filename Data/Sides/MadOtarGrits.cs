/*
 * Author: Chris Schultz
 * Class name: MadOtarGrits.cs
 * Purpose: Define a class for Mad Otar Grits
 */
using BleakwindBuffet.Data.Enums;
using System;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Cheesy grits
    /// </summary>
    public class MadOtarGrits
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
                    case Size.Small: return 1.22;
                    case Size.Medium: return 1.58;
                    case Size.Large: return 1.93;
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
                    case Size.Small: return 105;
                    case Size.Medium: return 142;
                    case Size.Large: return 179;
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
        public override string ToString() => $"{Size} Mad Otar Grits";
    }
}
