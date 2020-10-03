/*
 * Author: Chris Schultz
 * Class name: GardenOrcOmelette.cs
 * Purpose: Defines a class for the Garden Orc Omelette
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Vegetarian omelette
    /// </summary>
    public class GardenOrcOmelette : Entree, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Invoked when a property of this item changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override double Price => 4.57;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public override uint Calories => 404;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Broccoli) instructions.Add("Hold broccoli");
                if (!Mushrooms) instructions.Add("Hold mushrooms");
                if (!Tomato) instructions.Add("Hold tomato");
                if (!Cheddar) instructions.Add("Hold cheddar");

                return instructions;
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool broccoli = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Broccoli
        {
            get => broccoli;
            set {
                broccoli = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Broccoli)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool mushrooms = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Mushrooms
        {
            get => mushrooms;
            set {
                mushrooms = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mushrooms)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool tomato = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Tomato
        {
            get => tomato;
            set {
                tomato = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tomato)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool cheddar = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Cheddar
        {
            get => cheddar;
            set {
                cheddar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cheddar)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
            }
        }

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Garden Orc Omelette";
    }
}
