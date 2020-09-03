/*
 * Author: Chris Schultz
 * Class name: GardenOrcOmelette.cs
 * Purpose: Defines a class for the Garden Orc Omelette
 */
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Vegetarian omelette
    /// </summary>
    public class GardenOrcOmelette
    {
        /// <value>
        /// The price of this item in USD.
        /// </value>
        public double Price => 4.57;

        /// <value>
        /// How many calories this item contains.
        /// </value>
        public uint Calories => 404;

        /// <value>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </value>
        public List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Broccoli) instructions.Add("Hold broccoli");
                if (!Mushrooms) instructions.Add("Hold mushrooms");
                if (!Tomato) instructions.Add("Hold tomato");
                if (!Cheddar) instructions.Add("Hold cheddar");

                return instructions;
            }
        }

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Broccoli { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Mushrooms { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Tomato { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Cheddar { get; set; } = true;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Garden Orc Omelette";
    }
}
