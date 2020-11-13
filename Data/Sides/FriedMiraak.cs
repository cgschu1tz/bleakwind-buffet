/*
 * Author: Chris Schultz
 * Class name: FriedMiraak.cs
 * Purpose: Defines a class for Fried Miraak
 */
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Hash brown pancakes
    /// </summary>
    public class FriedMiraak : Side, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// A brief description of this item.
        /// </summary>
        public string Description => "Perfectly prepared hash brown pancakes.";

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
                    case Size.Small: return 1.78m;
                    case Size.Medium: return 2.01m;
                    case Size.Large: default: return 2.88m;
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
                    case Size.Small: return 151;
                    case Size.Medium: return 236;
                    case Size.Large: default: return 306;
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
        public override string ToString() => $"{Size} Fried Miraak";
    }
}
