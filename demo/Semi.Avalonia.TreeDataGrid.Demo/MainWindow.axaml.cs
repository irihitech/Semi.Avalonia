using Avalonia.Controls;
using Semi.Avalonia.TreeDataGrid.Demo.ViewModels;

namespace Semi.Avalonia.TreeDataGrid.Demo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new SongsPageViewModel();
    }
}