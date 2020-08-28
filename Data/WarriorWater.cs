// Author: Christopher Schultz
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    class WarriorWater
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price => 0.00;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories => 0;

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
                if (Lemon) instructions.Add("Add lemon");

                return instructions;
            }
        }

        // Ingredients:
        // Set to true to include in this item and false to exclude them.
        public bool Ice { get; set; } = true;
        public bool Lemon { get; set; } = false;

        public override string ToString() => $"{Size} Warrior Water";
    }
}
