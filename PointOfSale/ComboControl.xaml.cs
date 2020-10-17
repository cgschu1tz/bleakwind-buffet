/*
 * Author: Chris Schultz
 * Class name: ComboControl.xaml.cs
 * Purpose: Defines interaction logic for ComboControl.xaml
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using System;
using System.Windows.Controls;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Interaction logic for ComboControl.xaml
    /// </summary>
    public partial class ComboControl : UserControl
    {
        public ComboControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raised when the user selects a different entree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (entree.SelectedItem is ComboBoxItem c)
            {
                ((Combo)DataContext).Entree = Activator.CreateInstance(c.Tag as Type) as Entree;
            }
        }

        /// <summary>
        /// Raised when the user selects a different side
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void side_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (side.SelectedItem is ComboBoxItem c)
            {
                ((Combo)DataContext).Side = Activator.CreateInstance(c.Tag as Type) as Side;
            }
        }

        /// <summary>
        /// Raised when the user selects a different drink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drink_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (drink.SelectedItem is ComboBoxItem c)
            {
                ((Combo)DataContext).Drink = Activator.CreateInstance(c.Tag as Type) as Drink;
            }
        }
    }
}
