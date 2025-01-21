using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class VariablesDemo : UserControl
{
    public VariablesDemo()
    {
        InitializeComponent();
        this.DataContext = new VariablesDemoViewModel();
    }

    protected override async void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        var vm = this.DataContext as VariablesDemoViewModel;
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