using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Controls.Primitives;
using Avalonia.Input.Platform;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class IconDemo : UserControl
{
    private IClipboard? _clipboard;
    private WindowNotificationManager? _windowNotificationManager;

    public IconDemo()
    {
        InitializeComponent();
        this.DataContext = new IconDemoViewModel();
    }

    protected override async void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        var vm = this.DataContext as IconDemoViewModel;
        await Dispatcher.UIThread.InvokeAsync(() => { vm?.InitializeResources(); });
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        var topLevel = TopLevel.GetTopLevel(this);
        _windowNotificationManager = new WindowNotificationManager(topLevel) { MaxItems = 3 };
        _clipboard = topLevel?.Clipboard;
    }

    private async void Button_Clicked(object sender, RoutedEventArgs e)
    {
        if (_clipboard is null) return;
        if (sender is not Button { DataContext: IconItem s }) return;
        await _clipboard.SetTextAsync(s.ResourceKey);
        _windowNotificationManager?.Show(
            new Notification("Copied", s.ResourceKey),
            NotificationType.Success);
    }
}