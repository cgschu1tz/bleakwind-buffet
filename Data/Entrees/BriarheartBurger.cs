/*
 * Author: Chris Schultz
 * Class name: BriarheartBurger.cs
 * Purpose: Defines a class for the Briarheart Burger
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// A 1/4lb burger
    /// </summary>
    public class BriarheartBurger : Entree, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// A brief description of this item.
        /// </summary>
        public string Description => "Single patty burger on a brioche bun. Comes with ketchup, mustard, pickle, and cheese.";

        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override decimal Price => 6.32m;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public override uint Calories => 743;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!Bun) instructions.Add("Hold bun");
                if (!Ketchup) instructions.Add("Hold ketchup");
                if (!Mustard) instructions.Add("Hold mustard");
                if (!Pickle) instructions.Add("Hold pickle");
                if (!Cheese) instructions.Add("Hold cheese");

                return instructions;
            }
        }

        /// <summary>
        /// The backing variable for an ingredient.
        /// </summary>
        private bool bun = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Bun
        {
            get => bun;
            set {
                bun = value;
                OnPropertyChanged(nameof(Bun));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The backing variable for an ingredient.
        /// </summary>
        private bool ketchup = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Ketchup
        {
            get => ketchup;
            set {
                ketchup = value;
                OnPropertyChanged(nameof(Ketchup));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The backing variable for an ingredient.
        /// </summary>
        private bool mustard = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Mustard
        {
            get => mustard;
            set {
                mustard = value;
                OnPropertyChanged(nameof(Mustard));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The backing variable for an ingredient.
        /// </summary>
        private bool pickle = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Pickle
        {
            get => pickle;
            set {
                pickle = value;
                OnPropertyChanged(nameof(Pickle));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// The backing variable for an ingredient.
        /// </summary>
        private bool cheese = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Cheese
        {
            get => cheese;
            set {
                cheese = value;
                OnPropertyChanged(nameof(Cheese));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Briarheart Burger";
    }
}
