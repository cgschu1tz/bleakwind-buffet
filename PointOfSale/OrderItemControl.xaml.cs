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
        public OrderItemControl()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent RemoveClickedEvent = EventManager.RegisterRoutedEvent(
            nameof(RemoveClicked), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(OrderItemControl));

        public event RoutedEventHandler RemoveClicked
        {
            add { AddHandler(RemoveClickedEvent, value); }
            remove { RemoveHandler(RemoveClickedEvent, value); }
        }

        private void removeBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(RemoveClickedEvent));
        }
    }
}
