using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Irihi.Avalonia.Shared.Converters;

namespace Semi.Avalonia.Converters;

public class PlacementToRenderTransformOriginConverter : MarkupValueConverter
{
    public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not PlacementMode p)
        {
            return new RelativePoint(0.5, 0.5, RelativeUnit.Relative);
        }

        return p switch
        {
            PlacementMode.Bottom => new RelativePoint(0.5, 0.0, RelativeUnit.Relative),
            PlacementMode.Left => new RelativePoint(1.0, 0.5, RelativeUnit.Relative),
            PlacementMode.Right => new RelativePoint(0.0, 0.5, RelativeUnit.Relative),
            PlacementMode.Top => new RelativePoint(0.5, 1.0, RelativeUnit.Relative),
            PlacementMode.Pointer => new RelativePoint(0.0, 0.0, RelativeUnit.Relative),
            PlacementMode.Center or PlacementMode.AnchorAndGravity => new RelativePoint(0.5, 0.5, RelativeUnit.Relative),
            PlacementMode.BottomEdgeAlignedLeft => new RelativePoint(0.0, 0.0, RelativeUnit.Relative),
            PlacementMode.BottomEdgeAlignedRight => new RelativePoint(1.0, 0.0, RelativeUnit.Relative),
            PlacementMode.LeftEdgeAlignedTop => new RelativePoint(1.0, 1.0, RelativeUnit.Relative),
            PlacementMode.LeftEdgeAlignedBottom => new RelativePoint(1.0, 0.0, RelativeUnit.Relative),
            PlacementMode.RightEdgeAlignedTop => new RelativePoint(0.0, 1.0, RelativeUnit.Relative),
            PlacementMode.RightEdgeAlignedBottom => new RelativePoint(0.0, 0.0, RelativeUnit.Relative),
            PlacementMode.TopEdgeAlignedLeft => new RelativePoint(0.0, 1.0, RelativeUnit.Relative),
            PlacementMode.TopEdgeAlignedRight => new RelativePoint(1.0, 1.0, RelativeUnit.Relative),
            _ => new RelativePoint(0.5, 0.5, RelativeUnit.Relative)
        };
    }
}