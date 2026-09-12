using System;
using System.Globalization;
using Irihi.Avalonia.Shared.Converters;

namespace Semi.Avalonia.Converters;

public class PositionToAngleConverter : MarkupValueConverter
{
    public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is double d ? d * 3.6 : 0;
    }

    public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is double d ? d / 3.6 : 0;
    }
}