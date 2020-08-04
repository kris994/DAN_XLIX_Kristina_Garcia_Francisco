using System;
using System.Globalization;
using System.Windows.Data;

namespace DAN_XLIX_Kristina_Garcia_Francisco.Converter
{
    /// <summary>
    /// Convertes the date value
    /// </summary>
    class DateConverter : IValueConverter
    {
        /// <summary>
        /// Returns current date if the date time is set to default
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((DateTime)value == default(DateTime))
            {
                value = DateTimeOffset.Now;
                return value;
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Returns the selected value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
