/*
 * Author: Chris Schultz
 * Class name: WarriorWater.cs
 * Purpose: Defines a class for Warrior Water
 */
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Water
    /// </summary>
    public class WarriorWater : Drink, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override decimal Price => 0.00m;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public override uint Calories => 0;

        /// <summary>
        /// The backing variable for the size.
        /// </summary>
        private Size size = Size.Small;

        /// <summary>
        /// The size of this item.
        /// </summary>
        public override Size Size
        {
            get => size;
            set {
                size = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Ice) instructions.Add("Hold ice");
                if (Lemon) instructions.Add("Add lemon");

                return instructions;
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool ice = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Ice
        {
            get => ice;
            set {
                ice = value;
                OnPropertyChanged(nameof(Ice));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool lemon = false;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Lemon
        {
            get => lemon;
            set {
                lemon = value;
                OnPropertyChanged(nameof(Lemon));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} Warrior Water";
    }
}
