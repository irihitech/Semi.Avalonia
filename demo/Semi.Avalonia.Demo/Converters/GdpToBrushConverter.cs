using System;
using System.Globalization;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using Irihi.Avalonia.Shared.Converters;

namespace Semi.Avalonia.Demo.Converters;

public sealed class GdpToBrushConverter : MarkupValueConverter
{
    private readonly ImmutableSolidColorBrush _orangeBrush = new(Colors.Orange, 0.6);
    private readonly ImmutableSolidColorBrush _yellowBrush = new(Colors.Yellow, 0.6);
    private readonly ImmutableSolidColorBrush _greenBrush = new(Colors.LightGreen, 0.6);

    public override object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not int gdp)
            return AvaloniaProperty.UnsetValue;

        return gdp switch
        {
            <= 5000 => _orangeBrush,
            <= 10000 => _yellowBrush,
            _ => _greenBrush
        };
    }
}
