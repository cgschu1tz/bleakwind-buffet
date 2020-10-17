/*
 * Author: Chris Schultz
 * Class name: CashDrawerWindow.xaml.cs
 * Purpose: Defines interaction logic for CashDrawerWindow.xaml
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Interaction logic for CashDrawerWindow.xaml
    /// </summary>
    public partial class CashDrawerWindow : Window
    {
        public CashDrawerWindow()
        {
            InitializeComponent();
            DataContext = new CashDrawerViewModel();
        }

        private void returnToOrder_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void finalizeSale_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
