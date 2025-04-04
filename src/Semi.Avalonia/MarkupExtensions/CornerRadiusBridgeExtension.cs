using System;
using Avalonia;

namespace Semi.Avalonia.Markup.Xaml;

public class CornerRadiusBridgeExtension
{
    public double TopLeft { get; set; }
    public double TopRight { get; set; }
    public double BottomRight { get; set; }
    public double BottomLeft { get; set; }

    public CornerRadiusBridgeExtension()
    {
    }

    public CornerRadiusBridgeExtension(double uniformRadius)
    {
        TopLeft = TopRight = BottomLeft = BottomRight = uniformRadius;
    }

    public CornerRadiusBridgeExtension(double top, double bottom)
    {
        TopLeft = TopRight = top;
        BottomLeft = BottomRight = bottom;
    }

    public CornerRadiusBridgeExtension(double topLeft, double topRight, double bottomRight, double bottomLeft)
    {
        TopLeft = topLeft;
        TopRight = topRight;
        BottomRight = bottomRight;
        BottomLeft = bottomLeft;
    }

    public CornerRadius ProvideValue(IServiceProvider serviceProvider)
    {
        return new CornerRadius(TopLeft, TopRight, BottomRight, BottomLeft);
    }
}