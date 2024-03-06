using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class TabControlDemo : UserControl
{
    public TabControlDemo()
    {
        InitializeComponent();
        this.DataContext = new TabControlDemoViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}