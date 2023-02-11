using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class PaletteDemo : UserControl
{
    public PaletteDemo()
    {
        InitializeComponent();
        this.DataContext = new PaletteDemoViewModel();
    }
}