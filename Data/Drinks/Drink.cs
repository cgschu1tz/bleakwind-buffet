﻿/*
 * Author: Chris Schultz
 * Class name: Drink.cs
 * Purpose: Defines an abstract base class for all drinks
 */
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Abstract base class for all drinks
    /// </summary>
    public abstract class Drink : INotifyPropertyChanged
    {
        /// <summary>
        /// The name of this item.
        /// </summary>
        public string Name => ToString();

        /// <summary>
        /// Invoked when a property of this item changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The size of this item.
        /// </summary>
        public abstract Size Size { get; set; }

        /// <summary>
        /// The price of the item in USD.
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// How many calories the item contains.
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// A list of instructions to follow when preparing the item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }

        /// <summary>
        /// Invokes the <see cref="PropertyChanged"/> event with the 
        /// name of the property that changed.
        /// </summary>
        /// <param name="propertyName">the name of the property that changed</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        }
    }
}
