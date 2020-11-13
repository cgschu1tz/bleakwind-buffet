/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: DragonbornWaffleFriesTests.cs
 * Purpose: Test the DragonbornWaffleFries.cs class in the Data library
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System.ComponentModel;
using Xunit;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
    /// <summary>
    /// Unit tests for <see cref="DragonbornWaffleFries"/>
    /// </summary>
    public class DragonbornWaffleFriesTests
    {
        [Fact]
        public void ShouldHaveDescription()
        {
            Assert.Equal("Crispy fried potato waffle fries.",
                new DragonbornWaffleFries().Description);
        }

        [Fact]
        public void ShouldInvokePropertyChangedEvent()
        {
            var d = new DragonbornWaffleFries();
            Assert.PropertyChanged(d, "Size", () => d.Size = Size.Medium);
            Assert.PropertyChanged(d, "Price", () => d.Size = Size.Medium);
            Assert.PropertyChanged(d, "Calories", () => d.Size = Size.Medium);
        }

        [Fact]
        public void ShouldInheritSide()
        {
            Assert.IsAssignableFrom<Side>(new DragonbornWaffleFries());
        }
        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new DragonbornWaffleFries());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new DragonbornWaffleFries());
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var d = new DragonbornWaffleFries();
            Assert.Equal(Size.Small, d.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var d = new DragonbornWaffleFries();
            d.Size = Size.Small;
            Assert.Equal(Size.Small, d.Size);
            d.Size = Size.Medium;
            Assert.Equal(Size.Medium, d.Size);
            d.Size = Size.Large;
            Assert.Equal(Size.Large, d.Size);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            var d = new DragonbornWaffleFries();
            Assert.Empty(d.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, 0.42)]
        [InlineData(Size.Medium, 0.76)]
        [InlineData(Size.Large, 0.96)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, decimal price)
        {
            var d = new DragonbornWaffleFries();
            d.Size = size;
            Assert.Equal(price, d.Price);
        }

        [Theory]
        [InlineData(Size.Small, 77)]
        [InlineData(Size.Medium, 89)]
        [InlineData(Size.Large, 100)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint calories)
        {
            var d = new DragonbornWaffleFries();
            d.Size = size;
            Assert.Equal(calories, d.Calories);
        }

        [Theory]
        [InlineData(Size.Small, "Small Dragonborn Waffle Fries")]
        [InlineData(Size.Medium, "Medium Dragonborn Waffle Fries")]
        [InlineData(Size.Large, "Large Dragonborn Waffle Fries")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var d = new DragonbornWaffleFries();
            d.Size = size;
            Assert.Equal(name, d.Name);
        }
    }
}