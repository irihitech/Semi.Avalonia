using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Semi.Avalonia.Demo.Views;

namespace Semi.Avalonia.Demo.Android;

public partial class App : Application
{
    public App()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is ISingleViewApplicationLifetime single)
        {
            single.MainView = new MainView()
            {

            };
        }
        base.OnFrameworkInitializationCompleted();
    }
}