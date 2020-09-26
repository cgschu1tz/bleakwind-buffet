using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.PointOfSale.Drinks;
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

        private void MenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menuItems = (ListBox)sender;
            if (menuItems.SelectedItem == null)
            {
                // Nothing is selected, so clear the customization control.
                CustomizationControl.Child = null;
            }
            else 
            {
                var selectedItem = (ListBoxItem)menuItems.SelectedItem;
                CustomizationControl.Child = (UIElement)Activator.CreateInstance((Type)selectedItem.Tag);
            }
        }
    }
}
