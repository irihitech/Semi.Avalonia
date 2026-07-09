using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class TableViewDemo : UserControl
{
    public TableViewDemo()
    {
        InitializeComponent();
        this.DataContext = new TableViewDemoViewModel();
    }
}
