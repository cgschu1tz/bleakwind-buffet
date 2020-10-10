/*
 * Author: Chris Schultz
 * Class name: Combo.cs
 * Purpose: Defines a class for a combo of a drink, a side, and an entree
 */
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// A combo of one drink, one side, and one entree
    /// </summary>
    public class Combo : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// The drink in this combo
        /// </summary>
        private Drink drink;

        /// <summary>
        /// The entree in this combo
        /// </summary>
        private Entree entree;

        /// <summary>
        /// The side in this combo
        /// </summary>
        private Side side;

        /// <summary>
        /// Invoked when a property of this item changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price => Drink.Price + Entree.Price + Side.Price - 1.00;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories => Drink.Calories + Entree.Calories + Side.Calories;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                instructions.Add(Entree.ToString());
                instructions.AddRange(Entree.SpecialInstructions);

                instructions.Add(Side.ToString());
                instructions.AddRange(Side.SpecialInstructions);

                instructions.Add(Drink.ToString());
                instructions.AddRange(Drink.SpecialInstructions);

                return instructions;
            }
        }

        /// <summary>
        /// The drink associated with this combo
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Cannot set <see cref="Drink"/> to <c>null</c>
        /// </exception>
        public Drink Drink
        {
            get => drink;
            set {
                if (value == null) throw new InvalidOperationException();
                if (drink != value)
                {
                    if (drink != null) drink.PropertyChanged -= OnItemChanged;
                    drink = value;
                    drink.PropertyChanged += OnItemChanged;
                    OnItemChanged(null, null);
                }
            }
        }


        /// <summary>
        /// The entree associated with this combo
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Cannot set <see cref="Entree"/> to <c>null</c>
        /// </exception>
        public Entree Entree
        {
            get => entree;
            set {
                if (value == null) throw new InvalidOperationException();
                if (entree != value)
                {
                    if (entree != null) entree.PropertyChanged -= OnItemChanged;
                    entree = value;
                    entree.PropertyChanged += OnItemChanged;
                    OnItemChanged(null, null);
                }
            }
        }


        /// <summary>
        /// The side associated with this combo
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Cannot set <see cref="Side"/> to <c>null</c>
        /// </exception>
        public Side Side
        {
            get => side;
            set {
                if (value == null) throw new InvalidOperationException();
                if (side != value)
                {
                    if (side != null) side.PropertyChanged -= OnItemChanged;
                    side = value;
                    side.PropertyChanged += OnItemChanged;
                    OnItemChanged(null, null);
                }
            }
        }

        /// <summary>
        /// Event handler that is invoked whenever the drink, side, or entree changes.
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="e">Details about the event</param>
        private void OnItemChanged(object sender, PropertyChangedEventArgs e)
        {
            // Better safe than sorry.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Drink)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Entree)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Side)));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Calories)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
        }

        /// <summary>
        /// Creates a combo
        /// </summary>
        /// <param name="drink">a drink</param>
        /// <param name="entree">an entree</param>
        /// <param name="side">a side</param>
        public Combo(Drink drink, Entree entree, Side side)
        {
            Drink = drink;
            Entree = entree;
            Side = side;
        }
    }
}
