using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Semi.Avalonia.Demo.Pages;

public partial class ThemeVariantDemo : UserControl
{
    private ThemeVariant _variant = ThemeVariant.Default;
    public ThemeVariantDemo()
    {
        InitializeComponent();
    }

    private void Switch_OnIsCheckedChanged(object sender, RoutedEventArgs e)
    {
        if (_variant == ThemeVariant.Dark)
        {
            scope.RequestedThemeVariant = ThemeVariant.Default;
            _variant = ThemeVariant.Default;
        }
        else
        {
            scope.RequestedThemeVariant = ThemeVariant.Dark;
            _variant = ThemeVariant.Dark;
        }
    }
}