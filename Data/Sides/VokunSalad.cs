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
        /// <value>
        /// The price of this item in USD.
        /// </value>
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

        /// <value>
        /// How many calories this item contains.
        /// </value>
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

        /// <value>
        /// The size of this item.
        /// </value>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} Vokun Salad";
    }
}
