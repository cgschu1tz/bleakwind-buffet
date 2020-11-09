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
        [Theory]
        [InlineData("", new[] {
            "Briarheart Burger",
            "Double Draugr",
            "Thalmor Triple",
            "Smokehouse Skeleton",
            "Garden Orc Omelette",
            "Philly Poacher",
            "Thugs T-Bone",

            "Small Blackberry Sailor Soda",
            "Small Cherry Sailor Soda",
            "Small Grapefruit Sailor Soda",
            "Small Lemon Sailor Soda",
            "Small Peach Sailor Soda",
            "Small Watermelon Sailor Soda",

            "Medium Blackberry Sailor Soda",
            "Medium Cherry Sailor Soda",
            "Medium Grapefruit Sailor Soda",
            "Medium Lemon Sailor Soda",
            "Medium Peach Sailor Soda",
            "Medium Watermelon Sailor Soda",

            "Large Blackberry Sailor Soda",
            "Large Cherry Sailor Soda",
            "Large Grapefruit Sailor Soda",
            "Large Lemon Sailor Soda",
            "Large Peach Sailor Soda",
            "Large Watermelon Sailor Soda",

            "Small Markarth Milk",
            "Medium Markarth Milk",
            "Large Markarth Milk",

            "Small Aretino Apple Juice",
            "Medium Aretino Apple Juice",
            "Large Aretino Apple Juice",

            "Small Candlehearth Coffee",
            "Medium Candlehearth Coffee",
            "Large Candlehearth Coffee",

            "Small Decaf Candlehearth Coffee",
            "Medium Decaf Candlehearth Coffee",
            "Large Decaf Candlehearth Coffee",

            "Small Warrior Water",
            "Medium Warrior Water",
            "Large Warrior Water",

            "Small Vokun Salad",
            "Medium Vokun Salad",
            "Large Vokun Salad",

            "Small Fried Miraak",
            "Medium Fried Miraak",
            "Large Fried Miraak",

            "Small Mad Otar Grits",
            "Medium Mad Otar Grits",
            "Large Mad Otar Grits",

            "Small Dragonborn Waffle Fries",
            "Medium Dragonborn Waffle Fries",
            "Large Dragonborn Waffle Fries",})]
        [InlineData(null, new[] {
            "Briarheart Burger",
            "Double Draugr",
            "Thalmor Triple",
            "Smokehouse Skeleton",
            "Garden Orc Omelette",
            "Philly Poacher",
            "Thugs T-Bone",

            "Small Blackberry Sailor Soda",
            "Small Cherry Sailor Soda",
            "Small Grapefruit Sailor Soda",
            "Small Lemon Sailor Soda",
            "Small Peach Sailor Soda",
            "Small Watermelon Sailor Soda",

            "Medium Blackberry Sailor Soda",
            "Medium Cherry Sailor Soda",
            "Medium Grapefruit Sailor Soda",
            "Medium Lemon Sailor Soda",
            "Medium Peach Sailor Soda",
            "Medium Watermelon Sailor Soda",

            "Large Blackberry Sailor Soda",
            "Large Cherry Sailor Soda",
            "Large Grapefruit Sailor Soda",
            "Large Lemon Sailor Soda",
            "Large Peach Sailor Soda",
            "Large Watermelon Sailor Soda",

            "Small Markarth Milk",
            "Medium Markarth Milk",
            "Large Markarth Milk",

            "Small Aretino Apple Juice",
            "Medium Aretino Apple Juice",
            "Large Aretino Apple Juice",

            "Small Candlehearth Coffee",
            "Medium Candlehearth Coffee",
            "Large Candlehearth Coffee",

            "Small Decaf Candlehearth Coffee",
            "Medium Decaf Candlehearth Coffee",
            "Large Decaf Candlehearth Coffee",

            "Small Warrior Water",
            "Medium Warrior Water",
            "Large Warrior Water",

            "Small Vokun Salad",
            "Medium Vokun Salad",
            "Large Vokun Salad",

            "Small Fried Miraak",
            "Medium Fried Miraak",
            "Large Fried Miraak",

            "Small Mad Otar Grits",
            "Medium Mad Otar Grits",
            "Large Mad Otar Grits",

            "Small Dragonborn Waffle Fries",
            "Medium Dragonborn Waffle Fries",
            "Large Dragonborn Waffle Fries",})]
        [InlineData("Triple", new[] { "Thalmor Triple" })]
        [InlineData("TriPlE", new[] { "Thalmor Triple" })]  // case insensitivity
        [InlineData("Drag", new[] { "Small Dragonborn Waffle Fries", "Medium Dragonborn Waffle Fries", "Large Dragonborn Waffle Fries" })]
        public void ShouldSearchByTerms(string searchTerms, string[] filteredItemNames)
        {
            var filteredItems = Menu.Search(Menu.FullMenu(), searchTerms);
            Assert.Equal(filteredItemNames.Length, filteredItems.Count());
            foreach (var name in filteredItemNames)
            {
                Assert.Contains(filteredItems, item => item.Name == name);
            }
        }

        [Fact]
        public void ShouldFilterByCategory()
        {
            IEnumerable<IOrderItem> items;

            items = Menu.FilterByCategory(Menu.FullMenu(), new[] { "Entree" });
            Assert.Equal(Menu.Entrees().Count(), items.Count());
            foreach (var item in items)
            {
                Assert.Contains(Menu.Entrees(), i => i.Name == item.Name);
            }

            items = Menu.FilterByCategory(Menu.FullMenu(), new[] { "Side" });
            Assert.Equal(Menu.Sides().Count(), items.Count());
            foreach (var item in items)
            {
                Assert.Contains(Menu.Sides(), i => i.Name == item.Name);
            }

            items = Menu.FilterByCategory(Menu.FullMenu(), new[] { "Drink" });
            Assert.Equal(Menu.Drinks().Count(), items.Count());
            foreach (var item in items)
            {
                Assert.Contains(Menu.Drinks(), i => i.Name == item.Name);
            }

            items = Menu.FilterByCategory(Menu.FullMenu(), new string[] { });
            Assert.Equal(Menu.FullMenu().Count(), items.Count());
            foreach (var item in items)
            {
                Assert.Contains(Menu.FullMenu(), i => i.Name == item.Name);
            }
        }

        [Theory]
        [InlineData(null, null, new[] {
            "Briarheart Burger",
            "Double Draugr",
            "Thalmor Triple",
            "Smokehouse Skeleton",
            "Garden Orc Omelette",
            "Philly Poacher",
            "Thugs T-Bone",

            "Small Blackberry Sailor Soda",
            "Small Cherry Sailor Soda",
            "Small Grapefruit Sailor Soda",
            "Small Lemon Sailor Soda",
            "Small Peach Sailor Soda",
            "Small Watermelon Sailor Soda",

            "Medium Blackberry Sailor Soda",
            "Medium Cherry Sailor Soda",
            "Medium Grapefruit Sailor Soda",
            "Medium Lemon Sailor Soda",
            "Medium Peach Sailor Soda",
            "Medium Watermelon Sailor Soda",

            "Large Blackberry Sailor Soda",
            "Large Cherry Sailor Soda",
            "Large Grapefruit Sailor Soda",
            "Large Lemon Sailor Soda",
            "Large Peach Sailor Soda",
            "Large Watermelon Sailor Soda",

            "Small Markarth Milk",
            "Medium Markarth Milk",
            "Large Markarth Milk",

            "Small Aretino Apple Juice",
            "Medium Aretino Apple Juice",
            "Large Aretino Apple Juice",

            "Small Candlehearth Coffee",
            "Medium Candlehearth Coffee",
            "Large Candlehearth Coffee",

            "Small Decaf Candlehearth Coffee",
            "Medium Decaf Candlehearth Coffee",
            "Large Decaf Candlehearth Coffee",

            "Small Warrior Water",
            "Medium Warrior Water",
            "Large Warrior Water",

            "Small Vokun Salad",
            "Medium Vokun Salad",
            "Large Vokun Salad",

            "Small Fried Miraak",
            "Medium Fried Miraak",
            "Large Fried Miraak",

            "Small Mad Otar Grits",
            "Medium Mad Otar Grits",
            "Large Mad Otar Grits",

            "Small Dragonborn Waffle Fries",
            "Medium Dragonborn Waffle Fries",
            "Large Dragonborn Waffle Fries",})]
        [InlineData(null, 0.00, new[] { "Small Warrior Water", "Medium Warrior Water", "Large Warrior Water" })]
        [InlineData(8.32, null, new[] { "Thalmor Triple" })]
        [InlineData(0.00, 0.00, new[] { "Small Warrior Water", "Medium Warrior Water", "Large Warrior Water" })]
        public void ShouldFilterByPrice(double? min, double? max, string[] filteredItemNames)
        {
            var filteredItems = Menu.FilterByPrice(Menu.FullMenu(), (decimal?)min, (decimal?)max);
            Assert.Equal(filteredItemNames.Length, filteredItems.Count());
            foreach (var name in filteredItemNames)
            {
                Assert.Contains(filteredItems, item => item.Name == name);
            }
        }

        [Theory]
        [InlineData(null, null, new[] {
            "Briarheart Burger",
            "Double Draugr",
            "Thalmor Triple",
            "Smokehouse Skeleton",
            "Garden Orc Omelette",
            "Philly Poacher",
            "Thugs T-Bone",

            "Small Blackberry Sailor Soda",
            "Small Cherry Sailor Soda",
            "Small Grapefruit Sailor Soda",
            "Small Lemon Sailor Soda",
            "Small Peach Sailor Soda",
            "Small Watermelon Sailor Soda",

            "Medium Blackberry Sailor Soda",
            "Medium Cherry Sailor Soda",
            "Medium Grapefruit Sailor Soda",
            "Medium Lemon Sailor Soda",
            "Medium Peach Sailor Soda",
            "Medium Watermelon Sailor Soda",

            "Large Blackberry Sailor Soda",
            "Large Cherry Sailor Soda",
            "Large Grapefruit Sailor Soda",
            "Large Lemon Sailor Soda",
            "Large Peach Sailor Soda",
            "Large Watermelon Sailor Soda",

            "Small Markarth Milk",
            "Medium Markarth Milk",
            "Large Markarth Milk",

            "Small Aretino Apple Juice",
            "Medium Aretino Apple Juice",
            "Large Aretino Apple Juice",

            "Small Candlehearth Coffee",
            "Medium Candlehearth Coffee",
            "Large Candlehearth Coffee",

            "Small Decaf Candlehearth Coffee",
            "Medium Decaf Candlehearth Coffee",
            "Large Decaf Candlehearth Coffee",

            "Small Warrior Water",
            "Medium Warrior Water",
            "Large Warrior Water",

            "Small Vokun Salad",
            "Medium Vokun Salad",
            "Large Vokun Salad",

            "Small Fried Miraak",
            "Medium Fried Miraak",
            "Large Fried Miraak",

            "Small Mad Otar Grits",
            "Medium Mad Otar Grits",
            "Large Mad Otar Grits",

            "Small Dragonborn Waffle Fries",
            "Medium Dragonborn Waffle Fries",
            "Large Dragonborn Waffle Fries",})]
        [InlineData(null, (uint)0, new[] { "Small Warrior Water", "Medium Warrior Water", "Large Warrior Water" })]
        [InlineData((uint)982, null, new[] { "Thugs T-Bone" })]
        [InlineData((uint)0, (uint)0, new[] { "Small Warrior Water", "Medium Warrior Water", "Large Warrior Water" })]
        public void ShouldFilterByCalories(uint? min, uint? max, string[] filteredItemNames)
        {
            var filteredItems = Menu.FilterByCalories(Menu.FullMenu(), min, max);
            Assert.Equal(filteredItemNames.Length, filteredItems.Count());
            foreach (var name in filteredItemNames)
            {
                Assert.Contains(filteredItems, item => item.Name == name);
            }
        }

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

            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Blackberry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Cherry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Grapefruit Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Lemon Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Peach Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Watermelon Sailor Soda");

            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Blackberry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Cherry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Grapefruit Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Lemon Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Peach Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Watermelon Sailor Soda");

            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Blackberry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Cherry Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Grapefruit Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Lemon Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Peach Sailor Soda");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Watermelon Sailor Soda");

            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Markarth Milk");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Markarth Milk");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Markarth Milk");

            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Aretino Apple Juice");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Aretino Apple Juice");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Aretino Apple Juice");

            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Candlehearth Coffee");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Candlehearth Coffee");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Candlehearth Coffee");

            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Decaf Candlehearth Coffee");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Decaf Candlehearth Coffee");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Decaf Candlehearth Coffee");

            Assert.Contains(Menu.Drinks(), item => item.Name == "Small Warrior Water");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Medium Warrior Water");
            Assert.Contains(Menu.Drinks(), item => item.Name == "Large Warrior Water");
        }

        [Fact]
        public void ShouldReturnAllSides()
        {
            Assert.Equal(numSides, Menu.Sides().Count());

            Assert.Contains(Menu.Sides(), item => item.Name == "Small Vokun Salad");
            Assert.Contains(Menu.Sides(), item => item.Name == "Medium Vokun Salad");
            Assert.Contains(Menu.Sides(), item => item.Name == "Large Vokun Salad");

            Assert.Contains(Menu.Sides(), item => item.Name == "Small Fried Miraak");
            Assert.Contains(Menu.Sides(), item => item.Name == "Medium Fried Miraak");
            Assert.Contains(Menu.Sides(), item => item.Name == "Large Fried Miraak");

            Assert.Contains(Menu.Sides(), item => item.Name == "Small Mad Otar Grits");
            Assert.Contains(Menu.Sides(), item => item.Name == "Medium Mad Otar Grits");
            Assert.Contains(Menu.Sides(), item => item.Name == "Large Mad Otar Grits");

            Assert.Contains(Menu.Sides(), item => item.Name == "Small Dragonborn Waffle Fries");
            Assert.Contains(Menu.Sides(), item => item.Name == "Medium Dragonborn Waffle Fries");
            Assert.Contains(Menu.Sides(), item => item.Name == "Large Dragonborn Waffle Fries");
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

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Blackberry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Cherry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Grapefruit Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Lemon Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Peach Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Watermelon Sailor Soda");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Blackberry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Cherry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Grapefruit Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Lemon Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Peach Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Watermelon Sailor Soda");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Blackberry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Cherry Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Grapefruit Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Lemon Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Peach Sailor Soda");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Watermelon Sailor Soda");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Markarth Milk");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Markarth Milk");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Markarth Milk");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Aretino Apple Juice");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Aretino Apple Juice");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Aretino Apple Juice");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Candlehearth Coffee");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Candlehearth Coffee");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Candlehearth Coffee");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Decaf Candlehearth Coffee");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Decaf Candlehearth Coffee");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Decaf Candlehearth Coffee");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Warrior Water");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Warrior Water");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Warrior Water");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Vokun Salad");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Vokun Salad");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Vokun Salad");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Fried Miraak");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Fried Miraak");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Fried Miraak");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Mad Otar Grits");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Mad Otar Grits");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Mad Otar Grits");

            Assert.Contains(Menu.FullMenu(), item => item.Name == "Small Dragonborn Waffle Fries");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Medium Dragonborn Waffle Fries");
            Assert.Contains(Menu.FullMenu(), item => item.Name == "Large Dragonborn Waffle Fries");
        }
    }
}
