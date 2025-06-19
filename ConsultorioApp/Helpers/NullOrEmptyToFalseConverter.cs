using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Helpers;

public class NullOrEmptyToFalseConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !string.IsNullOrEmpty(value?.ToString());
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}