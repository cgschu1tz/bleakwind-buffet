/* 
 * Author: Chris Schultz
 * Class name: DragonbornWaffleFries.cs
 * Purpose: Defines a class for Dragonborn Waffle Fries
 */
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Cajun fries
    /// </summary>
    public class DragonbornWaffleFries
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
                    case Size.Small: return 0.42;
                    case Size.Medium: return 0.76;
                    case Size.Large: return 0.96;
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
                    case Size.Small: return 77;
                    case Size.Medium: return 89;
                    case Size.Large: return 100;
                    default: throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The size of this item.
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public List<string> SpecialInstructions => new List<string>();

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} Dragonborn Waffle Fries";
    }
}
