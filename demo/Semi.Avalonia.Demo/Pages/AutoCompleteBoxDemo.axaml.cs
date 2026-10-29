using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class AutoCompleteBoxDemo : ContentPage
{
    public AutoCompleteBoxDemo()
    {
        InitializeComponent();
        this.DataContext = new AutoCompleteBoxDemoViewModel();
    }
}