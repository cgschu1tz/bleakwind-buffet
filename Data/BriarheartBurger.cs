// Author: Christopher Schultz
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    class BriarheartBurger
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price => 6.32;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories => 743;

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

        public override string ToString() => "Briarheart Burger";
    }
}
