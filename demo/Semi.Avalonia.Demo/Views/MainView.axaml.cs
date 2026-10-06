using Avalonia.Controls;
using CommunityToolkit.Mvvm.Messaging;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Views;

public partial class MainView : DrawerPage
{
    private readonly MainViewModel _viewModel;

    public MainView()
    {
        InitializeComponent();
        DataContext = _viewModel = new MainViewModel();
        _viewModel.Navigator = NavPage;
        _ = _viewModel.NavigateToItemAsync(_viewModel.SelectedItem!);
        WeakReferenceMessenger.Default.Register<string, string>(this, "JumpTo", MessageHandler);
    }

    private void MessageHandler(object _, string message)
    {
        _viewModel.TryNavigateTo(message);
    }
}
