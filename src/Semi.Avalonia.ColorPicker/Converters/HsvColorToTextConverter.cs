using System;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Semi.Avalonia.ColorPicker.Converters;

public class HsvColorToTextConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is HsvColor hsvColor
            ? $"{Math.Round(hsvColor.H)},{Math.Round(hsvColor.S * 100)},{Math.Round(hsvColor.V * 100)}"
            : AvaloniaProperty.UnsetValue;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string str) return BindingOperations.DoNothing;
        var parts = str.Split(',');
        if (parts.Length != 3 || parts.Any(string.IsNullOrWhiteSpace)) return BindingOperations.DoNothing;

        if (double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var h) &&
            double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var s) &&
            double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var v))
        {
            return new HsvColor(1, h, s / 100, v / 100);
        }

        return BindingOperations.DoNothing;
    }
}