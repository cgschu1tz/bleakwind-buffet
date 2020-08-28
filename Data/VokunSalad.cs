// Author: Christopher Schultz
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Sides
{
    class VokunSalad
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
                        return 0.93;
                    case Size.Medium:
                        return 1.28;
                    case Size.Large:
                        return 1.82;
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
                        return 41;
                    case Size.Medium:
                        return 52;
                    case Size.Large:
                        return 73;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public Size Size { get; } = Size.Small;

        public override string ToString() => $"{Size} Vokun Salad";
    }
}
