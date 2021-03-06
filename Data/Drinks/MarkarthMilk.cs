﻿/*
 * Author: Chris Schultz
 * Class name: MarkarthMilk.cs
 * Purpose: Defines a class for Markarth Milk
 */
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// 2% milk
    /// </summary>
    public class MarkarthMilk : Drink, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// A brief description of this item.
        /// </summary>
        public string Description => "Hormone-free organic 2% milk.";

        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// <see cref="Size"/> is not a valid size
        /// </exception>
        public override decimal Price
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 1.05m;
                    case Size.Medium: return 1.11m;
                    case Size.Large: default: return 1.22m;
                }
            }
        }

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// <see cref="Size"/> is not a valid size
        /// </exception>
        public override uint Calories
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 56;
                    case Size.Medium: return 72;
                    case Size.Large: default: return 93;
                }
            }
        }

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
                OnPropertyChanged(nameof(Calories));
                OnPropertyChanged(nameof(Price));
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

                if (Ice) instructions.Add("Add ice");

                return instructions;
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool ice = false;

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
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} Markarth Milk";
    }
}
