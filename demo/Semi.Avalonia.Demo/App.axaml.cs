using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Semi.Avalonia.Demo.Views;

namespace Semi.Avalonia.Demo;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindow();
                break;
            case ISingleViewApplicationLifetime singleView:
                singleView.MainView = new MainView();
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }
}