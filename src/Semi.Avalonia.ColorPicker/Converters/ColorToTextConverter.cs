using System;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Semi.Avalonia.ColorPicker.Converters;

public class ColorToTextConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is Color color ? $"{color.R},{color.G},{color.B}" : AvaloniaProperty.UnsetValue;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string str) return BindingOperations.DoNothing;
        var parts = str.Split(',');
        if (parts.Length != 3 || parts.Any(string.IsNullOrWhiteSpace)) return BindingOperations.DoNothing;

        if (byte.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out var r) &&
            byte.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var g) &&
            byte.TryParse(parts[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out var b))
        {
            return new Color(0xFF, r, g, b);
        }

        return BindingOperations.DoNothing;
    }
}