// Author: Christopher Schultz
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    class SailorSoda
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price
        {
            get {
                switch (Size)
                {
                    case Size.Small:
                        return 1.42;
                    case Size.Medium:
                        return 1.74;
                    case Size.Large:
                        return 2.07;
                    default:
                        throw new NotImplementedException();
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
                    case Size.Small:
                        return 117;
                    case Size.Medium:
                        return 153;
                    case Size.Large:
                        return 205;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public Size Size { get; } = Size.Small;

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

        SodaFlavor Flavor { get; set; } = SodaFlavor.Cherry;

        public override string ToString() => $"{Size} {Flavor} Sailor Soda";
    }
}
