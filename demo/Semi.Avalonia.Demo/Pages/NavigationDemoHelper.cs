using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace Semi.Avalonia.Demo.Pages;

/// <summary>
/// Shared helpers for ControlCatalog demo pages.
/// </summary>
internal static class NavigationDemoHelper
{
    /// <summary>
    /// Pastel background brushes cycled by page index.
    /// </summary>
    internal static readonly IBrush[] PageBrushes =
    [
        new SolidColorBrush(Color.Parse("#BBDEFB")),
        new SolidColorBrush(Color.Parse("#C8E6C9")),
        new SolidColorBrush(Color.Parse("#FFE0B2")),
        new SolidColorBrush(Color.Parse("#E1BEE7")),
        new SolidColorBrush(Color.Parse("#FFCDD2")),
        new SolidColorBrush(Color.Parse("#B2EBF2"))
    ];

    internal static IBrush GetPageBrush(int index) =>
        PageBrushes[(index % PageBrushes.Length + PageBrushes.Length) % PageBrushes.Length];

    /// <summary>
    /// Creates a simple demo ContentPage with a centered title and subtitle.
    /// </summary>
    internal static ContentPage MakePage(string header, string body, int colorIndex) =>
        new()
        {
            Header = header,
            Background = GetPageBrush(colorIndex),
            Content = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Spacing = 8,
                Children =
                {
                    new TextBlock
                    {
                        Text = header,
                        FontSize = 20,
                        FontWeight = FontWeight.SemiBold,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Foreground = Brushes.Black,
                    },
                    new TextBlock
                    {
                        Text = body,
                        FontSize = 13,
                        Opacity = 0.7,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center,
                        MaxWidth = 260,
                        Foreground = Brushes.Black,
                    }
                }
            },
            HorizontalContentAlignment = HorizontalAlignment.Stretch,
            VerticalContentAlignment = VerticalAlignment.Stretch
        };
}