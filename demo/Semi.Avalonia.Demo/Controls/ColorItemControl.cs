using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using CommunityToolkit.Mvvm.Messaging;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Controls;

public class ColorItemControl : TemplatedControl
{
    public static readonly StyledProperty<string?> ColorNameProperty =
        AvaloniaProperty.Register<ColorItemControl, string?>(nameof(ColorName));

    public string? ColorName
    {
        get => GetValue(ColorNameProperty);
        set => SetValue(ColorNameProperty, value);
    }

    public static readonly StyledProperty<string?> HexProperty = AvaloniaProperty.Register<ColorItemControl, string?>(
        nameof(Hex));

    public string? Hex
    {
        get => GetValue(HexProperty);
        set => SetValue(HexProperty, value);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        switch (this.DataContext)
        {
            case ColorItemViewModel colorItemViewModel:
                WeakReferenceMessenger.Default.Send(colorItemViewModel);
                break;
            case ColorResource colorResource:
                WeakReferenceMessenger.Default.Send(colorResource);
                break;
        }
    }
}