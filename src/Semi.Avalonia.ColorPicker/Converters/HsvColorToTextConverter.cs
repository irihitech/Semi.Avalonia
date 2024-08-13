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
            ? $"{Math.Round(hsvColor.H)},{Math.Round(hsvColor.S * 100)},{Math.Round(hsvColor.V * 100)},{Math.Round(hsvColor.A * 100)}"
            : AvaloniaProperty.UnsetValue;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string str) return BindingOperations.DoNothing;
        var parts = str.Split(',');
        if (parts.Length != 4 || parts.Any(string.IsNullOrWhiteSpace)) return BindingOperations.DoNothing;

        if (double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out var h) &&
            double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out var s) &&
            double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out var v) &&
            double.TryParse(parts[3], NumberStyles.Float, CultureInfo.InvariantCulture, out var a))
        {
            return new HsvColor(a / 100, h, s / 100, v / 100);
        }

        return BindingOperations.DoNothing;
    }
}