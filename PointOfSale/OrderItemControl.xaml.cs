/*
 * Author: Chris Schultz
 * Class name: OrderItemControl.xaml.cs
 * Purpose: Defines interaction logic for OrderItemControl.xaml
 */
using System.Windows;
using System.Windows.Controls;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderItemControl.xaml
    /// </summary>
    public partial class OrderItemControl : UserControl
    {
        /// <summary>
        /// Creates another control
        /// </summary>
        public OrderItemControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lets WPF know that we have a routed event of our own.
        /// </summary>
        public static readonly RoutedEvent RemoveClickedEvent = EventManager.RegisterRoutedEvent(
            nameof(RemoveClicked), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OrderItemControl));

        /// <summary>
        /// Raised when the "Remove" button is clicked
        /// </summary>
        public event RoutedEventHandler RemoveClicked
        {
            add { AddHandler(RemoveClickedEvent, value); }
            remove { RemoveHandler(RemoveClickedEvent, value); }
        }

        /// <summary>
        /// Fires when the "Remove" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(RemoveClickedEvent));
        }
    }
}
