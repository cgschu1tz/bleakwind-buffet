// Author: Chris Schultz
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Breakfast combo
    /// </summary>
    public class SmokehouseSkeleton
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price => 5.62;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories => 602;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!SausageLink) instructions.Add("Hold sausage");
                if (!Egg) instructions.Add("Hold eggs");
                if (!HashBrowns) instructions.Add("Hold hash browns");
                if (!Pancake) instructions.Add("Hold pancakes");

                return instructions;
            }
        }

        // Ingredients:
        // Set to true to include in this item and false to exclude them.
        public bool SausageLink { get; set; } = true;
        public bool Egg { get; set; } = true;
        public bool HashBrowns { get; set; } = true;
        public bool Pancake { get; set; } = true;

        /// <returns>A string containing the name of this item.</returns>
        public override string ToString() => "Smokehouse Skeleton";
    }
}
