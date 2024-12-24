using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;

namespace Semi.Avalonia.Converters;

public class PlacementToRenderTransformOriginConverter: IValueConverter
{
    public static PlacementToRenderTransformOriginConverter Instance { get; } = new PlacementToRenderTransformOriginConverter();
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not PlacementMode p)
        {
            return new RelativePoint(0.5, 0.5, RelativeUnit.Relative);
        }
        switch (p)
        {
            case  PlacementMode.Bottom:
                return new RelativePoint(0.5, 0.0, RelativeUnit.Relative);
            case PlacementMode.Left:
                return new RelativePoint(1.0, 0.5, RelativeUnit.Relative);
            case PlacementMode.Right:
                return new RelativePoint(0.0, 0.5, RelativeUnit.Relative);
            case PlacementMode.Top:
                return new RelativePoint(0.5, 1.0, RelativeUnit.Relative);
            case PlacementMode.Pointer:
                return new RelativePoint(0.0, 0.0, RelativeUnit.Relative);
            case PlacementMode.Center:
            case PlacementMode.AnchorAndGravity:
                return new RelativePoint(0.5, 0.5, RelativeUnit.Relative);
            case PlacementMode.BottomEdgeAlignedLeft:
                return new RelativePoint(0.0, 0.0, RelativeUnit.Relative);
            case PlacementMode.BottomEdgeAlignedRight:
                return new RelativePoint(1.0, 0.0, RelativeUnit.Relative);
            case PlacementMode.LeftEdgeAlignedTop:
                return new RelativePoint(1.0, 1.0, RelativeUnit.Relative);
            case PlacementMode.LeftEdgeAlignedBottom:
                return new RelativePoint(1.0, 0.0, RelativeUnit.Relative);
            case PlacementMode.RightEdgeAlignedTop:
                return new RelativePoint(0.0, 1.0, RelativeUnit.Relative);
            case PlacementMode.RightEdgeAlignedBottom:
                return new RelativePoint(0.0, 0.0, RelativeUnit.Relative);
            case PlacementMode.TopEdgeAlignedLeft:
                return new RelativePoint(0.0, 1.0, RelativeUnit.Relative);
            case PlacementMode.TopEdgeAlignedRight:
                return new RelativePoint(1.0, 1.0, RelativeUnit.Relative);
        }
        return new RelativePoint(0.5, 0.5, RelativeUnit.Relative);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}