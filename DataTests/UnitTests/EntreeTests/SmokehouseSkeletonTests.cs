/*
 * Author: Zachery Brunner
 * Edited by: Chris Schultz
 * Class: SmokehouseSkeletonTests.cs
 * Purpose: Test the SmokehouseSkeleton.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.EntreeTests
{
    /// <summary>
    /// Unit tests for <see cref="SmokehouseSkeletonTests"/>
    /// </summary>
    public class SmokehouseSkeletonTests
    {
        [Fact]
        public void ShouldInvokePropertyChangedEvent()
        {
            var s = new SmokehouseSkeleton();

            Assert.PropertyChanged(s, "SausageLink", () => s.SausageLink = true);
            Assert.PropertyChanged(s, "SpecialInstructions", () => s.SausageLink = true);

            Assert.PropertyChanged(s, "Egg", () => s.Egg = true);
            Assert.PropertyChanged(s, "SpecialInstructions", () => s.Egg = true);

            Assert.PropertyChanged(s, "HashBrowns", () => s.HashBrowns = true);
            Assert.PropertyChanged(s, "SpecialInstructions", () => s.HashBrowns = true);

            Assert.PropertyChanged(s, "Pancake", () => s.Pancake = true);
            Assert.PropertyChanged(s, "SpecialInstructions", () => s.Pancake = true);
        }

        [Fact]
        public void ShouldInheritEntree()
        {
            Assert.IsAssignableFrom<Entree>(new SmokehouseSkeleton());
        }

        [Fact]
        public void ShouldImplementIOrderItem()
        {
            Assert.IsAssignableFrom<IOrderItem>(new SmokehouseSkeleton());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new SmokehouseSkeleton());
        }

        [Fact]
        public void ShouldIncludeSausageLinkByDefault()
        {
            Assert.True(new SmokehouseSkeleton().SausageLink);
        }

        [Fact]
        public void ShouldIncludeEggByDefault()
        {
            Assert.True(new SmokehouseSkeleton().Egg);
        }

        [Fact]
        public void ShouldIncludeHashbrownsByDefault()
        {
            Assert.True(new SmokehouseSkeleton().HashBrowns);
        }

        [Fact]
        public void ShouldIncludePancakeByDefault()
        {
            Assert.True(new SmokehouseSkeleton().Pancake);
        }

        [Fact]
        public void ShouldBeAbleToSetSausage()
        {
            var s = new SmokehouseSkeleton();
            s.SausageLink = false;
            Assert.False(s.SausageLink);
            s.SausageLink = true;
            Assert.True(s.SausageLink);
        }

        [Fact]
        public void ShouldBeAbleToSetEgg()
        {
            var s = new SmokehouseSkeleton();
            s.Egg = false;
            Assert.False(s.Egg);
            s.Egg = true;
            Assert.True(s.Egg);
        }

        [Fact]
        public void ShouldBeAbleToSetHashbrowns()
        {
            var s = new SmokehouseSkeleton();
            s.HashBrowns = false;
            Assert.False(s.HashBrowns);
            s.HashBrowns = true;
            Assert.True(s.HashBrowns);
        }

        [Fact]
        public void ShouldBeAbleToSetPancake()
        {
            var s = new SmokehouseSkeleton();
            s.Pancake = false;
            Assert.False(s.Pancake);
            s.Pancake = true;
            Assert.True(s.Pancake);
        }

        [Fact]
        public void ShouldReturnCorrectPrice()
        {
            Assert.Equal(5.62m, new SmokehouseSkeleton().Price);
        }

        [Fact]
        public void ShouldReturnCorrectCalories()
        {
            Assert.Equal((uint)602, new SmokehouseSkeleton().Calories);
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, false, false, false)]
        public void ShouldReturnCorrectSpecialInstructions(bool includeSausage, bool includeEgg,
                                                            bool includeHashbrowns, bool includePancake)
        {
            var s = new SmokehouseSkeleton();
            s.SausageLink = includeSausage;
            s.Egg = includeEgg;
            s.HashBrowns = includeHashbrowns;
            s.Pancake = includePancake;

            if (!includeSausage) Assert.Contains("Hold sausage", s.SpecialInstructions);
            if (!includeEgg) Assert.Contains("Hold eggs", s.SpecialInstructions);
            if (!includeHashbrowns) Assert.Contains("Hold hash browns", s.SpecialInstructions);
            if (!includePancake) Assert.Contains("Hold pancakes", s.SpecialInstructions);

            if (includeSausage && includeEgg & includeHashbrowns && includePancake)
                Assert.Empty(s.SpecialInstructions);
        }

        [Fact]
        public void ShouldReturnCorrectToString()
        {
            Assert.Equal("Smokehouse Skeleton", new SmokehouseSkeleton().Name);
        }
    }
}