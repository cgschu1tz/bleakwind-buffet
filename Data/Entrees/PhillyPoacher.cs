/*
 * Author: Chris Schultz
 * Class name: PhillyPoacher.cs
 * Purpose: Defines a class for the Philly Poacher
 */
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Philly cheesesteak sandwich
    /// </summary>
    public class PhillyPoacher
    {
        /// <value>
        /// The price of this item in USD.
        /// </value>
        public double Price => 7.23;

        /// <value>
        /// How many calories this item contains.
        /// </value>
        public uint Calories => 784;

        /// <value>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </value>
        public List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Sirloin) instructions.Add("Hold sirloins");
                if (!Onion) instructions.Add("Hold onions");
                if (!Roll) instructions.Add("Hold roll");

                return instructions;
            }
        }

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Sirloin { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Onion { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Roll { get; set; } = true;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Philly Poacher";
    }
}
