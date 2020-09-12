/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: CandlehearthCoffeeTests.cs
 * Purpose: Test the CandlehearthCoffee.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    /// <summary>
    /// Unit tests for <see cref="CandlehearthCoffee"/>
    /// </summary>
    public class CandlehearthCoffeeTests
    {
        [Fact]
        public void ImplementsIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new CandlehearthCoffee());
        }

        [Fact]
        public void ShouldNotIncludeIceByDefault()
        {
            var c = new CandlehearthCoffee();
            Assert.False(c.Ice);
        }

        [Fact]
        public void ShouldNotBeDecafByDefault()
        {
            var c = new CandlehearthCoffee();
            Assert.False(c.Decaf);
        }

        [Fact]
        public void ShouldNotHaveRoomForCreamByDefault()
        {
            var c = new CandlehearthCoffee();
            Assert.False(c.RoomForCream);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var c = new CandlehearthCoffee();
            Assert.Equal(Size.Small, c.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var c = new CandlehearthCoffee();
            c.Ice = true;
            Assert.True(c.Ice);
            c.Ice = false;
            Assert.False(c.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetDecaf()
        {
            var c = new CandlehearthCoffee();
            c.Decaf = true;
            Assert.True(c.Decaf);
            c.Decaf = false;
            Assert.False(c.Decaf);
        }

        [Fact]
        public void ShouldBeAbleToSetRoomForCream()
        {
            var c = new CandlehearthCoffee();
            c.RoomForCream = true;
            Assert.True(c.RoomForCream);
            c.RoomForCream = false;
            Assert.False(c.RoomForCream);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var c = new CandlehearthCoffee();
            c.Size = Size.Small;
            Assert.Equal(Size.Small, c.Size);
            c.Size = Size.Medium;
            Assert.Equal(Size.Medium, c.Size);
            c.Size = Size.Large;
            Assert.Equal(Size.Large, c.Size);
        }

        [Theory]
        [InlineData(Size.Small, 0.75)]
        [InlineData(Size.Medium, 1.25)]
        [InlineData(Size.Large, 1.75)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            var c = new CandlehearthCoffee();
            c.Size = size;
            Assert.Equal(price, c.Price);
        }

        [Theory]
        [InlineData(Size.Small, 7)]
        [InlineData(Size.Medium, 10)]
        [InlineData(Size.Large, 20)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            var c = new CandlehearthCoffee();
            c.Size = size;
            Assert.Equal(cal, c.Calories);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce, bool includeCream)
        {
            var c = new CandlehearthCoffee();
            c.RoomForCream = includeCream;
            c.Ice = includeIce;

            if (includeIce) Assert.Contains("Add ice", c.SpecialInstructions);
            if (includeCream) Assert.Contains("Add cream", c.SpecialInstructions);

            if (!includeIce && !includeCream) Assert.Empty(c.SpecialInstructions);
        }

        [Theory]
        [InlineData(true, Size.Small, "Small Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Medium, "Medium Decaf Candlehearth Coffee")]
        [InlineData(true, Size.Large, "Large Decaf Candlehearth Coffee")]
        [InlineData(false, Size.Small, "Small Candlehearth Coffee")]
        [InlineData(false, Size.Medium, "Medium Candlehearth Coffee")]
        [InlineData(false, Size.Large, "Large Candlehearth Coffee")]
        public void ShouldReturnCorrectToStringBasedOnSize(bool decaf, Size size, string name)
        {
            var c = new CandlehearthCoffee();
            c.Decaf = decaf;
            c.Size = size;
            Assert.Equal(name, c.ToString());
        }
    }
}
