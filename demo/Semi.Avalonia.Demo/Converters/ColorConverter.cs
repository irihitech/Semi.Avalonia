using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Semi.Avalonia.Demo.Converters;

public static class ColorConverter
{
    public static readonly IValueConverter ToHex =
        new FuncValueConverter<object, bool, string>(
            (obj, withAlpha) =>
                obj switch
                {
                    Color color => withAlpha
                        ? $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}"
                        : $"#{color.R:X2}{color.G:X2}{color.B:X2}",
                    ISolidColorBrush brush => withAlpha
                        ? $"#{brush.Color.A:X2}{brush.Color.R:X2}{brush.Color.G:X2}{brush.Color.B:X2}"
                        : $"#{brush.Color.R:X2}{brush.Color.G:X2}{brush.Color.B:X2}",
                    _ => string.Empty
                }
        );
}