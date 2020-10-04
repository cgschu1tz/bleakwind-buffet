/*
 * Author: Chris Schultz
 * Class name: MenuItemControl.xaml.cs
 * Purpose: Defines interaction logic for MenuItemControl.xaml
 */
using System;
using System.Windows.Controls;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuItemControl.xaml
    /// </summary>
    public partial class MenuItemControl : ListBoxItem
    {
        public MenuItemControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The type of control that is used to customize this item.
        /// </summary>
        public Type CustomizationControl { get; set; }

        /// <summary>
        /// The type of menu item object that should be constructed and bound 
        /// to the customization control.
        /// </summary>
        public Type MenuItem { get; set; }
    }
}
