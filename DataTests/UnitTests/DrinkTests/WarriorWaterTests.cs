/*
 * Author: Chris Schultz
 * Class: WarriorWaterTests.cs
 * Purpose: Test the WarriorWater class in the Data library
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System.ComponentModel;
using Xunit;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    /// <summary>
    /// Unit tests for <see cref="WarriorWater"/>
    /// </summary>
    public class WarriorWaterTests
    {
        [Fact]
        public void ShouldInheritDrink()
        {
            Assert.IsAssignableFrom<Drink>(new WarriorWater());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new WarriorWater());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new WarriorWater());
        }

        [Fact]
        public void ShouldIncludeIceByDefault()
        {
            var w = new WarriorWater();
            Assert.True(w.Ice);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var w = new WarriorWater();
            Assert.Equal(Size.Small, w.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var w = new WarriorWater();
            w.Ice = true;
            Assert.True(w.Ice);
            w.Ice = false;
            Assert.False(w.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var w = new WarriorWater();
            w.Size = Size.Small;
            Assert.Equal(Size.Small, w.Size);
            w.Size = Size.Medium;
            Assert.Equal(Size.Medium, w.Size);
            w.Size = Size.Large;
            Assert.Equal(Size.Large, w.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetLemon()
        {
            var w = new WarriorWater();
            w.Lemon = true;
            Assert.True(w.Lemon);
            w.Lemon = false;
            Assert.False(w.Lemon);
        }

        [Theory]
        [InlineData(Size.Small, 0.00)]
        [InlineData(Size.Medium, 0.00)]
        [InlineData(Size.Large, 0.00)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            var w = new WarriorWater();
            w.Size = size;
            Assert.Equal(w.Price, price);
        }

        [Theory]
        [InlineData(Size.Small, 0)]
        [InlineData(Size.Medium, 0)]
        [InlineData(Size.Large, 0)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            var w = new WarriorWater();
            w.Size = size;
            Assert.Equal(w.Calories, cal);
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce, bool includeLemon)
        {
            var w = new WarriorWater();
            w.Ice = includeIce;
            w.Lemon = includeLemon;

            if (!includeIce) Assert.Contains("Hold ice", w.SpecialInstructions);
            if (includeLemon) Assert.Contains("Add lemon", w.SpecialInstructions);

            if (includeIce && !includeLemon) Assert.Empty(w.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, "Small Warrior Water")]
        [InlineData(Size.Medium, "Medium Warrior Water")]
        [InlineData(Size.Large, "Large Warrior Water")]
        public void ShouldHaveCorrectToStringBasedOnSize(Size size, string name)
        {
            var w = new WarriorWater();
            w.Size = size;
            Assert.Equal(name, w.ToString());
        }
    }
}
