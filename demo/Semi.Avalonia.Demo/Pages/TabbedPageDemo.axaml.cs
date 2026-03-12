using System.Collections;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace Semi.Avalonia.Demo.Pages;

public partial class TabbedPageDemo : UserControl
{
    private int _tabCounter = 3;

    public TabbedPageDemo()
    {
        InitializeComponent();
    }

    private void OnAddTab(object? sender, RoutedEventArgs e)
    {
        var idx = ++_tabCounter;
        var page = new ContentPage
        {
            Header = $"Tab {idx}",
            Content = new StackPanel
            {
                Margin = new Thickness(16),
                Spacing = 8,
                Children =
                {
                    new TextBlock
                    {
                        Text = $"Tab {idx}",
                        FontSize = 24,
                        FontWeight = FontWeight.Bold,
                    },
                    new TextBlock
                    {
                        Text = $"This tab was added dynamically (tab #{idx}).",
                        Opacity = 0.7,
                        TextWrapping = TextWrapping.Wrap,
                    }
                }
            }
        };

        ((IList)DemoTabs.Pages!).Add(page);
        UpdateStatus();
    }

    private void OnRemoveTab(object? sender, RoutedEventArgs e)
    {
        var pages = (IList)DemoTabs.Pages!;
        if (pages.Count > 1)
        {
            pages.RemoveAt(pages.Count - 1);
            UpdateStatus();
        }
    }

    private void OnPlacementChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DemoTabs == null) return;
        DemoTabs.TabPlacement = PlacementCombo.SelectedIndex switch
        {
            1 => TabPlacement.Bottom,
            2 => TabPlacement.Left,
            3 => TabPlacement.Right,
            _ => TabPlacement.Top
        };
    }

    private void OnSelectionChanged(object? sender, PageSelectionChangedEventArgs e)
    {
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        if (StatusText == null) return;
        var pages = (IList)DemoTabs.Pages!;
        var pageName = (DemoTabs.SelectedPage as ContentPage)?.Header?.ToString() ?? "—";
        StatusText.Text = $"{pages.Count} tab{(pages.Count != 1 ? "s" : "")} | Selected: {pageName} ({DemoTabs.SelectedIndex})";
    }
}