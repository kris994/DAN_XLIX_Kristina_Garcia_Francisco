using System;
using System.Globalization;
using System.Windows.Data;

namespace DAN_XLIX_Kristina_Garcia_Francisco.Converter
{
    /// <summary>
    /// Convertes the radio button values
    /// </summary>
    class RadioButtonConverter : IValueConverter
    {
        /// <summary>
        /// Converts the parameter value into a string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)parameter == (string)value);
        }

        /// <summary>
        /// Reverts it back, not implemented
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? parameter : null;
        }
    }
}
