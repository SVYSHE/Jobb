using System;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Jobb.Utility;

namespace GUI.Avalonia.Utility {
    public class EnumToStringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {

            return value.ToString();

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            var listBoxItem = value as ListBoxItem;
            return (JobbType)Enum.Parse(typeof(JobbType), listBoxItem.Content.ToString(), true);

        }
    }
}
