/* 
 * Author: Chris Schultz
 * Class name: DragonbornWaffleFries.cs
 * Purpose: Defines a class for Dragonborn Waffle Fries
 */
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Sides
{
    /// <summary>
    /// Cajun fries
    /// </summary>
    public class DragonbornWaffleFries : Side, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// A brief description of this item.
        /// </summary>
        public string Description => "Crispy fried potato waffle fries.";

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
                    case Size.Small: return 0.42m;
                    case Size.Medium: return 0.76m;
                    case Size.Large: default: return 0.96m;
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
                    case Size.Small: return 77;
                    case Size.Medium: return 89;
                    case Size.Large: default: return 100;
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
        public override string ToString() => $"{Size} Dragonborn Waffle Fries";
    }
}
