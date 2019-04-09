using System;
using System.Windows.Data;

namespace CSharp
{
    /// <summary>
    /// Converter to convert a MyEnum enum to a string.
    /// </summary>
    [ValueConversion(typeof(MyEnum), typeof(string))]
    public class EnumToStringConverter : IValueConverter
    {
        /// <summary>
        /// Convert from MyEnum enum to string.
        /// </summary>
        /// <param name="value">Input value of type MyEnum.</param>
        /// <param name="targetType">Type to convert to.</param>
        /// <param name="parameter">Some kind of parameter.</param>
        /// <param name="culture">Culture parameter.</param>
        /// <returns>Converted value.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((MyEnum)value)      // This example converts to filenames as string.
            {
                case MyEnum.test1:
                    return "pack://application:,,,/Images/test1.jpg";
                case MyEnum.test2:
                    return "pack://application:,,,/Images/test2.jpg";
                case MyEnum.test3:
                    return "pack://application:,,,/Images/test3.jpg";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Not used for anything, but needed for the IValueConverter interface.
        /// </summary>
        /// <param name="value">The parameter is not used.</param>
        /// <param name="targetType">The parameter is not used.</param>
        /// <param name="parameter">The parameter is not used.</param>
        /// <param name="culture">The parameter is not used.</param>
        /// <returns>Not applicable.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
