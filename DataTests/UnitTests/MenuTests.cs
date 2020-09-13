/*
 * Author: Chris Schultz
 * Class: MenuTests.cs
 * Purpose: Test the Menu.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data;
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Entrees;
using System.Linq;

namespace BleakwindBuffet.DataTests.UnitTests
{
    /// <summary>
    /// Unit tests for <see cref="Menu"/>
    /// </summary>
    public class MenuTests
    {
        /// <summary>
        /// The number of drinks on the menu (3 ordinary drinks,
        /// plus 6 flavors of Sailor Soda,
        /// plus caffeinated and decaffeinated Candlehearth Coffee,
        /// all in 3 sizes)
        /// </summary>
        private readonly int numDrinks = (3 + 6 + 2) * 3;

        /// <summary>
        /// The number of entrees on the menu
        /// </summary>
        private readonly int numEntrees = 7;

        /// <summary>
        /// The number of sides on the menu
        /// </summary>
        private readonly int numSides = 3 * 4;

        [Fact]
        public void ShouldReturnAllEntrees()
        {
            Assert.Equal(numEntrees, Menu.Entrees().Count());

            Assert.Contains(Menu.Entrees(), item => item is BriarheartBurger);
            Assert.Contains(Menu.Entrees(), item => item is DoubleDraugr);
            Assert.Contains(Menu.Entrees(), item => item is ThalmorTriple);
            Assert.Contains(Menu.Entrees(), item => item is SmokehouseSkeleton);
            Assert.Contains(Menu.Entrees(), item => item is GardenOrcOmelette);
            Assert.Contains(Menu.Entrees(), item => item is PhillyPoacher);
            Assert.Contains(Menu.Entrees(), item => item is ThugsTBone);
        }

        [Fact]
        public void ShouldReturnAllDrinks()
        {
            Assert.Equal(numDrinks, Menu.Drinks().Count());

            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Blackberry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Cherry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Grapefruit Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Lemon Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Peach Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Watermelon Sailor Soda");

            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Blackberry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Cherry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Grapefruit Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Lemon Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Peach Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Watermelon Sailor Soda");

            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Blackberry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Cherry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Grapefruit Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Lemon Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Peach Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Watermelon Sailor Soda");

            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Markarth Milk");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Markarth Milk");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Markarth Milk");

            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Aretino Apple Juice");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Aretino Apple Juice");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Aretino Apple Juice");

            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Candlehearth Coffee");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Candlehearth Coffee");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Candlehearth Coffee");

            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Decaf Candlehearth Coffee");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Decaf Candlehearth Coffee");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Decaf Candlehearth Coffee");

            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Small Warrior Water");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Medium Warrior Water");
            Assert.Contains(Menu.Drinks(), item => item.ToString() == "Large Warrior Water");
        }

        [Fact]
        public void ShouldReturnAllSides()
        {
            Assert.Equal(numSides, Menu.Sides().Count());

            Assert.Contains(Menu.Sides(), item => item.ToString() == "Small Vokun Salad");
            Assert.Contains(Menu.Sides(), item => item.ToString() == "Medium Vokun Salad");
            Assert.Contains(Menu.Sides(), item => item.ToString() == "Large Vokun Salad");

            Assert.Contains(Menu.Sides(), item => item.ToString() == "Small Fried Miraak");
            Assert.Contains(Menu.Sides(), item => item.ToString() == "Medium Fried Miraak");
            Assert.Contains(Menu.Sides(), item => item.ToString() == "Large Fried Miraak");

            Assert.Contains(Menu.Sides(), item => item.ToString() == "Small Mad Otar Grits");
            Assert.Contains(Menu.Sides(), item => item.ToString() == "Medium Mad Otar Grits");
            Assert.Contains(Menu.Sides(), item => item.ToString() == "Large Mad Otar Grits");

            Assert.Contains(Menu.Sides(), item => item.ToString() == "Small Dragonborn Waffle Fries");
            Assert.Contains(Menu.Sides(), item => item.ToString() == "Medium Dragonborn Waffle Fries");
            Assert.Contains(Menu.Sides(), item => item.ToString() == "Large Dragonborn Waffle Fries");
        }

        [Fact]
        public void ShouldReturnAllMenuItems()
        {
            Assert.Equal(numEntrees + numDrinks + numSides, Menu.FullMenu().Count());

            Assert.Contains(Menu.FullMenu(), item => item is BriarheartBurger);
            Assert.Contains(Menu.FullMenu(), item => item is DoubleDraugr);
            Assert.Contains(Menu.FullMenu(), item => item is ThalmorTriple);
            Assert.Contains(Menu.FullMenu(), item => item is SmokehouseSkeleton);
            Assert.Contains(Menu.FullMenu(), item => item is GardenOrcOmelette);
            Assert.Contains(Menu.FullMenu(), item => item is PhillyPoacher);
            Assert.Contains(Menu.FullMenu(), item => item is ThugsTBone);

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Blackberry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Cherry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Grapefruit Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Lemon Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Peach Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Watermelon Sailor Soda");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Blackberry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Cherry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Grapefruit Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Lemon Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Peach Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Watermelon Sailor Soda");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Blackberry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Cherry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Grapefruit Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Lemon Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Peach Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Watermelon Sailor Soda");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Markarth Milk");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Markarth Milk");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Markarth Milk");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Aretino Apple Juice");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Aretino Apple Juice");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Aretino Apple Juice");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Candlehearth Coffee");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Candlehearth Coffee");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Candlehearth Coffee");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Decaf Candlehearth Coffee");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Decaf Candlehearth Coffee");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Decaf Candlehearth Coffee");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Warrior Water");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Warrior Water");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Warrior Water");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Vokun Salad");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Vokun Salad");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Vokun Salad");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Fried Miraak");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Fried Miraak");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Fried Miraak");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Mad Otar Grits");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Mad Otar Grits");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Mad Otar Grits");

            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Small Dragonborn Waffle Fries");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Medium Dragonborn Waffle Fries");
            Assert.Contains(Menu.FullMenu(), item => item.ToString() == "Large Dragonborn Waffle Fries");
        }
    }
}
