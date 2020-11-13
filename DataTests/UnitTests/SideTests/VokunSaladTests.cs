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
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
    /// <summary>
    /// Unit tests for <see cref="VokunSalad"/>
    /// </summary>
    public class VokunSaladTests
    {
        [Fact]
        public void ShouldHaveDescription()
        {
            Assert.Equal("A seasonal fruit salad of melons, berries, mangoes, grapes, apples, and oranges.",
                new VokunSalad().Description);
        }

        [Fact]
        public void ShouldInvokePropertyChangedEvent()
        {
            var v = new VokunSalad();
            Assert.PropertyChanged(v, "Size", () => v.Size = Size.Medium);
            Assert.PropertyChanged(v, "Price", () => v.Size = Size.Medium);
            Assert.PropertyChanged(v, "Calories", () => v.Size = Size.Medium);
        }

        [Fact]
        public void ShouldInheritSide()
        {
            Assert.IsAssignableFrom<Side>(new VokunSalad());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new VokunSalad());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new VokunSalad());
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
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, decimal price)
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
            Assert.Equal(name, v.Name);
        }
    }
}