/*
 * Author: Chris Schultz
 * Class name: Entree.cs
 * Purpose: Defines an abstract base class for all entrees
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Abstract base class for all entrees
    /// </summary>
    public abstract class Entree : INotifyPropertyChanged
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
        /// The price of the item in USD.
        /// </summary>
        public abstract double Price { get; }

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
