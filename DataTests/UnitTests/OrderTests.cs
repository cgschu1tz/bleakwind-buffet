/*
 * Author: Chris Schultz
 * Class: OrderTests.cs
 * Purpose: Test the Order.cs class in the Data library
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using Xunit;

namespace BleakwindBuffet.DataTests.UnitTests
{
    /// <summary>
    /// Unit tests for <see cref="Order"/>
    /// </summary>
    public class OrderTests
    {
        [Fact]
        public void ShouldImplementICollection()
        {
            Assert.IsAssignableFrom<ICollection<IOrderItem>>(new Order());
        }

        [Fact]
        public void ShouldImplementINotifyCollectionChanged()
        {
            Assert.IsAssignableFrom<INotifyCollectionChanged>(new Order());
        }

        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Assert.IsAssignableFrom<INotifyPropertyChanged>(new Order());
        }

        [Fact]
        public void AddingAnItemShouldNotify()
        {
            var o = new Order();

            bool raised = false;
            o.CollectionChanged += (a, b) => raised = true;
            o.Add(new MockDrink());
            Assert.True(raised);

            Assert.PropertyChanged(o, "Subtotal", () => o.Add(new MockDrink()));
            Assert.PropertyChanged(o, "Tax", () => o.Add(new MockDrink()));
            Assert.PropertyChanged(o, "Total", () => o.Add(new MockDrink()));
            Assert.PropertyChanged(o, "Calories", () => o.Add(new MockDrink()));
        }

        [Fact]
        public void RemovingAnItemShouldNotify()
        {
            var o = new Order();
            var d = new MockDrink();
            o.Add(d);

            bool raised = false;
            o.CollectionChanged += (a, b) => raised = true;
            o.Remove(d);
            Assert.True(raised);

            o.Add(d);
            Assert.PropertyChanged(o, "Subtotal", () => o.Remove(d));
            o.Add(d);
            Assert.PropertyChanged(o, "Tax", () => o.Remove(d));
            o.Add(d);
            Assert.PropertyChanged(o, "Total", () => o.Remove(d));
            o.Add(d);
            Assert.PropertyChanged(o, "Calories", () => o.Remove(d));
        }

        [Fact]
        public void ChangingAnItemShouldNotify()
        {
            var o = new Order();
            var d = new MockDrink();
            o.Add(d);

            Assert.PropertyChanged(o, "Subtotal", () => d.ChangeProperty("Price"));
            Assert.PropertyChanged(o, "Tax", () => d.ChangeProperty("Price"));
            Assert.PropertyChanged(o, "Total", () => d.ChangeProperty("Price"));

            Assert.PropertyChanged(o, "Calories", () => d.ChangeProperty("Calories"));
        }

        [Fact]
        public void CanHoldItems()
        {
            var o = new Order();
            var d = new MockDrink();

            Assert.Empty(o);

            o.Add(d);
            Assert.Contains(o, item => item is MockDrink);

            o.Remove(d);
            Assert.DoesNotContain(o, item => item is MockDrink);
            Assert.Empty(o);

            o.Add(d);
            o.Clear();
            Assert.Empty(o);
        }

        [Fact]
        public void ShouldDoTheMathRight()
        {
            var o = new Order();
            o.Add(new BriarheartBurger());
            o.Add(new SailorSoda() { Size = Size.Medium });
            o.Add(new VokunSalad() { Size = Size.Small });
            o.SalesTaxRate = 0.09;

            Assert.Equal(6.32 + 1.74 + 0.93, o.Subtotal, 2);
            Assert.Equal(0.09 * (6.32 + 1.74 + 0.93), o.Tax, 2);
            Assert.Equal(0.09 * (6.32 + 1.74 + 0.93) + (6.32 + 1.74 + 0.93), o.Total, 2);
            Assert.Equal(743 + 153 + 41, (int)o.Calories);
        }

        [Fact]
        public void UniqueInstancesShouldHaveDifferentNumbers()
        {
            var a = new Order();
            var b = new Order();
            Assert.NotEqual(a.Number, b.Number);
        }
    }
}
