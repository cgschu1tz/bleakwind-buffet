/*
 * Author: Chris Schultz
 * Class name: CandlehearthCoffee.cs
 * Purpose: Defines a class for Candlehearth Coffee
 */
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Coffee
    /// </summary>
    public class CandlehearthCoffee
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
                    case Size.Small: return 0.75;
                    case Size.Medium: return 1.25;
                    case Size.Large: return 1.75;
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
                    case Size.Small: return 7;
                    case Size.Medium: return 10;
                    case Size.Large: return 20;
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
                if (RoomForCream) instructions.Add("Add cream");

                return instructions;
            }
        }

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Ice { get; set; } = false;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool RoomForCream { get; set; } = false;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Decaf { get; set; } = false;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString()
        {
            if (Decaf)
            {
                return $"{Size} Decaf Candlehearth Coffee";
            }
            else
            {
                return $"{Size} Candlehearth Coffee";
            }
        }
    }
}
