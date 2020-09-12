/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: VokunSaladTests.cs
 * Purpose: Test the VokunSalad.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
    /// <summary>
    /// Unit tests for <see cref="VokunSalad"/>
    /// </summary>
    public class VokunSaladTests
    {
        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new VokunSalad());
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var v = new VokunSalad();
            Assert.Equal(Size.Small, v.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var v = new VokunSalad();
            v.Size = Size.Small;
            Assert.Equal(Size.Small, v.Size);
            v.Size = Size.Medium;
            Assert.Equal(Size.Medium, v.Size);
            v.Size = Size.Large;
            Assert.Equal(Size.Large, v.Size);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            Assert.Empty(new VokunSalad().SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, 0.93)]
        [InlineData(Size.Medium, 1.28)]
        [InlineData(Size.Large, 1.82)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
            var v = new VokunSalad();
            v.Size = size;
            Assert.Equal(price, v.Price);
        }

        [Theory]
        [InlineData(Size.Small, 41)]
        [InlineData(Size.Medium, 52)]
        [InlineData(Size.Large, 73)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint calories)
        {
            var v = new VokunSalad();
            v.Size = size;
            Assert.Equal(calories, v.Calories);
        }

        [Theory]
        [InlineData(Size.Small, "Small Vokun Salad")]
        [InlineData(Size.Medium, "Medium Vokun Salad")]
        [InlineData(Size.Large, "Large Vokun Salad")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var v = new VokunSalad();
            v.Size = size;
            Assert.Equal(name, v.ToString());
        }
    }
}