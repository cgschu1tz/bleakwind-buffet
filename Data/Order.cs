/*
 * Author: Chris Schultz
 * Class name: Order.cs
 * Purpose: Defines a class representing an order
 */
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace BleakwindBuffet.Data
{
    /// <summary>
    /// An order
    /// </summary>
    public class Order : ObservableCollection<IOrderItem>, ICollection<IOrderItem>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// The number that will be assigned to the next created order.
        /// </summary>
        static int nextOrderNumber = 1;

        /// <summary>
        /// Adds an item to the order
        /// </summary>
        /// <param name="item">the item to add</param>
        public new void Add(IOrderItem item)
        {
            base.Add(item);
            if (item is INotifyPropertyChanged i)
            {
                i.PropertyChanged += OnItemChanged;
            }
            OnItemChanged(null, null);
        }

        /// <summary>
        /// Clears the order
        /// </summary>
        public new void Clear()
        {
            foreach (var item in this)
            {
                if (item is INotifyPropertyChanged i)
                {
                    i.PropertyChanged -= OnItemChanged;
                }
            }
            base.Clear();
            OnItemChanged(null, null);
        }

        /// <summary>
        /// Removes an item from the order
        /// </summary>
        /// <param name="item">the item to remove</param>
        /// <returns>
        /// <c>true</c> if the item was successfully removed,
        /// <c>false</c> otherwise
        /// </returns>
        public new bool Remove(IOrderItem item)
        {
            var result = base.Remove(item);
            if (item is INotifyPropertyChanged i)
            {
                i.PropertyChanged -= OnItemChanged;
            }
            OnItemChanged(null, null);
            return result;
        }

        /// <summary>
        /// This order's number.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// The sales tax rate
        /// </summary>
        public double SalesTaxRate { get; set; } = 0.12;

        /// <summary>
        /// The total price of all the items in the order before tax
        /// </summary>
        public double Subtotal
        {
            get {
                double subtotal = 0;
                foreach (var item in this)
                {
                    subtotal += item.Price;
                }
                return subtotal;
            }
        }

        /// <summary>
        /// The total calories in the order
        /// </summary>
        public uint Calories
        {
            get {
                uint calories = 0;
                foreach (var item in this)
                {
                    calories += item.Calories;
                }
                return calories;
            }
        }

        /// <summary>
        /// The tax on the order
        /// </summary>
        public double Tax => Subtotal * SalesTaxRate;

        /// <summary>
        /// The total cost of the order (including tax)
        /// </summary>
        public double Total => Subtotal + Tax;

        /// <summary>
        /// Creates a new order.
        /// </summary>
        public Order()
        {
            Number = nextOrderNumber;
            nextOrderNumber++;
        }

        /// <summary>
        /// Sends notifications whenever the order changes.
        /// </summary>
        private void OnItemChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Subtotal)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Tax)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Total)));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Calories)));
        }
    }
}
