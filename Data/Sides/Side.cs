/*
 * Author: Chris Schultz
 * Class name: Side.cs
 * Purpose: Defines an abstract base class for all sides
 */
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Abstract base class for all sides
    /// </summary>
    public abstract class Side
    {
        /// <summary>
        /// The size of this item.
        /// </summary>
        public abstract Size Size { get; set; }

        /// <summary>
        /// The price of the item in USD.
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// How many calories the item contains.
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// A list of instructions to follow when preparing the item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
