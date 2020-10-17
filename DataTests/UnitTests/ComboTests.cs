/*
 * Author: Chris Schultz
 * Class: ComboTests.cs
 * Purpose: Test the Combo.cs class in the Data library
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
using System.ComponentModel;
using BleakwindBuffet.Data.Sides;

namespace BleakwindBuffet.DataTests.UnitTests
{
    /// <summary>
    /// Unit tests for <see cref="Combo"/>
    /// </summary>
    public class ComboTests
    {
        [Fact]
        public void ShouldImplementIOrderItem()
        {
            var d = new MockDrink();
            var e = new MockEntree();
            var s = new MockSide();
            var c = new Combo(d, e, s);

            Assert.IsAssignableFrom<IOrderItem>(c);
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            var d = new MockDrink();
            var e = new MockEntree();
            var s = new MockSide();
            var c = new Combo(d, e, s);

            Assert.IsAssignableFrom<INotifyPropertyChanged>(c);
        }

        [Fact]
        public void AddingDrinkShouldRaisePropertyChanged()
        {
            var d = new MockDrink();
            var e = new MockEntree();
            var s = new MockSide();
            var c = new Combo(d, e, s);

            Assert.PropertyChanged(c, "Drink", () => c.Drink = new MockDrink());
            Assert.PropertyChanged(c, "Price", () => c.Drink = new MockDrink());
            Assert.PropertyChanged(c, "Calories", () => c.Drink = new MockDrink());
            Assert.PropertyChanged(c, "SpecialInstructions", () => c.Drink = new MockDrink());
        }

        [Fact]
        public void AddingSideShouldRaisePropertyChanged()
        {
            var d = new MockDrink();
            var e = new MockEntree();
            var s = new MockSide();
            var c = new Combo(d, e, s);

            Assert.PropertyChanged(c, "Side", () => c.Side = new MockSide());
            Assert.PropertyChanged(c, "Price", () => c.Side = new MockSide());
            Assert.PropertyChanged(c, "Calories", () => c.Side = new MockSide());
            Assert.PropertyChanged(c, "SpecialInstructions", () => c.Side = new MockSide());
        }

        [Fact]
        public void AddingEntreeShouldRaisePropertyChanged()
        {
            var d = new MockDrink();
            var e = new MockEntree();
            var s = new MockSide();
            var c = new Combo(d, e, s);

            Assert.PropertyChanged(c, "Entree", () => c.Entree = new MockEntree());
            Assert.PropertyChanged(c, "Price", () => c.Entree = new MockEntree());
            Assert.PropertyChanged(c, "Calories", () => c.Entree = new MockEntree());
            Assert.PropertyChanged(c, "SpecialInstructions", () => c.Entree = new MockEntree());
        }

        [Fact]
        public void ChangingItemPriceShouldChangeComboPrice()
        {
            var d = new MockDrink();
            var e = new MockEntree();
            var s = new MockSide();
            var c = new Combo(d, e, s);

            Assert.PropertyChanged(c, "Price", () => s.ChangeProperty("Price"));
            Assert.PropertyChanged(c, "Price", () => d.ChangeProperty("Price"));
            Assert.PropertyChanged(c, "Price", () => e.ChangeProperty("Price"));
        }

        [Fact]
        public void ChangingItemCaloriesShouldChangeComboCalories()
        {
            var d = new MockDrink();
            var e = new MockEntree();
            var s = new MockSide();
            var c = new Combo(d, e, s);

            Assert.PropertyChanged(c, "Calories", () => s.ChangeProperty("Calories"));
            Assert.PropertyChanged(c, "Calories", () => d.ChangeProperty("Calories"));
            Assert.PropertyChanged(c, "Calories", () => e.ChangeProperty("Calories"));
        }

        [Fact]
        public void ChangingItemSpecialInstructionsShouldChangeComboSpecialInstructions()
        {
            var d = new MockDrink();
            var e = new MockEntree();
            var s = new MockSide();
            var c = new Combo(d, e, s);

            Assert.PropertyChanged(c, "SpecialInstructions", () => s.ChangeProperty("SpecialInstructions"));
            Assert.PropertyChanged(c, "SpecialInstructions", () => d.ChangeProperty("SpecialInstructions"));
            Assert.PropertyChanged(c, "SpecialInstructions", () => e.ChangeProperty("SpecialInstructions"));
        }

        [Fact]
        public void ShouldDoTheMathRight()
        {
            // I can't do a [Theory] because C# doesn't let you pass user-defined
            // objects as attribute parameters, so this is the next best thing.
            var c = new Combo(new SailorSoda() { Size = Size.Medium }, new BriarheartBurger(), new VokunSalad() { Size = Size.Small });

            Assert.Equal(6.32m + 1.74m + 0.93m - 1.00m, c.Price, 2); // Don't forget the discount
            Assert.Equal(743 + 153 + 41, (int)c.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectSpecialInstructions()
        {
            var c = new Combo(new SailorSoda() { Size = Size.Medium, Ice = false, Flavor = SodaFlavor.Lemon },
                new BriarheartBurger() { Cheese = false },
                new VokunSalad() { Size = Size.Small });

            Assert.Contains("Medium Lemon Sailor Soda", c.SpecialInstructions);
            Assert.Contains("* Hold ice", c.SpecialInstructions);

            Assert.Contains("Briarheart Burger", c.SpecialInstructions);
            Assert.Contains("* Hold cheese", c.SpecialInstructions);

            Assert.Contains("Small Vokun Salad", c.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectName()
        {
            Assert.Equal("Combo", new Combo(new SailorSoda() { Size = Size.Medium }, new BriarheartBurger(), new VokunSalad() { Size = Size.Small }).Name);
        }
    }
}
