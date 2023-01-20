using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Presenters;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Semi.Avalonia.Demo.Views;

namespace Semi.Avalonia.Demo.Pages;

public partial class NotificationDemo : UserControl
{
    private MainWindow? _window;
    public NotificationDemo()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        _window = VisualRoot as MainWindow;
    }

    private void InfoButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button b && b.Content is string s && Enum.TryParse<NotificationType>(s, out NotificationType t))
        {
            _window?.Notify(t);
        }
    }
}