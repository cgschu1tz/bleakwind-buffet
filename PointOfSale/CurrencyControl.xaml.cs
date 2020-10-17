/*
 * Author: Chris Schultz
 * Class name: CurrencyControl.xaml.cs
 * Purpose: Defines interaction logic for CurrencyControl.xaml
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Interaction logic for CurrencyControl.xaml
    /// </summary>
    public partial class CurrencyControl : UserControl
    {
        public static DependencyProperty LabelProperty = DependencyProperty.Register(nameof(Label), typeof(string), typeof(CurrencyControl));
        public static DependencyProperty ChangeQuantityProperty = DependencyProperty.Register(nameof(ChangeQuantity), typeof(int), typeof(CurrencyControl));
        public static DependencyProperty CustomerQuantityProperty = DependencyProperty.Register(nameof(CustomerQuantity), typeof(int), typeof(CurrencyControl));

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public int ChangeQuantity
        {
            get => (int)GetValue(ChangeQuantityProperty);
            set => SetValue(ChangeQuantityProperty, value);
        }

        public int CustomerQuantity
        {
            get => (int)GetValue(CustomerQuantityProperty);
            set => SetValue(CustomerQuantityProperty, value);
        }

        public CurrencyControl()
        {
            InitializeComponent();
        }

        private void plusBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerQuantity++;
        }

        private void minusBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerQuantity--;
        }
    }
}
