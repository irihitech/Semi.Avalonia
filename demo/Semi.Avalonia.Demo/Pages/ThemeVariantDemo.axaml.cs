using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace Semi.Avalonia.Demo.Pages;

public partial class ThemeVariantDemo : UserControl
{
    public ThemeVariantDemo()
    {
        InitializeComponent();
    }

    private void Switch_OnIsCheckedChanged(object sender, RoutedEventArgs e)
    {
        scope.RequestedThemeVariant = scope.ActualThemeVariant == ThemeVariant.Dark ? ThemeVariant.Light : ThemeVariant.Dark;
    }
}