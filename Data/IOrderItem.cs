/*
 * Author: Chris Schultz
 * Class name: IOrderItem.cs
 * Purpose: Defines an interface for all the menu items
 */
using System.Collections.Generic;

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// Interface that all entrees, drinks, and sides must implement
    /// </summary>
    public interface IOrderItem
    {
        /// <summary>
        /// The price of the item in USD.
        /// </summary>
        double Price { get; }

        /// <summary>
        /// How many calories the item contains.
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// A list of instructions to follow when preparing the item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        List<string> SpecialInstructions { get; }

        /// <summary>
        /// The name of the item.
        /// </summary>
        string Name { get; }
    }
}
