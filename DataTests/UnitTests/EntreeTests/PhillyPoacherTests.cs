/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: PhillyPoacherTests.cs
 * Purpose: Test the PhillyPoacher.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    /// <summary>
    /// Unit tests for <see cref="PhillyPoacher"/>
    /// </summary>
    public class PhillyPoacherTests
    {
        [Fact]
        public void InheritsEntree()
        {
            Assert.IsAssignableFrom<Entree>(new PhillyPoacher());
        }

        [Fact]
        public void ImplementsIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new PhillyPoacher());
        }

        [Fact]
        public void ShouldIncludeSirloinByDefault()
        {
            Assert.True(new PhillyPoacher().Sirloin);
        }

        [Fact]
        public void ShouldIncludeOnionByDefault()
        {
            Assert.True(new PhillyPoacher().Onion);
        }

        [Fact]
        public void ShouldIncludeRollByDefault()
        {
            Assert.True(new PhillyPoacher().Roll);
        }

        [Fact]
        public void ShouldBeAbleToSetSirloin()
        {
            var p = new PhillyPoacher();
            p.Sirloin = false;
            Assert.False(p.Sirloin);
            p.Sirloin = true;
            Assert.True(p.Sirloin);
        }

        [Fact]
        public void ShouldBeAbleToSetOnions()
        {
            var p = new PhillyPoacher();
            p.Onion = false;
            Assert.False(p.Onion);
            p.Onion = true;
            Assert.True(p.Onion);
        }

        [Fact]
        public void ShouldBeAbleToSetRoll()
        {
            var p = new PhillyPoacher();
            p.Roll = false;
            Assert.False(p.Roll);
            p.Roll = true;
            Assert.True(p.Roll);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(7.23, new PhillyPoacher().Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)784, new PhillyPoacher().Calories);
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeSirloin, bool includeOnion,
                                                            bool includeRoll)
        {
            var g = new PhillyPoacher();
            g.Sirloin = includeSirloin;
            g.Roll = includeRoll;
            g.Onion = includeOnion;

            if (!includeSirloin) Assert.Contains("Hold sirloin", g.SpecialInstructions);
            if (!includeRoll) Assert.Contains("Hold roll", g.SpecialInstructions);
            if (!includeOnion) Assert.Contains("Hold onions", g.SpecialInstructions);

            if (includeSirloin && includeRoll & includeOnion)
                Assert.Empty(g.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Philly Poacher", new PhillyPoacher().ToString());
        }
    }
}