using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;

namespace Semi.Avalonia.Demo.Pages;

public partial class DrawerPageDemo : UserControl
{
    public DrawerPageDemo()
    {
        InitializeComponent();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        DemoDrawer.Opened += OnDrawerStatusChanged;
        DemoDrawer.Closed += OnDrawerStatusChanged;
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        base.OnUnloaded(e);
        DemoDrawer.Opened -= OnDrawerStatusChanged;
        DemoDrawer.Closed -= OnDrawerStatusChanged;
    }

    private void OnDrawerStatusChanged(object? sender, EventArgs e) => UpdateStatus();

    private void OnToggleDrawer(object? sender, RoutedEventArgs e)
    {
        DemoDrawer.IsOpen = !DemoDrawer.IsOpen;
    }

    private void OnGestureChanged(object? sender, RoutedEventArgs e)
    {
        DemoDrawer.IsGestureEnabled = GestureCheck.IsChecked == true;
    }

    private void OnMenuSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DrawerMenu.SelectedItem is ListBoxItem item)
        {
            DemoDrawer.Content = new ContentPage
            {
                Header = item.Content?.ToString(),
                Content = new TextBlock
                {
                    Text = $"{item.Content} page content",
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = Brushes.Black,
                },
                HorizontalContentAlignment = HorizontalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Stretch
            };
            DemoDrawer.IsOpen = false;
        }
    }

    private void UpdateStatus()
    {
        StatusText.Text = $"Drawer: {(DemoDrawer.IsOpen ? "Open" : "Closed")}";
    }
}