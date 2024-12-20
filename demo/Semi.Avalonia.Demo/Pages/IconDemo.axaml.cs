using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class IconDemo : UserControl
{
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
}