using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class TabStripDemo : ContentPage
{
    public TabStripDemo()
    {
        InitializeComponent();
        this.DataContext = new TabStripDemoViewModel();
    }
}