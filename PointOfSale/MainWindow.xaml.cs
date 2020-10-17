/*
 * Author: Chris Schultz
 * Class name: MainWindow.xaml.cs
 * Purpose: Defines interaction logic for MainWindow.xaml
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Wraps <see cref="DataContext"/> so we don't have to cast it every time we use it.
        /// </summary>
        private Order Order
        {
            get => DataContext as Order;
            set {
                DataContext = value;
            }
        }

        /// <summary>
        /// Creates the window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Order = new Order();
            Order.Add(new Combo(new SailorSoda(), new BriarheartBurger(), new VokunSalad()));
        }

        private void menuItem_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button b)
            {
                Order.Add(Activator.CreateInstance(b.Tag as Type) as IOrderItem);

                // Select the item we just added so the user can modify it
                orderItems.SelectedIndex = orderItems.Items.Count - 1;
            }
        }

        /// <summary>
        /// Raised when the user clicks the "Cancel order" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(
                "The current order will be lost forever.  Is this OK?",
                "Bleakwind Buffet POS",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Order = new Order();
            }
        }

        /// <summary>
        /// Raised when the user clicks "Remove" on one of the items in the order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void orderControl_RemoveClicked(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is Button b)
            {
                Order.Remove(b.DataContext as IOrderItem);
            }
        }

        /// <summary>
        /// Raised when the user clicks "Pay with Credit/Debit"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void payCardBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = RoundRegister.CardReader.RunCard(Order.Total);
            switch (result)
            {
                case RoundRegister.CardTransactionResult.Approved:
                    ReceiptPrinter.PrintReceipt(Order, PaymentMethod.CreditDebit);
                    MessageBox.Show("Transaction approved");
                    Order = new Order();
                    break;

                case RoundRegister.CardTransactionResult.Declined:
                    MessageBox.Show("Card declined");
                    break;

                case RoundRegister.CardTransactionResult.ReadError:
                    MessageBox.Show("Card failed to read.  Please try again.");
                    break;

                case RoundRegister.CardTransactionResult.InsufficientFunds:
                    MessageBox.Show("Insufficient funds on card");
                    break;

                case RoundRegister.CardTransactionResult.IncorrectPin:
                    MessageBox.Show("The PIN that was entered is incorrect.");
                    break;
            }
        }

        /// <summary>
        /// Raised when the user clicks "Pay with Cash"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void payCashBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CashDrawerWindow() { Owner = this };
            ((CashDrawerViewModel)dialog.DataContext).SaleAmount = Order.Total;
            if(dialog.ShowDialog() == true)
            {
                Order = new Order();
            }
        }
    }
}
