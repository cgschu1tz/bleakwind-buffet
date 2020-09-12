﻿/*
 * Author: Chris Schultz
 * Class name: BriarheartBurger.cs
 * Purpose: Defines a class for the Briarheart Burger
 */
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// A 1/4lb burger
    /// </summary>
    public class BriarheartBurger : Entree, IOrderItem
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override double Price => 6.32;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public override uint Calories => 743;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public override List<string> SpecialInstructions
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

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Bun { get; set; } = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Ketchup { get; set; } = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Mustard { get; set; } = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Briarheart Burger";
    }
}
