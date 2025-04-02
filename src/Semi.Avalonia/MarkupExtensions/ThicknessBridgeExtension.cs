using System;
using Avalonia;

namespace Semi.Avalonia.Markup.Xaml;

public class ThicknessBridgeExtension
{
    public double Left { get; set; }
    public double Top { get; set; }
    public double Right { get; set; }
    public double Bottom { get; set; }

    public ThicknessBridgeExtension()
    {
    }

    public ThicknessBridgeExtension(double uniformLength)
    {
        Left = Right = Top = Bottom = uniformLength;
    }

    public ThicknessBridgeExtension(double horizontal, double vertical)
    {
        Left = Right = horizontal;
        Top = Bottom = vertical;
    }

    public ThicknessBridgeExtension(double left, double top, double right, double bottom)
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }

    public Thickness ProvideValue(IServiceProvider serviceProvider)
    {
        return new Thickness(Left, Top, Right, Bottom);
    }
}