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
        /// A brief description of this item.
        /// </summary>
        public string Description => "Vegetarian. Two egg omelette packed with a mix of broccoli, mushrooms, and tomatoes. Topped with cheddar cheese.";

        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override decimal Price => 4.57m;

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
                OnPropertyChanged(nameof(Broccoli));
                OnPropertyChanged(nameof(SpecialInstructions));
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
                OnPropertyChanged(nameof(Mushrooms));
                OnPropertyChanged(nameof(SpecialInstructions));
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
                OnPropertyChanged(nameof(Tomato));
                OnPropertyChanged(nameof(SpecialInstructions));
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
                OnPropertyChanged(nameof(Cheddar));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Garden Orc Omelette";
    }
}
