// Author: Christopher Schultz
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    class TripleThalmor
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price => 8.32;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories => 943;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
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

        // Ingredients:
        // Set to true to include in this item and false to exclude them.
        public bool Bun { get; set; } = true;
        public bool Ketchup { get; set; } = true;
        public bool Mustard { get; set; } = true;
        public bool Pickle { get; set; } = true;
        public bool Cheese { get; set; } = true;
        public bool Tomato { get; set; } = true;
        public bool Lettuce { get; set; } = true;
        public bool Mayo { get; set; } = true;
        public bool Bacon { get; set; } = true;
        public bool Egg { get; set; } = true;

        public override string ToString() => "Thalmor Triple";
    }
}
