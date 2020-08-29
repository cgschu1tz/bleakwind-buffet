// Author: Chris Schultz
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// Cajun fries
    /// </summary>
    public class DragonbornWaffleFries
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 0.42;
                    case Size.Medium: return 0.76;
                    case Size.Large: return 0.96;
                    default: throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public uint Calories
        {
            get {
                switch (Size)
                {
                    case Size.Small: return 77;
                    case Size.Medium: return 89;
                    case Size.Large: return 100;
                    default: throw new NotImplementedException();
                }
            }
        }

        /// <summary>
        /// The size of this item.
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <returns>A string containing the name of this item.</returns>
        public override string ToString() => $"{Size} Dragonborn Waffle Fries";
    }
}
