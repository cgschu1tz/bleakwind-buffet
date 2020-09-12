/*
 * Author: Chris Schultz
 * Class name: Entree.cs
 * Purpose: Defines an abstract base class for all entrees
 */
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Abstract base class for all entrees
    /// </summary>
    public abstract class Entree
    {
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
