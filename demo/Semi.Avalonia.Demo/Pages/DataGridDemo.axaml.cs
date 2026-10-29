using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class DataGridDemo : ContentPage
{
    public DataGridDemo()
    {
        InitializeComponent();
        DataContext = new DataGridDemoViewModel();
    }
}
