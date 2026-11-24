using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using CommunityToolkit.Mvvm.Messaging;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Controls;

public partial class ColorItemControl : TemplatedControl
{
    [GeneratedStyledProperty] public partial string? ColorName { get; set; }
    [GeneratedStyledProperty] public partial string? Hex { get; set; }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);
        switch (DataContext)
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