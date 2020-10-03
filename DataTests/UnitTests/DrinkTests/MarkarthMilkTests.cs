/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: MarkarthMilkTests.cs
 * Purpose: Test the MarkarthMilk.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    /// <summary>
    /// Unit tests for <see cref="MarkarthMilk"/>
    /// </summary>
    public class MarkarthMilkTests
    {
        [Fact]
        public void ShouldInheritDrink()
        {
            Assert.IsAssignableFrom<Drink>(new MarkarthMilk());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new MarkarthMilk());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new MarkarthMilk());
        }

        [Fact]
        public void ShouldNotIncludeIceByDefault()
        {
            var m = new MarkarthMilk();
            Assert.False(m.Ice);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var m = new MarkarthMilk();
            Assert.Equal(Size.Small, m.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var m = new MarkarthMilk();
            m.Ice = true;
            Assert.True(m.Ice);
            m.Ice = false;
            Assert.False(m.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var m = new MarkarthMilk();
            m.Size = Size.Small;
            Assert.Equal(Size.Small, m.Size);
            m.Size = Size.Medium;
            Assert.Equal(Size.Medium, m.Size);
            m.Size = Size.Large;
            Assert.Equal(Size.Large, m.Size);
        }

        [Theory]
        [InlineData(Size.Small, 1.05)]
        [InlineData(Size.Medium, 1.11)]
        [InlineData(Size.Large, 1.22)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            var m = new MarkarthMilk();
            m.Size = size;
            Assert.Equal(price, m.Price);
        }

        [Theory]
        [InlineData(Size.Small, 56)]
        [InlineData(Size.Medium, 72)]
        [InlineData(Size.Large, 93)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            var m = new MarkarthMilk();
            m.Size = size;
            Assert.Equal(cal, m.Calories);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce)
        {
            var m = new MarkarthMilk();
            m.Ice = includeIce;

            if (includeIce) Assert.Contains("Add ice", m.SpecialInstructions);
            if (!includeIce) Assert.Empty(m.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, "Small Markarth Milk")]
        [InlineData(Size.Medium, "Medium Markarth Milk")]
        [InlineData(Size.Large, "Large Markarth Milk")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var m = new MarkarthMilk();
            m.Size = size;
            Assert.Equal(name, m.ToString());
        }
    }
}