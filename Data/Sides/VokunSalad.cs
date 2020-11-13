/*
 * Author: Chris Schultz
 * Class name: VokunSalad.cs
 * Purpose: Defines a class for Vokun Salad
 */
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// A fruit salad
    /// </summary>
    public class VokunSalad : Side, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// A brief description of this item.
        /// </summary>
        public string Description => "A seasonal fruit salad of melons, berries, mangoes, grapes, apples, and oranges.";

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
                    case Size.Small: return 0.93m;
                    case Size.Medium: return 1.28m;
                    case Size.Large: default: return 1.82m;
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
                    case Size.Small: return 41;
                    case Size.Medium: return 52;
                    case Size.Large: default: return 73;
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
        public override List<string> SpecialInstructions => new List<string>();

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} Vokun Salad";
    }
}
