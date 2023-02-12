using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class PaletteDemo : UserControl
{
    public PaletteDemo()
    {
        InitializeComponent();
        
    }

    protected override async  void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        PaletteDemoViewModel? vm = new PaletteDemoViewModel();
        vm.InitializeResources();
        DataContext = vm;
    }
}