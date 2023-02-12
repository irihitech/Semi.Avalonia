using System.Globalization;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input.Platform;
using Avalonia.Media;
using Avalonia.Media.Immutable;

namespace Semi.Avalonia.Demo.Controls;

public class ColorDetailControl: TemplatedControl
{
    public const string KEY_ResourceKey = "ResourceKey";
    public const string KEY_Hex = "Hex";
    public const string KEY_Opacity = "Opacity";
    
    public static readonly StyledProperty<string?> ResourceKeyProperty = AvaloniaProperty.Register<ColorDetailControl, string?>(
        nameof(ResourceKey));
    public string? ResourceKey
    {
        get => GetValue(ResourceKeyProperty);
        set => SetValue(ResourceKeyProperty, value);
    }

    public static readonly StyledProperty<string?> ResourceNameProperty = AvaloniaProperty.Register<ColorDetailControl, string?>(
        nameof(ResourceName));

    public string? ResourceName
    {
        get => GetValue(ResourceNameProperty);
        set => SetValue(ResourceNameProperty, value);
    }

    public static readonly DirectProperty<ColorDetailControl, string?> HexProperty = AvaloniaProperty.RegisterDirect<ColorDetailControl, string?>(
        nameof(Hex), o => o.Hex);
    private string? _hex;
    public string? Hex
    {
        get => _hex;
        private set => SetAndRaise(HexProperty, ref _hex, value);
    }
    
    public static readonly DirectProperty<ColorDetailControl, string?> OpacityNumberProperty = AvaloniaProperty.RegisterDirect<ColorDetailControl, string?>(
        nameof(OpacityNumber), o => o.OpacityNumber);
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
        if (color is ISolidColorBrush b)
        {
            Hex = b.Color.ToString().ToUpperInvariant();
            OpacityNumber = b.Opacity.ToString(CultureInfo.InvariantCulture);
        }
    }

    public async void Copy(object o)
    {
        string? text = null;
        if (o is string s)
        {
            switch (s)
            {
                case KEY_ResourceKey: text = ResourceKey;
                    break;
                case KEY_Hex: text = Hex;
                    break;
                case KEY_Opacity: text = OpacityNumber;
                    break;
                default: text = string.Empty; break;
            }
        }

        if (Application.Current is { Clipboard: { } c })
        {
            await c.SetTextAsync(text??string.Empty);
        }
        
    }
    
}