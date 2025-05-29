using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class DataGridDemo : UserControl
{
    public DataGridDemo()
    {
        InitializeComponent();
        DataContext = new DataGridDemoViewModel();
    }
}