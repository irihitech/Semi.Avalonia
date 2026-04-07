using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input.GestureRecognizers;
using Avalonia.Interactivity;
using Avalonia.Layout;

namespace Semi.Avalonia.Demo.Pages;

public partial class DrawerPageDemo : UserControl
{
    public DrawerPageDemo()
    {
        InitializeComponent();
        EnableMouseSwipeGesture(DemoDrawer);
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

    private static void EnableMouseSwipeGesture(Control control)
    {
        var recognizer = control.GestureRecognizers
            .OfType<SwipeGestureRecognizer>()
            .FirstOrDefault();

        recognizer?.IsMouseEnabled = true;
    }

    private void OnLayoutChanged(object? sender, SelectionChangedEventArgs e)
    {
        DemoDrawer.DrawerLayoutBehavior = (sender as ComboBox)?.SelectedIndex switch
        {
            0 => DrawerLayoutBehavior.CompactOverlay,
            1 => DrawerLayoutBehavior.CompactInline,
            2 => DrawerLayoutBehavior.Split,
            3 => DrawerLayoutBehavior.Overlay,
            _ => DrawerLayoutBehavior.CompactOverlay
        };
    }
}