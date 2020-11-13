/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: ThalmorTripleTests.cs
 * Purpose: Test the ThalmorTriple.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    /// <summary>
    /// Unit tests for <see cref="ThalmorTripleTests"/>
    /// </summary>
    public class ThalmorTripleTests
    {
        [Fact]
        public void ShouldHaveDescription()
        {
            Assert.Equal("Think you are strong enough to take on the Thalmor? Includes two 1/4lb patties, with a 1/2lb patty in between, and ketchup, mustard, pickle, cheese, tomato, lettuce, mayo, bacon, and an egg.",
                new ThalmorTriple().Description);
        }

        [Fact]
        public void ShouldInvokePropertyChangedEvent()
        {
            var t = new ThalmorTriple();

            Assert.PropertyChanged(t, "Bun", () => t.Bun = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Bun = true);

            Assert.PropertyChanged(t, "Ketchup", () => t.Ketchup = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Ketchup = true);

            Assert.PropertyChanged(t, "Mustard", () => t.Mustard = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Mustard = true);

            Assert.PropertyChanged(t, "Pickle", () => t.Pickle = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Pickle = true);

            Assert.PropertyChanged(t, "Cheese", () => t.Cheese = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Cheese = true);

            Assert.PropertyChanged(t, "Tomato", () => t.Tomato = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Tomato = true);

            Assert.PropertyChanged(t, "Lettuce", () => t.Lettuce = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Lettuce = true);

            Assert.PropertyChanged(t, "Mayo", () => t.Mayo = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Mayo = true);

            Assert.PropertyChanged(t, "Bacon", () => t.Bacon = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Bacon = true);

            Assert.PropertyChanged(t, "Egg", () => t.Egg = true);
            Assert.PropertyChanged(t, "SpecialInstructions", () => t.Egg = true);
        }

        [Fact]
        public void ShouldInheritEntree()
        {
            Assert.IsAssignableFrom<Entree>(new ThalmorTriple());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new ThalmorTriple());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new ThalmorTriple());
        }

        [Fact]
        public void ShouldIncludeBunByDefault()
        {
            Assert.True(new ThalmorTriple().Bun);
        }

        [Fact]
        public void ShouldIncludeKetchupByDefault()
        {
            Assert.True(new ThalmorTriple().Ketchup);
        }

        [Fact]
        public void ShouldIncludeMustardByDefault()
        {
            Assert.True(new ThalmorTriple().Mustard);
        }

        [Fact]
        public void ShouldIncludePickleByDefault()
        {
            Assert.True(new ThalmorTriple().Pickle);
        }

        [Fact]
        public void ShouldIncludeCheeseByDefault()
        {
            Assert.True(new ThalmorTriple().Cheese);
        }

        [Fact]
        public void ShouldIncludeTomatoByDefault()
        {
            Assert.True(new ThalmorTriple().Tomato);
        }

        [Fact]
        public void ShouldIncludeLettuceByDefault()
        {
            Assert.True(new ThalmorTriple().Lettuce);
        }

        [Fact]
        public void ShouldIncludeMayoByDefault()
        {
            Assert.True(new ThalmorTriple().Mayo);
        }

        [Fact]
        public void ShouldIncludeBaconByDefault()
        {
            Assert.True(new ThalmorTriple().Bacon);
        }

        [Fact]
        public void ShouldIncludeEggByDefault()
        {
            Assert.True(new ThalmorTriple().Egg);
        }

        [Fact]
        public void ShouldBeAbleToSetBun()
        {
            var t = new ThalmorTriple();
            t.Bun = false;
            Assert.False(t.Bun);
            t.Bun = true;
            Assert.True(t.Bun);
        }

        [Fact]
        public void ShouldBeAbleToSetKetchup()
        {
            var t = new ThalmorTriple();
            t.Ketchup = false;
            Assert.False(t.Ketchup);
            t.Ketchup = true;
            Assert.True(t.Ketchup);
        }

        [Fact]
        public void ShouldBeAbleToSetMustard()
        {
            var t = new ThalmorTriple();
            t.Mustard = false;
            Assert.False(t.Mustard);
            t.Mustard = true;
            Assert.True(t.Mustard);
        }

        [Fact]
        public void ShouldBeAbleToSetPickle()
        {
            var t = new ThalmorTriple();
            t.Pickle = false;
            Assert.False(t.Pickle);
            t.Pickle = true;
            Assert.True(t.Pickle);
        }

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            var t = new ThalmorTriple();
            t.Cheese = false;
            Assert.False(t.Cheese);
            t.Cheese = true;
            Assert.True(t.Cheese);
        }

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            var t = new ThalmorTriple();
            t.Tomato = false;
            Assert.False(t.Tomato);
            t.Tomato = true;
            Assert.True(t.Tomato);
        }

        [Fact]
        public void ShouldBeAbleToSetLettuce()
        {
            var t = new ThalmorTriple();
            t.Lettuce = false;
            Assert.False(t.Lettuce);
            t.Lettuce = true;
            Assert.True(t.Lettuce);
        }

        [Fact]
        public void ShouldBeAbleToSetMayo()
        {
            var t = new ThalmorTriple();
            t.Mayo = false;
            Assert.False(t.Mayo);
            t.Mayo = true;
            Assert.True(t.Mayo);
        }

        [Fact]
        public void ShouldBeAbleToSetBacon()
        {
            var t = new ThalmorTriple();
            t.Bacon = false;
            Assert.False(t.Bacon);
            t.Bacon = true;
            Assert.True(t.Bacon);
        }

        [Fact]
        public void ShouldBeAbleToSetEgg()
        {
            var t = new ThalmorTriple();
            t.Egg = false;
            Assert.False(t.Egg);
            t.Egg = true;
            Assert.True(t.Egg);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(8.32m, new ThalmorTriple().Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)943, new ThalmorTriple().Calories);
        }

        [Theory]
        [InlineData(true, true, true, true, true, true, true, true, true, true)]
        [InlineData(false, false, false, false, false, false, false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBun, bool includeKetchup, bool includeMustard,
                                                                    bool includePickle, bool includeCheese, bool includeTomato,
                                                                    bool includeLettuce, bool includeMayo,
                                                                    bool includeBacon, bool includeEgg)
        {
            var t = new ThalmorTriple();
            t.Bun = includeBun;
            t.Ketchup = includeKetchup;
            t.Mustard = includeMustard;
            t.Pickle = includePickle;
            t.Cheese = includeCheese;
            t.Tomato = includeTomato;
            t.Lettuce = includeLettuce;
            t.Mayo = includeMayo;
            t.Bacon = includeBacon;
            t.Egg = includeEgg;

            if (!includeBun) Assert.Contains("Hold bun", t.SpecialInstructions);
            if (!includeKetchup) Assert.Contains("Hold ketchup", t.SpecialInstructions);
            if (!includeMustard) Assert.Contains("Hold mustard", t.SpecialInstructions);
            if (!includePickle) Assert.Contains("Hold pickle", t.SpecialInstructions);
            if (!includeTomato) Assert.Contains("Hold tomato", t.SpecialInstructions);
            if (!includeLettuce) Assert.Contains("Hold lettuce", t.SpecialInstructions);
            if (!includeMayo) Assert.Contains("Hold mayo", t.SpecialInstructions);
            if (!includeBacon) Assert.Contains("Hold bacon", t.SpecialInstructions);
            if (!includeEgg) Assert.Contains("Hold egg", t.SpecialInstructions);

            if (includeBun && includeKetchup && includeMustard
                && includePickle && includeCheese && includeTomato
                && includeLettuce && includeMayo
                && includeBacon && includeEgg)
                Assert.Empty(t.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Thalmor Triple", new ThalmorTriple().Name);
        }
    }
}