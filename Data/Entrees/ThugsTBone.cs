/*
 * Author: Chris Schultz
 * Class name: ThugsTBone.cs
 * Purpose: Defines a class for the Thug's T-Bone
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// T-Bone steak
    /// </summary>
    public class ThugsTBone : Entree, IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// A brief description of this item.
        /// </summary>
        public string Description => "Juicy T-Bone, not much else to say.";

        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override decimal Price => 6.44m;

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public override uint Calories => 982;

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public override List<string> SpecialInstructions => new List<string>();

        /// <summary>
        /// Converts this item to its string representation.
        /// </summary>
        /// <returns>A string containing the name of the item.</returns>
        public override string ToString() => "Thugs T-Bone";
    }
}
