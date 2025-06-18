using System;
using System.Globalization;
using Microsoft.Maui.Controls;

public class TimeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime dateTime)
            return new TimeSpan(dateTime.Hour, dateTime.Minute, 0);

        return new TimeSpan(9, 0, 0); // Default
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is TimeSpan timeSpan) return new DateTime(1, 1, 1, timeSpan.Hours, timeSpan.Minutes, 0);

        return DateTime.Now;
    }
}