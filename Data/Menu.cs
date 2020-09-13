/*
 * Author: Chris Schultz
 * Class name: Menu.cs
 * Purpose: Defines a static class to list the items on the menu
 */
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System.Collections.Generic;

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// Static class that lists items on the menu
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// List of all possible sizes
        /// </summary>
        private static readonly Size[] sizes = { Size.Small, Size.Medium, Size.Large };

        /// <summary>
        /// Lists all entrees on the menu.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="IOrderItem"/> objects
        /// representing all entrees on the menu
        /// </returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            return new IOrderItem[] {
                new BriarheartBurger(),
                new DoubleDraugr(),
                new GardenOrcOmelette(),
                new PhillyPoacher(),
                new SmokehouseSkeleton(),
                new ThalmorTriple(),
                new ThugsTBone()
            };
        }

        /// <summary>
        /// Lists all sides on the menu.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="IOrderItem"/> objects
        /// representing all sides on the menu
        /// </returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            foreach (Size size in sizes) yield return new DragonbornWaffleFries() { Size = size };
            foreach (Size size in sizes) yield return new FriedMiraak() { Size = size };
            foreach (Size size in sizes) yield return new MadOtarGrits() { Size = size };
            foreach (Size size in sizes) yield return new VokunSalad() { Size = size };
        }

        /// <summary>
        /// Lists all drinks on the menu.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="IOrderItem"/> objects
        /// representing all drinks on the menu
        /// </returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            foreach (Size size in sizes) yield return new AretinoAppleJuice() { Size = size };
            foreach (Size size in sizes) yield return new MarkarthMilk() { Size = size };
            foreach (Size size in sizes) yield return new WarriorWater() { Size = size };

            foreach (Size size in sizes) yield return new CandlehearthCoffee() { Decaf = true, Size = size };
            foreach (Size size in sizes) yield return new CandlehearthCoffee() { Decaf = false, Size = size };

            var flavors = new[]
            {
                SodaFlavor.Blackberry,
                SodaFlavor.Cherry,
                SodaFlavor.Grapefruit,
                SodaFlavor.Lemon,
                SodaFlavor.Peach,
                SodaFlavor.Watermelon
            };
            foreach (Size size in sizes)
            {
                foreach (SodaFlavor flavor in flavors)
                {
                    yield return new SailorSoda() { Size = size, Flavor = flavor };
                }
            }
        }

        /// <summary>
        /// Lists all items on the menu.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="IOrderItem"/> objects
        /// representing all items on the menu
        /// </returns>
        public static IEnumerable<IOrderItem> FullMenu()
        {
            foreach (IOrderItem entree in Entrees()) yield return entree;
            foreach (IOrderItem side in Sides()) yield return side;
            foreach (IOrderItem drink in Drinks()) yield return drink;
        }
    }
}
