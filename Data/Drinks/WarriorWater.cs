// Author: Chris Schultz
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Water
    /// </summary>
    public class WarriorWater
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price => 0.00;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories => 0;

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
                if (Lemon) instructions.Add("Add lemon");

                return instructions;
            }
        }

        // Ingredients:
        // Set to true to include in this item and false to exclude them.
        public bool Ice { get; set; } = true;
        public bool Lemon { get; set; } = false;

        /// <returns>A string containing the name of this item.</returns>
        public override string ToString() => $"{Size} Warrior Water";
    }
}
