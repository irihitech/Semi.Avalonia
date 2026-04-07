using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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