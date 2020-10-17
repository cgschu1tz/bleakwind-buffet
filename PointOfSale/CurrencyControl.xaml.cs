/*
 * Author: Chris Schultz
 * Class name: CurrencyControl.xaml.cs
 * Purpose: Defines interaction logic for CurrencyControl.xaml
 */
using System.Windows;
using System.Windows.Controls;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Interaction logic for CurrencyControl.xaml
    /// </summary>
    public partial class CurrencyControl : UserControl
    {
        /// <summary>
        /// A dependency property
        /// </summary>
        public static DependencyProperty LabelProperty = DependencyProperty.Register(nameof(Label), typeof(string), typeof(CurrencyControl));

        /// <summary>
        /// A dependency property
        /// </summary>
        public static DependencyProperty ChangeQuantityProperty = DependencyProperty.Register(nameof(ChangeQuantity), typeof(int), typeof(CurrencyControl));

        /// <summary>
        /// A dependency property
        /// </summary>
        public static DependencyProperty CustomerQuantityProperty = DependencyProperty.Register(nameof(CustomerQuantity), typeof(int), typeof(CurrencyControl));

        /// <summary>
        /// The currency label
        /// </summary>
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        /// <summary>
        /// The amount of this currency that is due as change
        /// </summary>
        public int ChangeQuantity
        {
            get => (int)GetValue(ChangeQuantityProperty);
            set => SetValue(ChangeQuantityProperty, value);
        }

        /// <summary>
        /// The amount of this currency that the customer has given us
        /// </summary>
        public int CustomerQuantity
        {
            get => (int)GetValue(CustomerQuantityProperty);
            set => SetValue(CustomerQuantityProperty, value);
        }

        /// <summary>
        /// Creates a new currency control
        /// </summary>
        public CurrencyControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raised when the user clicks the + button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void plusBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerQuantity++;
        }

        /// <summary>
        /// Raised when the user clicks the - button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minusBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerQuantity--;
        }
    }
}
