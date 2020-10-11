/*
 * Author: Chris Schultz
 * Class name: MainWindow.xaml.cs
 * Purpose: Defines interaction logic for MainWindow.xaml
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.PointOfSale.Drinks;
using BleakwindBuffet.PointOfSale.Entrees;
using BleakwindBuffet.PointOfSale.Sides;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Dictionary<Type, Type> customizationControls = new Dictionary<Type, Type>
        {
            {typeof(BriarheartBurger), typeof(BriarheartBurgerControl)},
            {typeof(DoubleDraugr), typeof(DoubleDraugrControl)},
            {typeof(ThalmorTriple), typeof(ThalmorTripleControl)},
            {typeof(SmokehouseSkeleton), typeof(SmokehouseSkeletonControl)},
            {typeof(GardenOrcOmelette), typeof(GardenOrcOmeletteControl)},
            {typeof(PhillyPoacher), typeof(PhillyPoacherControl)},
            {typeof(ThugsTBone), typeof(ThugsTBoneControl)},
            {typeof(SailorSoda), typeof(SailorSodaControl)},
            {typeof(MarkarthMilk), typeof(MarkarthMilkControl)},
            {typeof(AretinoAppleJuice), typeof(AretinoAppleJuiceControl)},
            {typeof(CandlehearthCoffee), typeof(CandlehearthCoffeeControl)},
            {typeof(WarriorWater), typeof(WarriorWaterControl)},
            {typeof(VokunSalad), typeof(VokunSaladControl)},
            {typeof(FriedMiraak), typeof(FriedMiraakControl)},
            {typeof(MadOtarGrits), typeof(MadOtarGritsControl)},
            {typeof(DragonbornWaffleFries), typeof(DragonbornWaffleFriesControl)},
        };

        public MainWindow()
        {
            InitializeComponent();
            orderControl.DataContext = new Order();
            ((Order)orderControl.DataContext).Add(new ThalmorTriple() { Bacon = false });
        }

        /// <summary>
        /// Fires when the menu item selection changes and
        /// updates the customization controls accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (menuItems.SelectedItem == null)
            {
                // Nothing is selected, so clear the customization control and its data context.
                customizationControl.Child = null;
                customizationControl.DataContext = null;
                addBtn.IsEnabled = false;
            }
            else
            {
                var selectedItem = (MenuItemControl)menuItems.SelectedItem;
                customizationControl.Child = (UIElement)Activator.CreateInstance(selectedItem.CustomizationControl);
                customizationControl.DataContext = Activator.CreateInstance(selectedItem.MenuItem);
                addBtn.IsEnabled = true;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var order = (Order)orderControl.DataContext;
            order.Add((IOrderItem)customizationControl.DataContext);

            customizationControl.Child = null;
            customizationControl.DataContext = null;
            addBtn.IsEnabled = false;
        }

        private void cancelOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(
                "The current order will be lost forever.  Is this OK?",
                "Bleakwind Buffet POS",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                orderControl.DataContext = new Order();
            }
        }

        private void orderItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (orderItems.SelectedItem == null)
            {
                // Nothing is selected, so clear the customization control and its data context.
                customizationControl.Child = null;
                customizationControl.DataContext = null;
                addBtn.IsEnabled = false;
            }
            else
            {
                var selectedItem = orderItems.SelectedItem;
                customizationControl.Child = (UIElement)Activator.CreateInstance(customizationControls[selectedItem.GetType()]);
                customizationControl.DataContext = selectedItem;
                addBtn.IsEnabled = false;
            }
        }

        private void orderControl_RemoveClicked(object sender, RoutedEventArgs e)
        {
            var order = (Order)orderControl.DataContext;
            var item = (OrderItemControl)e.OriginalSource;
            order.Remove((IOrderItem)item.DataContext);
        }
    }
}
