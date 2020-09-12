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
    public class PhillyPoacher : Entree, IOrderItem
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override double Price => 7.23;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public override uint Calories => 784;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Sirloin) instructions.Add("Hold sirloin");
                if (!Onion) instructions.Add("Hold onions");
                if (!Roll) instructions.Add("Hold roll");

                return instructions;
            }
        }

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Sirloin { get; set; } = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Onion { get; set; } = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Roll { get; set; } = true;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Philly Poacher";
    }
}
