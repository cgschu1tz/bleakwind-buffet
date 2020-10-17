/*
 * Author: Chris Schultz
 * Class name: LessThanOrEqualConverter.cs
 * Purpose: Defines a class for DataTriggers to use
 */
using System;
using System.Globalization;
using System.Windows.Data;

namespace BleakwindBuffet.PointOfSale
{
    /// <summary>
    /// Converts a <see cref="double"/> to a <see cref="bool"/> based on whether it is less than or equal to 0.
    /// </summary>
    public class LessThanOrEqualZeroConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value) <= 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
