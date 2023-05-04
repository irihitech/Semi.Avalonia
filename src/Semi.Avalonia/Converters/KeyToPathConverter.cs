using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Metadata;

namespace Semi.Avalonia.Converters;

public class KeyToPathConverter: IValueConverter
{
    [Content]
    public IDictionary<string, object?> Resources { get; } = new Dictionary<string, object?>();
    
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if(value is string s && Resources.TryGetValue(s, out var v))
            return v;
        return AvaloniaProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}