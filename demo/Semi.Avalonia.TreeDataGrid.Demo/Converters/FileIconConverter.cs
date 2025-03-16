using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Metadata;

namespace Semi.Avalonia.TreeDataGrid.Demo.Converters;

public class FileIconConverter : IMultiValueConverter
{
    [Content] public IDictionary<string, object?> Items { get; } = new Dictionary<string, object?>();

    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0] is bool isDirectory && values[1] is bool isOpen)
        {
            if (!isDirectory)
            {
                return Items["file"];
            }

            return isOpen ? Items["folderOpen"] : Items["folderClosed"];
        }

        return AvaloniaProperty.UnsetValue;
    }
}