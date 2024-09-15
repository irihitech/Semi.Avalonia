using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;

namespace Semi.Avalonia.Demo.Pages;

public partial class NotificationDemo : UserControl
{
    private WindowNotificationManager? _manager;

    public NotificationDemo()
    {
        InitializeComponent();
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        var topLevel = TopLevel.GetTopLevel(this);
        _manager = new WindowNotificationManager(topLevel) { MaxItems = 3 };
    }

    private void NormalButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button b && b.Content is string s)
        {
            _manager?.Show(Enum.TryParse<NotificationType>(s, out var t)
                ? new Notification(t.ToString(), "This is message", t)
                : new Notification(s, "This is message"));
        }
    }

    private void PositionButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is RadioButton b && b.Content is string s)
        {
            Enum.TryParse<NotificationPosition>(s, out var t);
            _manager.Position = t;
        }
    }
}