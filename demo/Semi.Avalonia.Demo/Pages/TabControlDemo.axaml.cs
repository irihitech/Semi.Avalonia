using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class TabControlDemo : ContentPage
{
    public TabControlDemo()
    {
        InitializeComponent();
        this.DataContext = new TabControlDemoViewModel();
    }
}