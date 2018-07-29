using System;

namespace ClientLight.Converters
{
    using Windows.UI.Xaml.Data;

    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return new DateTimeOffset(((DateTime)value).ToUniversalTime());

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                return ((DateTimeOffset)value).DateTime;
            }
            return DateTimeOffset.UtcNow;
        }
    }
}
