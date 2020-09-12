﻿/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: AretinoAppleJuiceTests.cs
 * Purpose: Test the AretinoAppleJuice.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data;

namespace BleakwindBuffet.DataTests.UnitTests.DrinkTests
{
    /// <summary>
    /// Unit tests for <see cref="AretinoAppleJuice"/>
    /// </summary>
    public class AretinoAppleJuiceTests
    {
        [Fact]
        public void ShouldInheritDrink()
        {
            Assert.IsAssignableFrom<Drink>(new AretinoAppleJuice());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new AretinoAppleJuice());
        }

        [Fact]
        public void ShouldNotIncludeIceByDefault()
        {
            var a = new AretinoAppleJuice();
            Assert.False(a.Ice);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            var a = new AretinoAppleJuice();
            Assert.Equal(Size.Small, a.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetIce()
        {
            var a = new AretinoAppleJuice();
            a.Ice = true;
            Assert.True(a.Ice);
            a.Ice = false;
            Assert.False(a.Ice);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var a = new AretinoAppleJuice();
            a.Size = Size.Small;
            Assert.Equal(Size.Small, a.Size);
            a.Size = Size.Medium;
            Assert.Equal(Size.Medium, a.Size);
            a.Size = Size.Large;
            Assert.Equal(Size.Large, a.Size);
        }

        [Theory]
        [InlineData(Size.Small, 0.62)]
        [InlineData(Size.Medium, 0.87)]
        [InlineData(Size.Large, 1.01)]
        public void ShouldHaveCorrectPriceForSize(Size size, double price)
        {
            var a = new AretinoAppleJuice();
            a.Size = size;
            Assert.Equal(price, a.Price);
        }

        [Theory]
        [InlineData(Size.Small, 44)]
        [InlineData(Size.Medium, 88)]
        [InlineData(Size.Large, 132)]
        public void ShouldHaveCorrectCaloriesForSize(Size size, uint cal)
        {
            var a = new AretinoAppleJuice();
            a.Size = size;
            Assert.Equal(cal, a.Calories);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldHaveCorrectSpecialInstructions(bool includeIce)
        {
            var a = new AretinoAppleJuice();
            a.Ice = includeIce;

            if (includeIce) Assert.Contains("Add ice", a.SpecialInstructions);
            if (!includeIce) Assert.Empty(a.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, "Small Aretino Apple Juice")]
        [InlineData(Size.Medium, "Medium Aretino Apple Juice")]
        [InlineData(Size.Large, "Large Aretino Apple Juice")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var a = new AretinoAppleJuice();
            a.Size = size;
            Assert.Equal(name, a.ToString());
        }
    }
}