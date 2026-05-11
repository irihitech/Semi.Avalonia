using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Semi.Avalonia.Demo.ViewModels;
using Semi.Avalonia.Demo.Views;

namespace Semi.Avalonia.Demo;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
#if DEBUG
        this.AttachDeveloperTools();
#endif
        DataContext = new ApplicationViewModel();
        if (OperatingSystem.IsLinux())
        {
            Resources.Add("DefaultFontFamily", null);
        }
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow { DataContext = new MainViewModel() };
        }
        else if (ApplicationLifetime is IActivityApplicationLifetime applicationLifetime)
        {
            applicationLifetime.MainViewFactory = () => new MainView { DataContext = new MainViewModel() };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView { DataContext = new MainViewModel() };
        }

        this.RegisterFollowSystemTheme();
        base.OnFrameworkInitializationCompleted();
    }
}
