/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: SailorSodaTests.cs
 * Purpose: Test the SailorSoda.cs class in the Data library
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using Xunit;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    /// <summary>
    /// Unit tests for <see cref="SailorSoda"/>
    /// </summary>
    public class SailorSodaTests
    {
        [Fact]
        public void ImplementsIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new SailorSoda());
        }

        [Fact]
        public void ShouldIncludeIceByDefault()
        {
            var s = new SailorSoda();
            Assert.True(s.Ice);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var s = new SailorSoda();
            Assert.Equal(Size.Small, s.Size);
        }

        [Fact]
        public void FlavorShouldBeCherryByDefault()
        {
            var s = new SailorSoda();
            Assert.Equal(SodaFlavor.Cherry, s.Flavor);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var s = new SailorSoda();
            s.Ice = false;
            Assert.False(s.Ice);
            s.Ice = true;
            Assert.True(s.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var s = new SailorSoda();
            s.Size = Size.Small;
            Assert.Equal(Size.Small, s.Size);
            s.Size = Size.Medium;
            Assert.Equal(Size.Medium, s.Size);
            s.Size = Size.Large;
            Assert.Equal(Size.Large, s.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetFlavor()
        {
            var s = new SailorSoda();
            s.Flavor = SodaFlavor.Blackberry;
            Assert.Equal(SodaFlavor.Blackberry, s.Flavor);
            s.Flavor = SodaFlavor.Cherry;
            Assert.Equal(SodaFlavor.Cherry, s.Flavor);
            s.Flavor = SodaFlavor.Grapefruit;
            Assert.Equal(SodaFlavor.Grapefruit, s.Flavor);
            s.Flavor = SodaFlavor.Lemon;
            Assert.Equal(SodaFlavor.Lemon, s.Flavor);
            s.Flavor = SodaFlavor.Peach;
            Assert.Equal(SodaFlavor.Peach, s.Flavor);
            s.Flavor = SodaFlavor.Watermelon;
            Assert.Equal(SodaFlavor.Watermelon, s.Flavor);
        }

        [Theory]
        [InlineData(Size.Small, 1.42)]
        [InlineData(Size.Medium, 1.74)]
        [InlineData(Size.Large, 2.07)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            var s = new SailorSoda();
            s.Size = size;
            Assert.Equal(price, s.Price);
        }

        [Theory]
        [InlineData(Size.Small, 117)]
        [InlineData(Size.Medium, 153)]
        [InlineData(Size.Large, 205)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            var s = new SailorSoda();
            s.Size = size;
            Assert.Equal(cal, s.Calories);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce)
        {
            var s = new SailorSoda();
            s.Ice = includeIce;
            
            if (!includeIce) Assert.Contains("Hold ice", s.SpecialInstructions);

            if (includeIce) Assert.Empty(s.SpecialInstructions);
        }
        
        [Theory]
        [InlineData(SodaFlavor.Cherry, Size.Small, "Small Cherry Sailor Soda")]
        [InlineData(SodaFlavor.Cherry, Size.Medium, "Medium Cherry Sailor Soda")]
        [InlineData(SodaFlavor.Cherry, Size.Large, "Large Cherry Sailor Soda")]

        [InlineData(SodaFlavor.Blackberry, Size.Small, "Small Blackberry Sailor Soda")]
        [InlineData(SodaFlavor.Blackberry, Size.Medium, "Medium Blackberry Sailor Soda")]
        [InlineData(SodaFlavor.Blackberry, Size.Large, "Large Blackberry Sailor Soda")]

        [InlineData(SodaFlavor.Grapefruit, Size.Small, "Small Grapefruit Sailor Soda")]
        [InlineData(SodaFlavor.Grapefruit, Size.Medium, "Medium Grapefruit Sailor Soda")]
        [InlineData(SodaFlavor.Grapefruit, Size.Large, "Large Grapefruit Sailor Soda")]

        [InlineData(SodaFlavor.Lemon, Size.Small, "Small Lemon Sailor Soda")]
        [InlineData(SodaFlavor.Lemon, Size.Medium, "Medium Lemon Sailor Soda")]
        [InlineData(SodaFlavor.Lemon, Size.Large, "Large Lemon Sailor Soda")]

        [InlineData(SodaFlavor.Peach, Size.Small, "Small Peach Sailor Soda")]
        [InlineData(SodaFlavor.Peach, Size.Medium, "Medium Peach Sailor Soda")]
        [InlineData(SodaFlavor.Peach, Size.Large, "Large Peach Sailor Soda")]

        [InlineData(SodaFlavor.Watermelon, Size.Small, "Small Watermelon Sailor Soda")]
        [InlineData(SodaFlavor.Watermelon, Size.Medium, "Medium Watermelon Sailor Soda")]
        [InlineData(SodaFlavor.Watermelon, Size.Large, "Large Watermelon Sailor Soda")]
        public void ShouldHaveCorrectToStringBasedOnSizeAndFlavor(SodaFlavor flavor, Size size, string name)
        {
            var s = new SailorSoda();
            s.Flavor = flavor;
            s.Size = size;
            Assert.Equal(name, s.ToString());
        }
    }
}
