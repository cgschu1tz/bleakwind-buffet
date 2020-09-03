/*
 * Author: Chris Schultz
 * Class name: MarkarthMilk.cs
 * Purpose: Defines a class for Markarth Milk
 */
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// 2% milk
    /// </summary>
    public class MarkarthMilk
    {
        /// <value>
        /// The price of this item in USD.
        /// </value>
        public double Price
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 1.05;
                    case Size.Medium: return 1.11;
                    case Size.Large: return 1.22;
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
                    case Size.Small: return 56;
                    case Size.Medium: return 72;
                    case Size.Large: return 93;
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

                if (Ice) instructions.Add("Add ice");

                return instructions;
            }
        }

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Ice { get; set; } = false;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} Markath Milk";
    }
}
