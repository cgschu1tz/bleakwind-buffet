/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: MadOtarGritsTests.cs
 * Purpose: Test the MadOtarGrits.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
    /// <summary>
    /// Unit tests for <see cref="MadOtarGrits"/>
    /// </summary>
    public class MadOtarGritsTests
    {
        [Fact]
        public void ShouldInvokePropertyChangedEvent()
        {
            var m = new MadOtarGrits();
            Assert.PropertyChanged(m, "Size", () => m.Size = Size.Medium);
            Assert.PropertyChanged(m, "Price", () => m.Size = Size.Medium);
            Assert.PropertyChanged(m, "Calories", () => m.Size = Size.Medium);
        }

        [Fact]
        public void ShouldInheritSide()
        {
            Assert.IsAssignableFrom<Side>(new MadOtarGrits());
        }
        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new MadOtarGrits());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new MadOtarGrits());
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            Assert.Equal(Size.Small, new MadOtarGrits().Size);
        }
                
        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            var m = new MadOtarGrits();
            m.Size = Size.Small;
            Assert.Equal(Size.Small, m.Size);
            m.Size = Size.Medium;
            Assert.Equal(Size.Medium, m.Size);
            m.Size = Size.Large;
            Assert.Equal(Size.Large, m.Size);
        }

        [Fact]
        public void ShouldReturnCorrectStringOnSpecialInstructions()
        {
            var m = new MadOtarGrits();
            Assert.Empty(m.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, 1.22)]
        [InlineData(Size.Medium, 1.58)]
        [InlineData(Size.Large, 1.93)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
            var m = new MadOtarGrits();
            m.Size = size;
            Assert.Equal(price, m.Price);
        }

        [Theory]
        [InlineData(Size.Small, 105)]
        [InlineData(Size.Medium, 142)]
        [InlineData(Size.Large, 179)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint calories)
        {
            var m = new MadOtarGrits();
            m.Size = size;
            Assert.Equal(calories, m.Calories);
        }

        [Theory]
        [InlineData(Size.Small, "Small Mad Otar Grits")]
        [InlineData(Size.Medium, "Medium Mad Otar Grits")]
        [InlineData(Size.Large, "Large Mad Otar Grits")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            var m = new MadOtarGrits();
            m.Size = size;
            Assert.Equal(name, m.Name);
        }
    }
}