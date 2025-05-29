using Avalonia.Controls;
using Avalonia.Interactivity;
using Semi.Avalonia.Demo.ViewModels;

namespace Semi.Avalonia.Demo.Pages;

public partial class AboutUs : UserControl
{
    public AboutUs()
    {
        InitializeComponent();
        this.DataContext = new AboutUsViewModel();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (this.DataContext is AboutUsViewModel vm)
        {
            var launcher = TopLevel.GetTopLevel(this)?.Launcher;
            vm.Launcher = launcher;
        }
    }
}