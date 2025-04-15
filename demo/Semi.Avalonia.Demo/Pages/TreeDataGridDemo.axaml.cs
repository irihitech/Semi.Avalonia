using Avalonia.Controls;
using Avalonia.Input;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class TreeDataGridDemo : UserControl
{
    public TreeDataGridDemo()
    {
        InitializeComponent();
        this.DataContext = new TreeDataGridDemoViewModel();
    }

    private void SelectedPath_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            var vm = DataContext as TreeDataGridDemoViewModel;
            vm.FilesContext.SelectedPath = (sender as TextBox)!.Text;
        }
    }
}