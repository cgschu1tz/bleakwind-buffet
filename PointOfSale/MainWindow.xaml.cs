/*
 * Author: Chris Schultz
 * Class name: MainWindow.xaml.cs
 * Purpose: Defines interaction logic for MainWindow.xaml
 */
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
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fires when the menu item selection changes and
        /// updates the customization controls accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menuItems = (ListBox)sender;
            if (menuItems.SelectedItem == null)
            {
                // Nothing is selected, so clear the customization control and its data context.
                CustomizationControl.Child = null;
                CustomizationControl.DataContext = null;
            }
            else 
            {
                var selectedItem = (MenuItemControl)menuItems.SelectedItem;
                CustomizationControl.Child = (UIElement)Activator.CreateInstance(selectedItem.CustomizationControl);
                CustomizationControl.DataContext = Activator.CreateInstance(selectedItem.MenuItem);
            }
        }
    }
}
