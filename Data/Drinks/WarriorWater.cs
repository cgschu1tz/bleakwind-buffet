/*
 * Author: Chris Schultz
 * Class name: WarriorWater.cs
 * Purpose: Defines a class for Warrior Water
 */
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Water
    /// </summary>
    public class WarriorWater : IOrderItem
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

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Lemon { get; set; } = false;

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} Warrior Water";
    }
}
