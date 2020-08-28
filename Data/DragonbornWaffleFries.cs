// Author: Christopher Schultz
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Drinks
{
    class DragonbornWaffleFries
    {
        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public double Price
        {
            get {
                switch (Size)
                {
                    case Size.Small:
                        return 0.42;
                    case Size.Medium:
                        return 0.76;
                    case Size.Large:
                        return 0.96;
                    default:
                        throw new NotImplementedException();
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
                    case Size.Small:
                        return 77;
                    case Size.Medium:
                        return 89;
                    case Size.Large:
                        return 100;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public Size Size { get; } = Size.Small;

        public override string ToString() => $"{Size} Dragonborn Waffle Fries";
    }
}
