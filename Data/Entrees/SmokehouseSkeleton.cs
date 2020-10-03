/*
 * Author: Chris Schultz
 * Class name: SmokehouseSkeleton.cs
 * Purpose: Defines a class for the Smokehouse Skeleton
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// Breakfast combo
    /// </summary>
    public class SmokehouseSkeleton : Entree, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Invoked when a property of this item changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override double Price => 5.62;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public override uint Calories => 602;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get {
                var instructions = new List<string>();

                if (!SausageLink) instructions.Add("Hold sausage");
                if (!Egg) instructions.Add("Hold eggs");
                if (!HashBrowns) instructions.Add("Hold hash browns");
                if (!Pancake) instructions.Add("Hold pancakes");

                return instructions;
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool sausageLink = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool SausageLink
        {
            get => sausageLink;
            set {
                sausageLink = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SausageLink)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool egg = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Egg
        {
            get => egg;
            set {
                egg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Egg)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool hashBrowns = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool HashBrowns
        {
            get => hashBrowns;
            set {
                hashBrowns = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HashBrowns)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
            }
        }

        /// <summary>
        /// A backing variable for an ingredient.
        /// </summary>
        private bool pancake = true;

        /// <summary>
        /// <c>true</c> if this ingredient is to be included and <c>false</c> if it is to be excluded.
        /// </summary>
        public bool Pancake
        {
            get => pancake;
            set {
                pancake = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pancake)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecialInstructions)));
            }
        }

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Smokehouse Skeleton";
    }
}
