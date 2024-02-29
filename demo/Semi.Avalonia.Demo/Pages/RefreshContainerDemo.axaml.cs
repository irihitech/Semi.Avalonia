using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

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

public class RefreshContainerDemoViewModel : ObservableObject
{
    public ObservableCollection<string> Items { get; }

    public RefreshContainerDemoViewModel()
    {
        Items = new ObservableCollection<string>(Enumerable.Range(1, 200).Select(i => $"Item {i}"));
    }

    public async Task AddToTop()
    {
        await Task.Delay(1000);
        Items.Insert(0, $"Item {200 - Items.Count}");
    }
}