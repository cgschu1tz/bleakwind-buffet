/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: FriedMiraakTests.cs
 * Purpose: Test the FriedMiraak.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
    /// <summary>
    /// Unit tests for <see cref="FriedMiraak"/>
    /// </summary>
    public class FriedMiraakTests
    {
        [Fact]
        public void ShouldInvokePropertyChangedEvent()
        {
            var f = new FriedMiraak();
            Assert.PropertyChanged(f, "Size", () => f.Size = Size.Medium);
            Assert.PropertyChanged(f, "Price", () => f.Size = Size.Medium);
            Assert.PropertyChanged(f, "Calories", () => f.Size = Size.Medium);
        }

        [Fact]
        public void ShouldInheritSide()
        {
            Assert.IsAssignableFrom<Side>(new FriedMiraak());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new FriedMiraak());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new FriedMiraak());
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var f = new FriedMiraak();
            Assert.Equal(Size.Small, f.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var f = new FriedMiraak();
            f.Size = Size.Small;
            Assert.Equal(Size.Small, f.Size);
            f.Size = Size.Medium;
            Assert.Equal(Size.Medium, f.Size);
            f.Size = Size.Large;
            Assert.Equal(Size.Large, f.Size);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            var f = new FriedMiraak();
            Assert.Empty(f.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, 1.78)]
        [InlineData(Size.Medium, 2.01)]
        [InlineData(Size.Large, 2.88)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
            var f = new FriedMiraak();
            f.Size = size;
            Assert.Equal(price, f.Price);
        }

        [Theory]
        [InlineData(Size.Small, 151)]
        [InlineData(Size.Medium, 236)]
        [InlineData(Size.Large, 306)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint calories)
        {
            var f = new FriedMiraak();
            f.Size = size;
            Assert.Equal(calories, f.Calories);
        }

        [Theory]
        [InlineData(Size.Small, "Small Fried Miraak")]
        [InlineData(Size.Medium, "Medium Fried Miraak")]
        [InlineData(Size.Large, "Large Fried Miraak")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var f = new FriedMiraak();
            f.Size = size;
            Assert.Equal(name, f.ToString());
        }
    }
}