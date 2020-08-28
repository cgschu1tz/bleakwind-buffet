using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    class PhillyPoacher
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price => 7.23;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories => 784;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
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

        // Ingredients:
        // Set to true to include in this item and false to exclude them.
        public bool Sirloin { get; set; } = true;
        public bool Onion { get; set; } = true;
        public bool Roll { get; set; } = true;

        public override string ToString() =>"Philly Poacher";
    }
}
