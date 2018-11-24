using System;
using System.Globalization;
using System.Windows.Data;

namespace PtaSheet.Infrastructure.Converters
{

    /// <summary>
    ///     Determines boolean value based upon nullability.
    /// </summary>
    /// <remarks>
    ///     If the incoming object is NULL, then false is returned. Does not support going backwards as it is meaningless.
    /// </remarks>
    [ValueConversion(typeof(object), typeof(bool))]
    public sealed class NullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}