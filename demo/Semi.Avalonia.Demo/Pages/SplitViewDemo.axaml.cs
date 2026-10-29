using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class SplitViewDemo : ContentPage
{
    public SplitViewDemo()
    {
        InitializeComponent();
        this.DataContext = new SplitViewDemoViewModel();
    }
}