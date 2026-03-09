using System.Globalization;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input.Platform;
using Avalonia.Media;
using Semi.Avalonia.Demo.Converters;

namespace Semi.Avalonia.Demo.Controls;

public class ColorDetailControl : TemplatedControl
{
    public const string KEY_ResourceKey = "ResourceKey";
    public const string KEY_Hex = "Hex";
    public const string KEY_Hex2 = "Hex2";
    public const string KEY_Opacity = "Opacity";
    public const string KEY_ColorResourceKey = "ColorResourceKey";

    public static readonly StyledProperty<string?> ResourceKeyProperty =
        AvaloniaProperty.Register<ColorDetailControl, string?>(nameof(ResourceKey));

    public string? ResourceKey
    {
        get => GetValue(ResourceKeyProperty);
        set => SetValue(ResourceKeyProperty, value);
    }

    public static readonly StyledProperty<string?> ResourceNameProperty =
        AvaloniaProperty.Register<ColorDetailControl, string?>(nameof(ResourceName));

    public string? ResourceName
    {
        get => GetValue(ResourceNameProperty);
        set => SetValue(ResourceNameProperty, value);
    }

    public static readonly StyledProperty<string?> ColorResourceKeyProperty =
        AvaloniaProperty.Register<ColorDetailControl, string?>(nameof(ColorResourceKey));

    public string? ColorResourceKey
    {
        get => GetValue(ColorResourceKeyProperty);
        set => SetValue(ColorResourceKeyProperty, value);
    }

    public static readonly DirectProperty<ColorDetailControl, string?> HexProperty =
        AvaloniaProperty.RegisterDirect<ColorDetailControl, string?>(nameof(Hex), o => o.Hex);

    private string? _hex;

    public string? Hex
    {
        get => _hex;
        private set => SetAndRaise(HexProperty, ref _hex, value);
    }

    private string? _hex2;

    public static readonly DirectProperty<ColorDetailControl, string?> Hex2Property =
        AvaloniaProperty.RegisterDirect<ColorDetailControl, string?>(nameof(Hex2), o => o.Hex2);

    public string? Hex2
    {
        get => _hex2;
        set => SetAndRaise(Hex2Property, ref _hex2, value);
    }

    public static readonly DirectProperty<ColorDetailControl, string?> OpacityNumberProperty =
        AvaloniaProperty.RegisterDirect<ColorDetailControl, string?>(nameof(OpacityNumber), o => o.OpacityNumber);

    private string? _opacityNumber;

    public string? OpacityNumber
    {
        get => _opacityNumber;
        private set => SetAndRaise(OpacityNumberProperty, ref _opacityNumber, value);
    }

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