using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class ComboBoxDemo : ContentPage
{
    public ComboBoxDemo()
    {
        InitializeComponent();
        this.DataContext = new ComboBoxDemoViewModel();
    }
}