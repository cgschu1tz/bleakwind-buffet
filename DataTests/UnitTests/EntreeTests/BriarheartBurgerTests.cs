/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: BriarheartBurgerTests.cs
 * Purpose: Test the BriarheartBurger.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    /// <summary>
    /// Unit tests for <see cref="BriarheartBurger"/>
    /// </summary>
    public class BriarheartBurgerTests
    {
        [Fact]
        public void ShouldInheritEntree()
        {
            Assert.IsAssignableFrom<Entree>(new BriarheartBurger());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new BriarheartBurger());
        }

        [Fact]
        public void ShouldIncludeBunByDefault()
        {
            Assert.True(new BriarheartBurger().Bun);
        }

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            Assert.True(new BriarheartBurger().Ketchup);
        }

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            Assert.True(new BriarheartBurger().Mustard);
        }

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            Assert.True(new BriarheartBurger().Pickle);
        }

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            Assert.True(new BriarheartBurger().Cheese);
        }

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            var b = new BriarheartBurger();
            b.Bun = false;
            Assert.False(b.Bun);
            b.Bun = true;
            Assert.True(b.Bun);
        }

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            var b = new BriarheartBurger();
            b.Ketchup = false;
            Assert.False(b.Ketchup);
            b.Ketchup = true;
            Assert.True(b.Ketchup);
        }

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            var b = new BriarheartBurger();
            b.Mustard = false;
            Assert.False(b.Mustard);
            b.Mustard = true;
            Assert.True(b.Mustard);
        }

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            var b = new BriarheartBurger();
            b.Pickle = false;
            Assert.False(b.Pickle);
            b.Pickle = true;
            Assert.True(b.Pickle);
        }

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            var b = new BriarheartBurger();
            b.Cheese = false;
            Assert.False(b.Cheese);
            b.Cheese = true;
            Assert.True(b.Cheese);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(6.32, new BriarheartBurger().Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)743, new BriarheartBurger().Calories);
        }

        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese)
        {
            var b = new BriarheartBurger();
            b.Bun = includeBun;
            b.Ketchup = includeKetchup;
            b.Mustard = includeMustard;
            b.Pickle = includePickle;
            b.Cheese = includeCheese;

            if (!includeBun) Assert.Contains("Hold bun", b.SpecialInstructions);
            if (!includeKetchup) Assert.Contains("Hold ketchup", b.SpecialInstructions);
            if (!includeMustard) Assert.Contains("Hold mustard", b.SpecialInstructions);
            if (!includePickle) Assert.Contains("Hold pickle", b.SpecialInstructions);
            if (!includeCheese) Assert.Contains("Hold cheese", b.SpecialInstructions);

            if (includeBun && includeKetchup && includeMustard && includePickle && includeCheese)
                Assert.Empty(b.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Briarheart Burger", new BriarheartBurger().ToString());
        }
    }
}