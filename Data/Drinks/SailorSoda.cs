/*
 * Author: Chris Schultz
 * Class name: SailorSoda.cs
 * Purpose: Defines a class for the Sailor Soda
 */
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Old-fashioned soda
    /// </summary>
    public class SailorSoda : Drink, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// A brief description of this item.
        /// </summary>
        public string Description => "An old-fashioned jerked soda, carbonated water and flavored syrup poured over a bed of crushed ice.";

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
                    case Size.Small: return 1.42m;
                    case Size.Medium: return 1.74m;
                    case Size.Large: default: return 2.07m;
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
                    case Size.Small: return 117;
                    case Size.Medium: return 153;
                    case Size.Large: default: return 205;
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

                if (!Ice) instructions.Add("Hold ice");

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
        /// The backing variable for the soda flavor.
        /// </summary>
        private SodaFlavor flavor = SodaFlavor.Cherry;

        /// <summary>
        /// The flavor of syrup to mix in this drink.
        /// </summary>
        public SodaFlavor Flavor
        {
            get => flavor;
            set {
                flavor = value;
                OnPropertyChanged(nameof(Flavor));
            }
        }

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => $"{Size} {Flavor} Sailor Soda";
    }
}
