using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Semi.Avalonia.Demo.Pages;

public partial class Overview : UserControl
{
    public Overview()
    {
        InitializeComponent();
    }

    private void ToggleButton_OnIsCheckedChanged(object sender, RoutedEventArgs e)
    {
        var variant = Application.Current!.RequestedThemeVariant;
        if (variant?.Key == "Dark")
        {
            Application.Current!.RequestedThemeVariant = ThemeVariant.Light;
        }
        else
        {
            Application.Current!.RequestedThemeVariant = ThemeVariant.Dark;
        }
    }
}