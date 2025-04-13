using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Semi.Avalonia.Converters;

public class TreeViewItemIndentConverter: IMultiValueConverter
{
    public static TreeViewItemIndentConverter Instance = new();
    
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is int level && values[1] is double indent)
        {
            return new Thickness( 
                indent * level,
                0,
                0,
                0);
        }
        return new Thickness(0);
    }
}