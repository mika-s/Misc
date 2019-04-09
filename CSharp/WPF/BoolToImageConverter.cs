using System;
using System.Globalization;
using System.Windows.Data;

namespace CSharp
{
    /// <summary>
    /// Converter to convert a bool to a string containing the URL of an image.
    /// </summary>
    [ValueConversion(typeof(bool), typeof(string))]
    public sealed class BoolToImageConverter : IValueConverter
    {
        /// <summary>
        /// Convert from bool to a string containing the URL of an image.
        /// </summary>
        /// <param name="value">Input value of type bool.</param>
        /// <param name="targetType">Type to convert to.</param>
        /// <param name="parameter">Some kind of parameter.</param>
        /// <param name="culture">Culture parameter.</param>
        /// <returns>Converted value.</returns>
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return null;

            if ((bool)value == true)
                return "pack://application:,,,/Images/TrueImage.png";
            else
                return "pack://application:,,,/Images/FalseImage.png";
        }

        /// <summary>
        /// Not used for anything, but needed for the IValueConverter interface.
        /// </summary>
        /// <param name="value">The parameter is not used.</param>
        /// <param name="targetType">The parameter is not used.</param>
        /// <param name="parameter">The parameter is not used.</param>
        /// <param name="culture">The parameter is not used.</param>
        /// <returns>Not applicable.</returns>
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
