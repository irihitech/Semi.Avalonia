using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Collections;
using Avalonia.Data.Converters;

namespace Semi.Avalonia.Converters;

public class ItemToObjectConverter: IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is AvaloniaList<object> list)
        {
            return list.Select(a => new object());
        }
        return new List<object>();
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}