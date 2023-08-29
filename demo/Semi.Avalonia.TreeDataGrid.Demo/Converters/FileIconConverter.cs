using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Metadata;

namespace Semi.Avalonia.TreeDataGrid.Demo.Converters;

public class FileIconConverter: IMultiValueConverter
{
    [Content] 
    public Dictionary<string, PathGeometry> Items { get; set; } = new Dictionary<string, PathGeometry>();

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