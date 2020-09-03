/*
 * Author: Chris Schultz
 * Class name: SailorSoda.cs
 * Purpose: Defines a class for the Sailor Soda
 */
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Old-fashioned soda
    /// </summary>
    public class SailorSoda
    {
        /// <value>
        /// The price of this item in USD.
        /// </value>
        public double Price
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 1.42;
                    case Size.Medium: return 1.74;
                    case Size.Large: return 2.07;
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
                    case Size.Small: return 117;
                    case Size.Medium: return 153;
                    case Size.Large: return 205;
                    default: throw new NotImplementedException();
                }
            }
        }

        /// <value>
        /// The size of this item.
        /// </value>
        public Size Size { get; set; } = Size.Small;

        /// <value>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </value>
        public List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Ice) instructions.Add("Hold ice");

                return instructions;
            }
        }

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Ice { get; set; } = true;

        /// <value>
        /// The flavor of syrup to mix in this drink.
        /// </value>
        SodaFlavor Flavor { get; set; } = SodaFlavor.Cherry;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} {Flavor} Sailor Soda";
    }
}
