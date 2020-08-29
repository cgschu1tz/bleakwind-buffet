// Author: Chris Schultz
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Old-fashioned soda
    /// </summary>
    public class SailorSoda
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
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

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
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

        /// <summary>
        /// The size of this item.
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Ice) instructions.Add("Hold ice");

                return instructions;
            }
        }

        // Ingredients:
        // Set to true to include in this item and false to exclude them.
        public bool Ice { get; set; } = true;

        /// <summary>
        /// The flavor of syrup to mix in this drink.
        /// </summary>
        SodaFlavor Flavor { get; set; } = SodaFlavor.Cherry;

        /// <returns>A string containing the name of this item.</returns>
        public override string ToString() => $"{Size} {Flavor} Sailor Soda";
    }
}
