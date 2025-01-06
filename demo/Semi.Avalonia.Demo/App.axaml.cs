using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Platform;
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
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new MainWindow();
                break;
            case ISingleViewApplicationLifetime singleView:
                singleView.MainView = new MainView();
                break;
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var setting = PlatformSettings?.GetColorValues();
            if (setting?.ContrastPreference is ColorContrastPreference.High)
            {
                if (setting.AccentColor1 == Color.Parse("#8EE3F0"))
                {
                    RequestedThemeVariant = SemiTheme.Aquatic;
                }
                else if (setting.AccentColor1 == Color.Parse("#903909"))
                {
                    RequestedThemeVariant = SemiTheme.Desert;
                }
                else if (setting.AccentColor1 == Color.Parse("#A1BFDE"))
                {
                    RequestedThemeVariant = SemiTheme.Dusk;
                }
                else if (setting.AccentColor1 == Color.Parse("#D6B4FD"))
                {
                    RequestedThemeVariant = SemiTheme.NightSky;
                }
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}