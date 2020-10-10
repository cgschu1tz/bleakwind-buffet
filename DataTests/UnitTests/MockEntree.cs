/*
 * Author: Chris Schultz
 * Class name: MockEntree.cs
 * Purpose: Defines a class for mocking entrees
 */
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.DataTests.UnitTests
{
    /// <summary>
    /// A mock entree
    /// </summary>
    class MockEntree : Entree
    {
        /// <summary>
        /// Fires the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">the name of the property that changed</param>
        public void ChangeProperty(string propertyName)
        {
            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// The price of this item in USD.
        /// </summary>
        public override double Price { get; }

        /// <summary>
        /// How many calories this item contains.
        /// </summary>
        public override uint Calories { get; }

        /// <summary>
        /// A list of instructions to follow when preparing this item
        /// (e.g. "Hold mayo" or "Hold ice").
        /// </summary>
        public override List<string> SpecialInstructions { get; }
    }
}
