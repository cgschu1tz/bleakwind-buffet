/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: ThugsTBoneTests.cs
 * Purpose: Test the ThugsTBone.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    /// <summary>
    /// Unit tests for <see cref="ThugsTBone"/>
    /// </summary>
    public class ThugsTBoneTests
    {
        [Fact]
        public void ShouldInheritEntree()
        {
            Assert.IsAssignableFrom<Entree>(new ThugsTBone());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new ThugsTBone());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new ThugsTBone());
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(6.44m, new ThugsTBone().Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)982, new ThugsTBone().Calories);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            Assert.Empty(new ThugsTBone().SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Thugs T-Bone", new ThugsTBone().Name);
        }
    }
}