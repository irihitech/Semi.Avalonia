using System;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using Avalonia.Styling;

namespace Semi.Avalonia.Converters;

public class AdaptiveColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is IImmutableSolidColorBrush brush)
        {
            var color = brush.Color;
            var theme = Application.Current.ActualThemeVariant;
            var para = double.Parse(parameter?.ToString() ?? "0.2");
            
            double factor = theme == ThemeVariant.Light ? -para : para; 
            return AdjustColorBrightness(color, factor);
        }
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    
    private IImmutableSolidColorBrush AdjustColorBrightness(Color color, double factor)
    {
        // 调整颜色亮度
        var r = (byte)Math.Min(255, Math.Max(0, color.R + color.R * factor));
        var g = (byte)Math.Min(255, Math.Max(0, color.G + color.G * factor));
        var b = (byte)Math.Min(255, Math.Max(0, color.B + color.B * factor));
        return new ImmutableSolidColorBrush(Color.FromRgb(r, g, b));
    }
}