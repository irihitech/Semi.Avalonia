using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class RefreshContainerDemo : UserControl
{
    private RefreshContainerDemoViewModel _viewModel;

    public RefreshContainerDemo()
    {
        InitializeComponent();
        _viewModel = new RefreshContainerDemoViewModel();
        DataContext = _viewModel;
    }

    private async void RefreshContainerPage_RefreshRequested(object? sender, RefreshRequestedEventArgs e)
    {
        var deferral = e.GetDeferral();
        await _viewModel.AddToTop();
        deferral.Complete();
    }
}