using Avalonia;
using Avalonia.Controls;
using Irihi.Lingua;
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

    // The picker switches the Lingua manager itself; the theme ships its own localized strings.
    private void OnCultureChanged(object? sender, CultureChangedEventArgs e)
    {
        if (Application.Current is { } app)
        {
            Semi.Avalonia.SemiTheme.OverrideLocaleResources(app, e.Culture?.Culture);
        }
    }
}
