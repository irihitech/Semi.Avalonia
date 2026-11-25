using Avalonia;
using Avalonia.Controls;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class SettingsPage : ContentPage
{
    private readonly SettingsPageViewModel _viewModel = new();

    public SettingsPage()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        // The page instance outlives navigation, so follow the window that shows it now.
        _viewModel.Attach(TopLevel.GetTopLevel(this) as Window);
    }
}
