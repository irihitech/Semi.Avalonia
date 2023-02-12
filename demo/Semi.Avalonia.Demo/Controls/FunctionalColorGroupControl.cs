using System.Collections;
using Avalonia;
using Avalonia.Controls.Primitives;

namespace Semi.Avalonia.Demo.Controls;

public class FunctionalColorGroupControl: TemplatedControl
{
    public static readonly StyledProperty<string?> TitleProperty = AvaloniaProperty.Register<FunctionalColorGroupControl, string?>(
        nameof(Title));
    public string? Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    public static readonly DirectProperty<FunctionalColorGroupControl, IEnumerable> LightColorsProperty = AvaloniaProperty.RegisterDirect<FunctionalColorGroupControl, IEnumerable>(
        nameof(LightColors), o => o.LightColors, (o, v) => o.LightColors = v);
    private IEnumerable _lightColors;
    public IEnumerable LightColors
    {
        get => _lightColors;
        set => SetAndRaise(LightColorsProperty, ref _lightColors, value);
    }

    

    public static readonly DirectProperty<FunctionalColorGroupControl, IEnumerable> DarkColorsProperty = AvaloniaProperty.RegisterDirect<FunctionalColorGroupControl, IEnumerable>(
        nameof(DarkColors), o => o.DarkColors, (o, v) => o.DarkColors = v);
    private IEnumerable _darkColors;
    public IEnumerable DarkColors
    {
        get => _darkColors;
        set => SetAndRaise(DarkColorsProperty, ref _darkColors, value);
    }
    
    
}