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
    /// Interaction logic for AddOrCancelControl.xaml
    /// </summary>
    public partial class OKCancelControl : UserControl
    {
        public OKCancelControl()
        {
            InitializeComponent();
        }

        public bool IsOK { get; private set; }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            IsOK = true;
            parent.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this);
            IsOK = false;
            parent.Close();
        }
    }
}
