using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class AutoCompleteBoxDemo : UserControl
{
    public AutoCompleteBoxDemo()
    {
        InitializeComponent();
        this.DataContext = new AutoCompleteBoxDemoViewModel();
    }
}