using System.Linq;
using Avalonia.Controls;
using Avalonia.Input.GestureRecognizers;
using Avalonia.Layout;

namespace Semi.Avalonia.Demo.Pages;

public partial class DrawerPageDemo : UserControl
{
    public DrawerPageDemo()
    {
        InitializeComponent();
        EnableMouseSwipeGesture(DemoDrawer);
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

    private static void EnableMouseSwipeGesture(Control control)
    {
        var recognizer = control.GestureRecognizers
            .OfType<SwipeGestureRecognizer>()
            .FirstOrDefault();

        recognizer?.IsMouseEnabled = true;
    }
}
