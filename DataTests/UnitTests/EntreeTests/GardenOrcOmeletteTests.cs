﻿/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: GardenOrcOmeletteTests.cs
 * Purpose: Test the GardenOrcOmelette.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    /// <summary>
    /// Unit tests for <see cref="GardenOrcOmelette"/>
    /// </summary>
    public class GardenOrcOmeletteTests
    {
        [Fact]
        public void ShouldHaveDescription()
        {
            Assert.Equal("Vegetarian. Two egg omelette packed with a mix of broccoli, mushrooms, and tomatoes. Topped with cheddar cheese.",
                new GardenOrcOmelette().Description);
        }

        [Fact]
        public void ShouldInvokePropertyChangedEvent()
        {
            var g = new GardenOrcOmelette();

            Assert.PropertyChanged(g, "Broccoli", () => g.Broccoli = true);
            Assert.PropertyChanged(g, "SpecialInstructions", () => g.Broccoli = true);

            Assert.PropertyChanged(g, "Mushrooms", () => g.Mushrooms = true);
            Assert.PropertyChanged(g, "SpecialInstructions", () => g.Mushrooms = true);

            Assert.PropertyChanged(g, "Tomato", () => g.Tomato = true);
            Assert.PropertyChanged(g, "SpecialInstructions", () => g.Tomato = true);

            Assert.PropertyChanged(g, "Cheddar", () => g.Cheddar = true);
            Assert.PropertyChanged(g, "SpecialInstructions", () => g.Cheddar = true);
        }

        [Fact]
        public void ShouldInheritEntree()
        {
            Assert.IsAssignableFrom<Entree>(new GardenOrcOmelette());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new GardenOrcOmelette());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new GardenOrcOmelette());
        }

        [Fact]
        public void ShouldIncludeBroccoliByDefault()
        {
            Assert.True(new GardenOrcOmelette().Broccoli);
        }

        [Fact]
        public void ShouldIncludeMushroomsByDefault()
        {
            Assert.True(new GardenOrcOmelette().Mushrooms);
        }

        [Fact]
        public void ShouldIncludeTomatoByDefault()
        {
            Assert.True(new GardenOrcOmelette().Tomato);
        }

        [Fact]
        public void ShouldIncludeCheddarByDefault()
        {
            Assert.True(new GardenOrcOmelette().Cheddar);
        }

        [Fact]
        public void ShouldBeAbleToSetBroccoli()
        {
            var g = new GardenOrcOmelette();
            g.Broccoli = false;
            Assert.False(g.Broccoli);
            g.Broccoli = true;
            Assert.True(g.Broccoli);
        }

        [Fact]
        public void ShouldBeAbleToSetMushrooms()
        {
            var g = new GardenOrcOmelette();
            g.Mushrooms = false;
            Assert.False(g.Mushrooms);
            g.Mushrooms = true;
            Assert.True(g.Mushrooms);
        }

        [Fact]
        public void ShouldBeAbleToSetTomato()
        {
            var g = new GardenOrcOmelette();
            g.Tomato = false;
            Assert.False(g.Tomato);
            g.Tomato = true;
            Assert.True(g.Tomato);
        }

        [Fact]
        public void ShouldBeAbleToSetCheddar()
        {
            var g = new GardenOrcOmelette();
            g.Cheddar = false;
            Assert.False(g.Cheddar);
            g.Cheddar = true;
            Assert.True(g.Cheddar);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal<decimal>(4.57m, new GardenOrcOmelette().Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)404, new GardenOrcOmelette().Calories);
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeBroccoli, bool includeMushrooms,
                                                            bool includeTomato, bool includeCheddar)
        {
            var g = new GardenOrcOmelette();
            g.Broccoli = includeBroccoli;
            g.Mushrooms = includeMushrooms;
            g.Tomato = includeTomato;
            g.Cheddar = includeCheddar;

            if (!includeBroccoli) Assert.Contains("Hold broccoli", g.SpecialInstructions);
            if (!includeMushrooms) Assert.Contains("Hold mushrooms", g.SpecialInstructions);
            if (!includeTomato) Assert.Contains("Hold tomato", g.SpecialInstructions);
            if (!includeCheddar) Assert.Contains("Hold cheddar", g.SpecialInstructions);

            if (includeBroccoli && includeMushrooms & includeTomato && includeCheddar)
                Assert.Empty(g.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Garden Orc Omelette", new GardenOrcOmelette().Name);
        }
    }
}