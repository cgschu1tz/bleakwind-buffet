using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    class GardenOrcOmelette
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price => 4.57;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories => 404;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
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

        // Ingredients:
        // Set to true to include in this item and false to exclude them.
        public bool Broccoli { get; set; } = true;
        public bool Mushrooms { get; set; } = true;
        public bool Tomato { get; set; } = true;
        public bool Cheddar { get; set; } = true;

        public override string ToString() => "Garden Orc Omelette";
    }
}
