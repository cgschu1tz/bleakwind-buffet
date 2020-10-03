/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: DoubleDraugrTests.cs
 * Purpose: Test the DoubleDraugr.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    /// <summary>
    /// Unit tests for <see cref="DoubleDraugr"/>
    /// </summary>
    public class DoubleDraugrTests
    {
        [Fact]
        public void ShouldInheritEntree()
        {
            Assert.IsAssignableFrom<Entree>(new DoubleDraugr());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new DoubleDraugr());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new DoubleDraugr());
        }

        [Fact]
        public void ShouldIncludeBunByDefault()
        {
            Assert.True(new DoubleDraugr().Bun);
        }

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            Assert.True(new DoubleDraugr().Ketchup);
        }

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            Assert.True(new DoubleDraugr().Mustard);
        }

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            Assert.True(new DoubleDraugr().Pickle);
        }

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            Assert.True(new DoubleDraugr().Cheese);
        }

        [Fact]
        public void ShouldIncludeTomatoByDefault()
        {
            Assert.True(new DoubleDraugr().Tomato);
        }

        [Fact]
        public void ShouldIncludeLettuceByDefault()
        {
            Assert.True(new DoubleDraugr().Lettuce);
        }

        [Fact]
        public void ShouldIncludeMayoByDefault()
        {
            Assert.True(new DoubleDraugr().Mayo);
        }

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            var d = new DoubleDraugr();
            d.Bun = false;
            Assert.False(d.Bun);
            d.Bun = true;
            Assert.True(d.Bun);
        }

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            var d = new DoubleDraugr();
            d.Ketchup = false;
            Assert.False(d.Ketchup);
            d.Ketchup = true;
            Assert.True(d.Ketchup);
        }

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            var d = new DoubleDraugr();
            d.Mustard = false;
            Assert.False(d.Mustard);
            d.Mustard = true;
            Assert.True(d.Mustard);
        }

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            var d = new DoubleDraugr();
            d.Pickle = false;
            Assert.False(d.Pickle);
            d.Pickle = true;
            Assert.True(d.Pickle);
        }

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            var d = new DoubleDraugr();
            d.Cheese = false;
            Assert.False(d.Cheese);
            d.Cheese = true;
            Assert.True(d.Cheese);
        }

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            var d = new DoubleDraugr();
            d.Tomato = false;
            Assert.False(d.Tomato);
            d.Tomato = true;
            Assert.True(d.Tomato);
        }

        [Fact]
        public void ShouldBeAbleToSetLettuce()
        {
            var d = new DoubleDraugr();
            d.Lettuce = false;
            Assert.False(d.Lettuce);
            d.Lettuce = true;
            Assert.True(d.Lettuce);
        }

        [Fact]
        public void ShouldBeAbleToSetMayo()
        {
            var d = new DoubleDraugr();
            d.Mayo = false;
            Assert.False(d.Mayo);
            d.Mayo = true;
            Assert.True(d.Mayo);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(7.32, new DoubleDraugr().Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)843, new DoubleDraugr().Calories);
        }

        [Theory]
        [InlineData(true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese, bool includeTomato,
                                                                    bool includeLettuce, bool includeMayo)
        {
            var d = new DoubleDraugr();
            d.Bun = includeBun;
            d.Ketchup = includeKetchup;
            d.Mustard = includeMustard;
            d.Pickle = includePickle;
            d.Cheese = includeCheese;
            d.Tomato = includeTomato;
            d.Lettuce = includeLettuce;
            d.Mayo = includeMayo;

            if (!includeBun) Assert.Contains("Hold bun", d.SpecialInstructions);
            if (!includeKetchup) Assert.Contains("Hold ketchup", d.SpecialInstructions);
            if (!includeMustard) Assert.Contains("Hold mustard", d.SpecialInstructions);
            if (!includePickle) Assert.Contains("Hold pickle", d.SpecialInstructions);
            if (!includeTomato) Assert.Contains("Hold tomato", d.SpecialInstructions);
            if (!includeLettuce) Assert.Contains("Hold lettuce", d.SpecialInstructions);
            if (!includeMayo) Assert.Contains("Hold mayo", d.SpecialInstructions);

            if (includeBun && includeKetchup && includeMustard
                && includePickle && includeCheese && includeTomato
                && includeLettuce && includeMayo)
                Assert.Empty(d.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Double Draugr", new DoubleDraugr().ToString());
        }
    }
}