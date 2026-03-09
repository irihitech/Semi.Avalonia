using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input.Platform;
using Avalonia.Threading;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class PaletteDemo : UserControl
{
    public PaletteDemo()
    {
        InitializeComponent();
        this.DataContext = new PaletteDemoViewModel();
    }

    protected override async void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        PaletteDemoViewModel? vm = this.DataContext as PaletteDemoViewModel;
        await Dispatcher.UIThread.InvokeAsync(() => { vm?.InitializeResources(); });
    }

    public async Task Copy(object? o)
    {
        if (o is null) return;
        var toplevel = TopLevel.GetTopLevel(this);
        if (toplevel?.Clipboard is { } c)
        {
            await c.SetTextAsync(o.ToString());
        }
    }
}