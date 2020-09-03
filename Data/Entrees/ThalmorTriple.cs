/*
 * Author: Chris Schultz
 * Class name: ThalmorTriple.cs
 * Purpose: Defines a class for the Thalmor Triple
 */
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// A 1lb burger
    /// </summary>
    public class ThalmorTriple
    {
        /// <value>
        /// The price of this item in USD.
        /// </value>
        public double Price => 8.32;

        /// <value>
        /// How many calories this item contains.
        /// </value>
        public uint Calories => 943;

        /// <value>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </value>
        public List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Bun) instructions.Add("Hold bun");
                if (!Ketchup) instructions.Add("Hold ketchup");
                if (!Mustard) instructions.Add("Hold mustard");
                if (!Pickle) instructions.Add("Hold pickle");
                if (!Cheese) instructions.Add("Hold cheese");
                if (!Tomato) instructions.Add("Hold tomato");
                if (!Lettuce) instructions.Add("Hold lettuce");
                if (!Mayo) instructions.Add("Hold mayo");
                if (!Bacon) instructions.Add("Hold bacon");
                if (!Egg) instructions.Add("Hold egg");

                return instructions;
            }
        }

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Bun { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Ketchup { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Mustard { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Pickle { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Cheese { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Tomato { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Lettuce { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Mayo { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Bacon { get; set; } = true;

        /// <value>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </value>
        public bool Egg { get; set; } = true;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Thalmor Triple";
    }
}
