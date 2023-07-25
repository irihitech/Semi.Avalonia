using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using Semi.Avalonia.TreeDataGrid.Demo.ViewModels;

namespace Semi.Avalonia.TreeDataGrid.Demo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new SongsPageViewModel();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var app = Application.Current;
        if (app is not null)
        {
            var theme = app.ActualThemeVariant;
            app.RequestedThemeVariant = theme == ThemeVariant.Dark ? ThemeVariant.Light : ThemeVariant.Dark;
        }
    }
}