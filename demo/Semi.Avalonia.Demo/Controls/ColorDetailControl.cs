using System.Globalization;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input.Platform;
using Avalonia.Media;
using Semi.Avalonia.Demo.Converters;

namespace Semi.Avalonia.Demo.Controls;

public partial class ColorDetailControl : TemplatedControl
{
    public const string KEY_ResourceKey = "ResourceKey";
    public const string KEY_Hex = "Hex";
    public const string KEY_Hex2 = "Hex2";
    public const string KEY_Opacity = "Opacity";
    public const string KEY_ColorResourceKey = "ColorResourceKey";

    [GeneratedStyledProperty] public partial string? ResourceKey { get; set; }
    [GeneratedStyledProperty] public partial string? ResourceName { get; set; }
    [GeneratedStyledProperty] public partial string? ColorResourceKey { get; set; }
    [GeneratedDirectProperty] public partial string? Hex { get; set; }
    [GeneratedDirectProperty] public partial string? Hex2 { get; set; }
    [GeneratedDirectProperty] public partial string? OpacityNumber { get; set; }

    static ColorDetailControl()
    {
        BackgroundProperty.Changed.AddClassHandler<ColorDetailControl>((o, e) => o.OnBackgroundChanged(e));
    }

    private void OnBackgroundChanged(AvaloniaPropertyChangedEventArgs args)
    {
        var color = args.GetNewValue<IBrush>();
        if (color is ISolidColorBrush brush)
        {
            var hex1 = ColorConverter.ToHex.Convert(brush.Color, typeof(string), false, CultureInfo.InvariantCulture);
            var hex2 = ColorConverter.ToHex.Convert(brush.Color, typeof(string), true, CultureInfo.InvariantCulture);
            Hex = hex1 as string;
            Hex2 = hex2 as string;
            OpacityNumber = brush.Opacity.ToString(CultureInfo.InvariantCulture);
        }
        else
        {
            Hex = null;
            Hex2 = null;
            OpacityNumber = null;
        }
    }

    public async Task Copy(object o)
    {
        string? text = null;
        if (o is string s)
        {
            text = s switch
            {
                KEY_ResourceKey => ResourceKey,
                KEY_Hex => Hex,
                KEY_Hex2 => Hex2,
                KEY_Opacity => OpacityNumber,
                KEY_ColorResourceKey => ColorResourceKey,
                _ => string.Empty
            };
        }

        var toplevel = TopLevel.GetTopLevel(this);
        if (toplevel?.Clipboard is { } c)
        {
            await c.SetTextAsync(text ?? string.Empty);
        }
    }
}