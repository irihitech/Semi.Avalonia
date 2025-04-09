using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class TabStripDemo : UserControl
{
    public TabStripDemo()
    {
        InitializeComponent();
        this.DataContext = new TabStripDemoViewModel();
    }
}