using System;
using System.Globalization;
using Avalonia.Controls;
using Irihi.Avalonia.Shared.Converters;

namespace Semi.Avalonia.ColorPicker.Converters;

public class ToColorModel : MarkupValueConverter
{
    public override object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return parameter is "Hex" && value is "Hex" ||
               parameter is "Rgba" && value is ColorModel.Rgba ||
               parameter is "Hsva" && value is ColorModel.Hsva;
    }

    public override object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}