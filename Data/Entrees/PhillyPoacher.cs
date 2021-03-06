﻿/*
 * Author: Chris Schultz
 * Class name: PhillyPoacher.cs
 * Purpose: Defines a class for the Philly Poacher
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Philly cheesesteak sandwich
    /// </summary>
    public class PhillyPoacher : Entree, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// A brief description of this item.
        /// </summary>
        public string Description => "Cheesesteak sandwich made from grilled sirloin, topped with onions on a fried roll.";

        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override decimal Price => 7.23m;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public override uint Calories => 784;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Sirloin) instructions.Add("Hold sirloin");
                if (!Onion) instructions.Add("Hold onions");
                if (!Roll) instructions.Add("Hold roll");

                return instructions;
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool sirloin = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Sirloin
        {
            get => sirloin;
            set {
                sirloin = value;
                OnPropertyChanged(nameof(Sirloin));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool onion = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Onion
        {
            get => onion;
            set {
                onion = value;
                OnPropertyChanged(nameof(Onion));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool roll = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Roll
        {
            get => roll;
            set {
                roll = value;
                OnPropertyChanged(nameof(Roll));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Philly Poacher";
    }
}
