using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class HighContrastDemo : UserControl
{
    public HighContrastDemo()
    {
        InitializeComponent();
        this.DataContext = new HighContrastDemoViewModel();
    }
}