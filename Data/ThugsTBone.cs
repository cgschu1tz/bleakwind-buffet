﻿// Author: Chris Schultz
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// T-Bone steak
    /// </summary>
    public class ThugsTBone
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price => 6.44;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories => 982;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public List<string> SpecialInstructions => new List<string>();

        /// <returns>A string containing the name of this item.</returns>
        public override string ToString() => "Thugs T-Bone";
    }
}
